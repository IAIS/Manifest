using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.IO;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Web;
using Manifest.Resources;
using Manifest.Shared;
using Manifest.Utils;
using Microsoft.Win32;
using Warehouse.Exceptions;

namespace Warehouse.Utilities
{
    public class MakeManifestForOldBOL
    {
        public Voyage TextFileToManifest(string textFileInput)
        {
            Voyage manifest = new Voyage();

            manifest.AgentsVoyageNumber = "1*1";
            manifest.AgentsManifestSequenceNumber = "1*1";
            manifest.VesselName = "1*1";
            
            var reader = new StreamReader(textFileInput);
            manifest.VoyageAgentCode = reader.ReadLine();
            manifest.LineCode = manifest.VoyageAgentCode;


            while (!reader.EndOfStream)
            {
                BillOfLading bol = new BillOfLading();
                bol.BillOfLadingNo = reader.ReadLine();
                bol.PortCodeOfOrigin = "irnot";
                bol.PortCodeOfLoading = "irnot";
                bol.PortCodeOfDischarge = "irnot";
                bol.PortCodeOfDestination = "irnot";
                bol.CountryOfOrigin = "ir";
                bol.ShipperName = manifest.VoyageAgentCode;
                bol.ShipperAddress = "-";
                bol.ConsigneeAddress = "-";
                bol.Notify1Address = "-";
                bol.MarksAndNumbers = "-";
                bol.CommodityCode = "99999999";
                bol.CommodityDescription = "-";
                bol.Packages = 1.0;
                bol.PackageType = "UNT";
                bol.PackageTypeCode = "UNT";
                bol.CargoWeightInKg = 1.0;
                bol.GrossWeightInKg = 1.0;

                manifest.BillOfLadings.Add(bol);
            }
            reader.Close();

            StringBuilder builder = new StringBuilder("");
            builder.AppendLine("\"VOY\"," + Printer.Print(manifest));

            List<BillOfLading> billOfLadings = manifest.BillOfLadings.ToList();
            foreach (BillOfLading billOfLading in billOfLadings)
            {
                builder.AppendLine("\"BOL\"," + Printer.Print(billOfLading));
                foreach (Container container in billOfLading.Containers)
                {
                    builder.AppendLine("\"CTR\"," + Printer.Print(container));
                    foreach (Consignment consignment in container.Consignments)
                    {
                        builder.AppendLine("\"CON\"," + Printer.Print(consignment));
                    }
                }
            }

            try
            {
                SaveFileDialog dialog = new SaveFileDialog();
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
                if (dialog.ShowDialog() == true)
                {

                    File.WriteAllText(dialog.FileName, builder.ToString(), Encoding.ASCII);
                }
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10301, ExceptionMessage.VoyagSave, ex);
            }

            return manifest;
        }
    }
}