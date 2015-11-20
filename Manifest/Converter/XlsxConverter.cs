using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Excel;
using Manifest.Shared;
using Manifest.Utils;

namespace Manifest.Converter
{
    public static class XlsxConverter
    {
        
        public static Voyage ConvertDHLExcelToVoyage(string filePath)
        {
            DataTable dt = ConvertFileToDataSet(filePath).Tables[0];
            Voyage v = ParameterUtility.GetVoyage();
            string lineCode = dt.Rows[0][0].ToString();
            v.LineCode = lineCode;
            v.VoyageAgentCode = lineCode;
            v.VesselName = "DHL";
            v.ExpectedToArriveDate = DateTime.Parse(dt.Rows[0][2].ToString());
            v.AgentsVoyageNumber = lineCode;
            v.PortCodeOfDischarge = dt.Rows[0][20].ToString();
            v.NoOfInstalment = dt.Rows.Count;
            v.AgentsManifestSequenceNumber = lineCode;

            Dictionary<string, BillOfLading> dictionary = new Dictionary<string, BillOfLading>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Consignment cons = ConvertLineToDHLConsignment(dt.Rows[i]);

                if (dictionary.ContainsKey(dt.Rows[i][1].ToString()))
                {
                    dictionary[dt.Rows[i][1].ToString()].Containers[0].Consignments.Add(cons);
                }
                else
                {
                    BillOfLading bol = ConvertLineToDhlBOL(dt.Rows[i]);
                    bol.Containers[0].Consignments.Add(cons);
                    dictionary.Add(bol.BillOfLadingNo , bol);
                }

            }

            foreach (BillOfLading bol in dictionary.Values)
            {
                v.BillOfLadings.Add(bol);
            }

            return v;
            
        }

        public static Voyage ConvertIranAirExcelToVoyage(string filePath)
        {
            DataTable dt = ConvertFileToDataSet(filePath).Tables[0];
            Voyage v = ParameterUtility.GetVoyage();
            string lineCode = dt.Rows[0][2].ToString();
            v.LineCode = lineCode;
            v.VoyageAgentCode = "IranAirCoding";
            v.VesselName = "IranAir";
            v.ExpectedToArriveDate = CommonUtility.DateConverterHijriToMiladi(dt.Rows[0][1].ToString());
            v.AgentsVoyageNumber = dt.Rows[0][0].ToString(); //شماره مانیفست ایران ایر
            v.PortCodeOfDischarge = "TEH-IR"; //پورت مقصد
            v.NoOfInstalment = dt.Rows.Count;
            v.AgentsManifestSequenceNumber = v.AgentsVoyageNumber; // فعلا شماره مانیفست // Agent's refrence number for a manifest for Customs

            Dictionary<string, BillOfLading> dictionary = new Dictionary<string, BillOfLading>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                Consignment cons = ConvertLineToIranAirConsignment(dt.Rows[i]);

                if (dictionary.ContainsKey(dt.Rows[i][3].ToString()))
                {
                    dictionary[dt.Rows[i][3].ToString()].Containers[0].Consignments.Add(cons);
                    dictionary[dt.Rows[i][3].ToString()].MarksAndNumbers += cons.MarksAndNumbers;
                }
                else
                {
                    BillOfLading bol = ConvertLineToIranAirBOL(dt.Rows[i]);
                    bol.Containers[0].Consignments.Add(cons);
                    dictionary.Add(bol.BillOfLadingNo, bol);
                }

            }

            foreach (BillOfLading bol in dictionary.Values)
            {
                v.BillOfLadings.Add(bol);
            }

            return v;

        }

        private static BillOfLading ConvertLineToIranAirBOL(DataRow dataRow)
        {
            BillOfLading bol = new BillOfLading();
            bol.BillOfLadingNo = dataRow[3].ToString();
            bol.BoxPartenringLineCode = "BoxPartenring (Required)";
            bol.BoxPartenringAgentCode = "BoxPartenring (Required)";
            bol.PortCodeOfOrigin = (dataRow[6].ToString() == "") ? "Origin" : (dataRow[6].ToString().Length>15)?dataRow[6].ToString().Substring(0,15):dataRow[6].ToString();
            bol.PortCodeOfLoading = bol.PortCodeOfOrigin;

            bol.PortCodeOfDischarge = "IRTEH";
            bol.PortCodeOfDestination = "IRTEH";
            bol.CountryOfOrigin = "??"; // (Required)

            bol.ShipperName = bol.PortCodeOfOrigin; // (Required)
            bol.ShipperAddress = bol.PortCodeOfOrigin;// (Required)

            bol.ConsigneeName = dataRow[11].ToString(); // در مانیفست هما gyrandeh
            bol.ConsigneeCode = "defaulCode"; // (Required)
            bol.ConsigneeAddress = (dataRow[9].ToString()=="")? "Address or Tel (Required)": dataRow[9].ToString(); // در مانیفست هما Address

            bol.Notify1Address = bol.ConsigneeAddress;
            bol.MarksAndNumbers = (dataRow[10].ToString() == "") ? "Marks and Number (Required)" : dataRow[10].ToString();
            bol.CommodityCode = "CommidityCode (Required)";
            bol.CommodityDescription = dataRow[11].ToString();

            bol.PackageType = bol.MarksAndNumbers; 
            bol.PackageTypeCode = "PKG";



            bol.Containers.Add(FakeHelper.GenerateFakeContainer("IRSU123456-7", "-"));

            return bol;
        }

        private static Consignment ConvertLineToIranAirConsignment(DataRow dataRow)
        {
            Consignment cons = new Consignment();
            cons.SerialNumber = "HSCODE (Required)";
            cons.MarksAndNumbers = (dataRow[10].ToString() == "") ? "Marks and Number (Required)" : dataRow[10].ToString(); // Classnerkh در مانیفست هما
            cons.CommodityCode = "CommidityCode (Required)";
            cons.CargoDescription = cons.SerialNumber + "- " + dataRow[11];
            cons.ConsignmentPackages = int.Parse(dataRow[4].ToString());
            cons.PackageType = cons.MarksAndNumbers; 
            cons.PackageTypeCode = "PKG";
            cons.NoOfPallets = int.Parse(dataRow[4].ToString());
            cons.ConsignmentWeightInKg = double.Parse(dataRow[5].ToString()); //در مانیفست هما realVazn

            return cons;
        }

        private static BillOfLading ConvertLineToDhlBOL(DataRow dataRow)
        {
            BillOfLading bol = new BillOfLading();
            bol.BillOfLadingNo = dataRow[1].ToString();
            bol.BoxPartenringLineCode = "DHL-LINECODE";
            bol.BoxPartenringAgentCode = "DHL-AGENTCODE";
            bol.PortCodeOfOrigin = (dataRow[8].ToString()=="")? dataRow[10].ToString() : dataRow[8].ToString();
            bol.PortCodeOfLoading = bol.PortCodeOfOrigin;
            
            bol.PortCodeOfDischarge = "TEHRAN";
            bol.PortCodeOfDestination = dataRow[18].ToString();
            bol.CountryOfOrigin = dataRow[10].ToString();
            
            bol.ShipperName = dataRow[3] + "-" + dataRow[4];
            bol.ShipperAddress = dataRow[5] + "-" + dataRow[6] + "-"+ dataRow[7] + "-"+ dataRow[8] + "-"+ dataRow[9] + "-"+ dataRow[10] + "- TEL:"+ dataRow[11];

            bol.ConsigneeName = dataRow[15] + " - " + dataRow[16];
            bol.ConsigneeCode = (dataRow[22].ToString()=="") ? bol.ConsigneeName : dataRow[22].ToString();
            bol.ConsigneeAddress = dataRow[15] + "-" + dataRow[16] + "-" + dataRow[17] + "-" + dataRow[18] + "-" + dataRow[19] + "-" + dataRow[20] + "- TEL:" + dataRow[21];

            bol.Notify1Address = bol.ConsigneeAddress;
            bol.MarksAndNumbers = dataRow[26].ToString();
            bol.CommodityCode = dataRow[23].ToString();
            bol.CommodityDescription = dataRow[27] + "-" + dataRow[23];
            bol.PackageType = "PKG";
            bol.PackageTypeCode = "PKG";



            bol.Containers.Add(FakeHelper.GenerateFakeContainer("IRSU123456-7", "-"));
            
            return bol;
        }

        private static Consignment ConvertLineToDHLConsignment(DataRow dataRow)
        {
            Consignment cons =  new Consignment();
            cons.SerialNumber = "HSCODE: " + dataRow[1] + "-" + dataRow[27] + "-" + dataRow[23];
            cons.MarksAndNumbers = dataRow[26].ToString();
            cons.CommodityCode = dataRow[23].ToString();
            cons.CargoDescription = dataRow[27] + "-" + dataRow[23];
            cons.ConsignmentPackages = 1;
            cons.PackageType = "PKG";
            cons.PackageTypeCode = "PKG";
            cons.NoOfPallets = int.Parse(cons.MarksAndNumbers[0].ToString());
            cons.ConsignmentWeightInKg = double.Parse(dataRow[28].ToString());


            return cons;
        }

        

        public static DataSet ConvertFileToDataSet(String filePath)
        {
            try
            {
                FileStream stream = File.Open(filePath, FileMode.Open, FileAccess.Read);
                IExcelDataReader excelReader = null;

                if (filePath.Contains("xlsx"))
                {
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
                }
                else if (filePath.Contains("xls"))
                {
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                

                excelReader.IsFirstRowAsColumnNames = true;
                DataSet result = excelReader.AsDataSet();
                return result;
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
