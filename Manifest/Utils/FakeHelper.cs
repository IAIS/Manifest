using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using Manifest.Annotations;
using Manifest.Resources;
using Manifest.Shared;
using Microsoft.Win32;
using Warehouse.Exceptions;

namespace Manifest.Utils
{
    public class FakeHelper
    {
        public static Voyage GenerateFakeManifest(String agentVoyageNumber, List<String> fakeBillOfLadings, string agentVoyageCode = "1*1",
            string commodityCode = "99999999", string consigneCode = "0", string portCodeOfDischarge = "irnot", string portCodeOfDestination = "irnot", string portCodeOfLoading = "irnot")
        {

            Random random = new Random();

            Voyage manifest = new Voyage
            {
                AgentsVoyageNumber = agentVoyageCode,
                AgentsManifestSequenceNumber = agentVoyageCode,
                VesselName = agentVoyageCode,
                PortCodeOfDischarge = portCodeOfDischarge,
                VoyageAgentCode = agentVoyageNumber,
            };


            manifest.LineCode = manifest.VoyageAgentCode;

            foreach (string fakeBillOfLading in fakeBillOfLadings)
            {
                BillOfLading bol = new BillOfLading
                {
                    BillOfLadingNo = fakeBillOfLading,
                    PortCodeOfOrigin = portCodeOfLoading,
                    PortCodeOfLoading = portCodeOfLoading,
                    PortCodeOfDischarge = portCodeOfDischarge,
                    PortCodeOfDestination = portCodeOfDestination,
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

                bool isFirstTime = true;

                while (isFirstTime || random.Next() % 3 == 0)
                {
                    Container container = new Container()
                    {
                        ContainerNumber = "FAKE" + random.Next(100000, 999999).ToString() + "-" + random.Next(0, 9),
                        SealNo = "F996633"
                    };

                    while (isFirstTime || random.Next() % 2 == 0)
                    {
                        container.Consignments.Add(new Consignment()
                        {
                            SerialNumber = "F234567",
                            MarksAndNumbers = "Fake Commodity",
                            CargoDescription = "Fake Cargo Description",
                            CommodityCode = GetCommodityCode(commodityCode),
                            PackageType = "Pallet",
                            PackageTypeCode = "PLT"
                        });
                        isFirstTime = false;
                    }


                    bol.Containers.Add(container);

                    
                    if (agentVoyageCode.Equals("0"))
                    {
                        break;
                    }
                }

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

        public static Container GenerateFakeContainer(string number, string sealNo)
        {
            Container c = new Container()
            {
                ContainerNumber = number,
                SealNo = sealNo
            };
            return c;
        }

        public static string GetCommodityCode(string seed)
        {
            if (seed.Equals("99999999"))
            {
                return "99999999";
            }
            else
            {
                Random random = new Random();
                List<string> commodityCodes = new List<string>() {"09083110", "10064000", "10063000"};
                int index = random.Next(commodityCodes.Count);
                return commodityCodes[index];
            }
        }
    }
}