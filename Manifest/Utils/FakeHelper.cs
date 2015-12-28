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
        private readonly Random _random;

        public FakeHelper()
        {
            this._random =  new Random();
        }

        public Voyage GenerateFakeManifest(String agentVoyageNumber, List<String> fakeBillOfLadings, string agentVoyageCode = "1*1",
            string commodityCode = "99999999", string consigneCode = "0", string portCodeOfDischarge = "irnot", string portCodeOfDestination = "irnot", string portCodeOfLoading = "irnot")
        {

            Voyage manifest = new Voyage
            {
                AgentsVoyageNumber = agentVoyageCode,
                AgentsManifestSequenceNumber = agentVoyageCode,
                VesselName = agentVoyageCode,
                PortCodeOfDischarge = portCodeOfDischarge,
                VoyageAgentCode = agentVoyageNumber,
            };

            manifest.LineCode = manifest.VoyageAgentCode;

            for (int i = 0; i < fakeBillOfLadings.Count; i++)
            {
                string fakeBillOfLading = fakeBillOfLadings[i];
                BillOfLading bol = GenerateFakeBillOfLading(fakeBillOfLading, portCodeOfLoading, portCodeOfDischarge,
                    portCodeOfDestination, agentVoyageCode, consigneCode, commodityCode);

                // یک کانتینر با یک قلم کالا
                if (i % 3 == 0)
                {
                    Container container = GenerateFakeContainer();

                    container.Consignments.Add(GenerateFakeConsignment(commodityCode));
                    container.Consignments.Add(GenerateFakeConsignment(commodityCode));

                    bol.NoOfContainers = 1;

                    bol.Containers.Add(container);
                }
                else
                {
                    Container container1 = GenerateFakeContainer();

                    container1.Consignments.Add(GenerateFakeConsignment(commodityCode));

                    bol.Containers.Add(container1);

                    Container container2 = GenerateFakeContainer();

                    container2.Consignments.Add(GenerateFakeConsignment(commodityCode));
                    container2.Consignments.Add(GenerateFakeConsignment(commodityCode));

                    bol.NoOfContainers = 2;

                    bol.Containers.Add(container2);

                }

                bol.TotalQuantity = bol.Containers.Sum(ctr => ctr.Consignments.Sum(cons => cons.ConsignmentPackages));
                bol.Packages = bol.Containers.Sum(ctr => ctr.Consignments.Sum(cons => cons.ConsignmentPackages));
                bol.TotalTareWeightInMT = bol.Containers.Sum(ctr => ctr.Consignments.Sum(cons => cons.ConsignmentWeightInKg));


                manifest.BillOfLadings.Add(bol);
            }

            return manifest;
        }

        public Voyage GenerateFakeManifest(String textFileInput)
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

        public Container GenerateFakeContainer(string number, string sealNo)
        {
            Container c = new Container()
            {
                ContainerNumber = number,
                SealNo = sealNo
            };
            return c;
        }

        private Container GenerateFakeContainer()
        {
            return GenerateFakeContainer("FAKU" + _random.Next(100000, 999999).ToString() + "-" + _random.Next(0, 9), "F" + _random.Next(100000, 999999));
        }

        private Consignment GenerateFakeConsignment(string commodityCode)
        {
            return new Consignment
            {
                SerialNumber = "F234567",
                MarksAndNumbers = "Fake Commodity",
                CargoDescription = "Fake Cargo Description",
                CommodityCode = GetCommodityCode(commodityCode),
                PackageType = "Pallet",
                PackageTypeCode = "PLT",
                ConsignmentWeightInKg = _random.NextDouble(),
                ConsignmentPackages = _random.NextDouble(),
                ConsignmentVolumeInCubicMeters = _random.NextDouble(),
                NoOfPallets = _random.NextDouble(),
            };
        }

        private BillOfLading GenerateFakeBillOfLading(string fakeBillOfLading, string portCodeOfLoading, string portCodeOfDischarge, string portCodeOfDestination, string voyageAgentCode, string consigneCode, string commodityCode)
        {
            return new BillOfLading
            {
                BillOfLadingNo = fakeBillOfLading,
                PortCodeOfOrigin = portCodeOfLoading,
                PortCodeOfLoading = portCodeOfLoading,
                PortCodeOfDischarge = portCodeOfDischarge,
                PortCodeOfDestination = portCodeOfDestination,
                CountryOfOrigin = "ir",
                ShipperName = voyageAgentCode,
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
        }

        public string GetCommodityCode(string seed)
        {
            if (seed.Equals("99999999"))
            {
                return "99999999";
            }
            else
            {
                Random random = _random;
                List<string> commodityCodes = new List<string>() { "09083110", "10064000", "10063000" };
                int index = random.Next(commodityCodes.Count);
                return commodityCodes[index];
            }
        }

    }
}