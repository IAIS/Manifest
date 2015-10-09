using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Manifest.Resources;
using Manifest.Shared;
using Microsoft.Win32;
using Warehouse.Exceptions;

namespace Manifest.Utils
{
    public class FakeHelper
    {
        public static Voyage GenerateFakeManifest(String agentVoyageNumber, List<String> fakeBillOfLadings, string commodityCode = "99999999", string consigneCode = "0", string portCodeOfDischarge = "irnot", string portCodeOfLoading = "irnot")
        {
            Voyage manifest = new Voyage
            {
                AgentsVoyageNumber = "1*1",
                AgentsManifestSequenceNumber = "1*1",
                VesselName = "1*1", 
                PortCodeOfDischarge = portCodeOfDischarge, 
            };


            manifest.VoyageAgentCode = agentVoyageNumber;
            manifest.LineCode = manifest.VoyageAgentCode;

            foreach (string fakeBillOfLading in fakeBillOfLadings)
            {
                BillOfLading bol = new BillOfLading
                {
                    BillOfLadingNo = fakeBillOfLading,
                    PortCodeOfOrigin = portCodeOfLoading,
                    PortCodeOfLoading = portCodeOfLoading,
                    PortCodeOfDischarge = portCodeOfDischarge,
                    PortCodeOfDestination = portCodeOfDischarge,
                    CountryOfOrigin = "ir",
                    ShipperName = manifest.VoyageAgentCode,
                    ShipperAddress = "-",
                    ConsigneeAddress = "-",
                    Notify1Address = "-",
                    MarksAndNumbers = "-",
                    ConsigneeCode = consigneCode, 
                    CommodityCode = commodityCode,
                    CommodityDescription = "-",
                    Packages = 1.0,
                    PackageType = "UNT",
                    PackageTypeCode = "UNT",
                    CargoWeightInKg = 1.0,
                    GrossWeightInKg = 1.0
                };

                Container container = new Container()
                {
                    ContainerNumber = "F123456",
                    SealNo = "F996633"
                };

                container.Consignments.Add(new Consignment()
                {
                    SerialNumber = "F234567",
                    MarksAndNumbers = "Fake Commodity",
                    CargoDescription = "Fake Cargo Description",
                    CommodityCode = "123457890",
                    PackageType = "Pallet",
                    PackageTypeCode = "PLT"
                });

                bol.Containers.Add(container);

                manifest.BillOfLadings.Add(bol);
            }

            return manifest;
        }

        public static Voyage GenerateFakeManifest(String textFileInput)
        {
            StreamReader reader = new StreamReader(textFileInput);
            String agentVoyageNumber = reader.ReadLine();
            List<String> fakeBillOfLadings = new List<string>();
            while (!reader.EndOfStream)
            {
                fakeBillOfLadings.Add(reader.ReadLine());
            }
            reader.Close();

            return GenerateFakeManifest(agentVoyageNumber, fakeBillOfLadings);
        }
    }
}