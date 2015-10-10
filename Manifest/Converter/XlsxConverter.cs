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
        
        public static Voyage ConvertExcelToVoyage(string filePath)
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
                Consignment cons = ConvertLineToConsignment(dt.Rows[i]);

                if (dictionary.ContainsKey(dt.Rows[i][1].ToString()))
                {
                    dictionary[dt.Rows[i][1].ToString()].Containers[0].Consignments.Add(cons);
                }
                else
                {
                    BillOfLading bol = ConvertLineToBOL(dt.Rows[i]);
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

        private static BillOfLading ConvertLineToBOL(DataRow dataRow)
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

        private static Consignment ConvertLineToConsignment(DataRow dataRow)
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

                if (filePath.Contains("xls"))
                {
                    excelReader = ExcelReaderFactory.CreateBinaryReader(stream);
                }
                else if (filePath.Contains("xlsx"))
                {
                    excelReader = ExcelReaderFactory.CreateOpenXmlReader(stream);
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
