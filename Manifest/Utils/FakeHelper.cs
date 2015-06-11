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
        public static Voyage GenerateFakeManifest(String textFileInput)
        {
            Voyage manifest = new Voyage
            {
                AgentsVoyageNumber = "1*1",
                AgentsManifestSequenceNumber = "1*1",
                VesselName = "1*1"
            };

            StreamReader reader = new StreamReader(textFileInput);
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
            reader.Close();

            
            return manifest;
        }
    }
}