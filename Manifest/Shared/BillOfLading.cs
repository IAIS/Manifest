using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Windows.Controls;
using Manifest.Utils;



namespace Manifest.Shared
{
    [MetadataType(typeof(BillOfLading))]
    public class BillOfLading
    {
        public BillOfLading()
        {
            Containers = new List<Container>();
            TradeCode = "I";
            TransShipmentMode = "S";
            CargoCode = "F";
            ConsolidatedCargoIndicator = "Y";
            BoxPartenringAgentCode = ConfiguraionManager.GetInstance().GetLineCode();
            BoxPartenringLineCode = ConfiguraionManager.GetInstance().GetLineCode();
            ConsigneeCode = "0";
            CheckDigit = "1";
            ConsolidatedCargoIndicator = "N";
            StorageRequestCode = "Y";
            ContainerServiceType = "FCL/FCL";
            ConsigneeName = "-";
            Notify1Name = "-";
            SlacIndicator = "Y";
            BillOfLadingNo = "";
            DateOfLoading = DateTime.Now.Date;
        }

        public void Finilize()
        {
            if (String.IsNullOrWhiteSpace(this.CountryOfOrigin))
            {
                if (PortCodeOfOrigin != null)
                {
                    CountryOfOrigin = new PortCodeConverter().GetCountry(PortCodeOfOrigin);
                }
            }
            Container firstContainer = Containers.FirstOrDefault();
            if (firstContainer != null)
            {
                this.ContainerNumber = firstContainer.ContainerNumber;
                Consignment firstConsignment = firstContainer.Consignments.FirstOrDefault();
                if (firstConsignment != null)
                {
                    CommodityCode = firstConsignment.CommodityCode;
                    PackageType = firstConsignment.PackageType;
                    PackageTypeCode = firstConsignment.PackageTypeCode;
                }
            }
            NoOfContainers = this.Containers.Count;
            if (PortCodeOfDischarge.Equals(PortCodeOfDestination)) // بار واردات
            {
                TradeCode = "I";
            }
            else // بار ترانزیت
            {
                TradeCode = "T";
            }
            Double packages = 0;
            Double weight = 0;
            foreach(Container container in this.Containers)
            {
                weight += container.TareWeightInMT;
                foreach(Consignment consignment in container.Consignments)
                {
                    packages += consignment.ConsignmentPackages;
                }
            }
            this.Packages = packages;
            this.TotalTareWeightInMT = weight;
            this.TotalQuantity = packages;
        }

        public List<Container> Containers { get; set; }

        [Required, Display(Order = 21), MyStringLength(60)]
        public String BillOfLadingNo { get; set; }

        [Required, Display(Order = 22), MyStringLength(18)]
        public String BoxPartenringLineCode { get; set; }

        [Required, Display(Order = 23), MyStringLength(18)]
        public String BoxPartenringAgentCode { get; set; }

        [Required, Display(Order = 24), MyStringLength(15)]
        public String PortCodeOfOrigin { get; set; }

        [Required, Display(Order = 25), MyStringLength(15)]
        public String PortCodeOfLoading { get; set; }

        [Required, Display(Order = 26), MyStringLength(15)]
        public String PortCodeOfDischarge { get; set; }

        [Required, Display(Order = 27), MyStringLength(15)]
        public String PortCodeOfDestination { get; set; }

        [Display(Order = 28), MyStringLength(33)]
        public DateTime DateOfLoading { get; set; }

        [Display(Order = 29), MyStringLength(24)]
        public String ManifestRegistrationNumber { get; set; }

        [Required, Display(Order = 210), MyStringLength(3)]
        public String TradeCode { get; set; }

        [Display(Order = 211), MyStringLength(3)]
        public String TransShipmentMode { get; set; }

        [Display(Order = 212), MyStringLength(90)]
        public String BillOfLadingOwnerName { get; set; }

        [Display(Order = 213), MyStringLength(3)]
        public String BillOfLadingOwnerAddress { get; set; }

        [Required, Display(Order = 214), MyStringLength(144)]
        public String CargoCode { get; set; }

        [Display(Order = 215), MyStringLength(3)]
        public String ConsolidatedCargoIndicator { get; set; }

        [Display(Order = 216), MyStringLength(3)]
        public String StorageRequestCode { get; set; }

        [Display(Order = 217), MyStringLength(21)]
        public String ContainerServiceType { get; set; }

        [Required, Display(Order = 218), MyStringLength(6)]
        public String CountryOfOrigin { get; set; }

        [Display(Order = 219), MyStringLength(90)]
        public String OriginalConsigneeName { get; set; }

        [Display(Order = 220), MyStringLength(720)]
        public String OriginalConsigneeAddress { get; set; }

        [Display(Order = 221), MyStringLength(90)]
        public String OriginalVesselName { get; set; }

        [Display(Order = 222), MyStringLength(30)]
        public String OriginalVoyageNumber { get; set; }

        [Display(Order = 223), MyStringLength(60)]
        public String OriginalBolNumber { get; set; }

        [Display(Order = 224), MyStringLength(90)]
        public String OriginalShippShipperName { get; set; }

        [Display(Order = 225), MyStringLength(144)]
        public String OriginalShipperAddess { get; set; }

        [Required, Display(Order = 226), MyStringLength(90)]
        public String ShipperName { get; set; }

        [Required, Display(Order = 227), MyStringLength(720)]
        public String ShipperAddress { get; set; }

        [Display(Order = 228), MyStringLength(6)]
        public String ShipperCountryCode { get; set; }

        [Required, Display(Order = 229), MyStringLength(15)]
        public String ConsigneeCode { get; set; }

        [Required, Display(Order = 230), MyStringLength(144)]
        public String ConsigneeName { get; set; }

        [Required, Display(Order = 231), MyStringLength(720)]
        public String ConsigneeAddress { get; set; }

        [Display(Order = 232), MyStringLength(18)]
        public String Notify1Code { get; set; }

        [Required, Display(Order = 233), MyStringLength(144)]
        public String Notify1Name { get; set; }

        [Required, Display(Order = 234), MyStringLength(720)]
        public String Notify1Address { get; set; }

        [Display(Order = 235), MyStringLength(18)]
        public String Notify2Code { get; set; }

        [Display(Order = 236), MyStringLength(144)]
        public String Notify2Name { get; set; }

        [Display(Order = 237), MyStringLength(720)]
        public String Notify2Address { get; set; }

        [Display(Order = 238), MyStringLength(18)]
        public String Notify3Code { get; set; }

        [Display(Order = 239), MyStringLength(144)]
        public String Notify3Name { get; set; }

        [Display(Order = 240), MyStringLength(720)]
        public String Notify3Address { get; set; }

        [Required, Display(Order = 241), MyStringLength(600)]
        public String MarksAndNumbers { get; set; }

        [Required, Display(Order = 242), MyStringLength(30)]
        public String CommodityCode { get; set; }

        [Required, Display(Order = 243), MyStringLength(900)]
        public String CommodityDescription { get; set; }

        [Required, Display(Order = 244)]
        public Double Packages { get; set; }

        [Required, Display(Order = 245), MyStringLength(90)]
        public String PackageType { get; set; }

        [Required, Display(Order = 246), MyStringLength(9)]
        public String PackageTypeCode { get; set; }

        [Display(Order = 247), MyStringLength(30)]
        public String ContainerNumber { get; set; }

        [Display(Order = 248), MyStringLength(3)]
        public String CheckDigit { get; set; }

        [Display(Order = 249)]
        public Double NoOfContainers { get; set; }

        [Display(Order = 250)]
        public Double NoOfTeus { get; set; }

        [Display(Order = 251)]
        public Double TotalTareWeightInMT { get; set; }

        [Required, Display(Order = 252)]
        public Double CargoWeightInKg { get; set; }

        [Required, Display(Order = 253)]
        public Double GrossWeightInKg { get; set; }

        [Display(Order = 254)]
        public Double CargoVolumeInCubicMetre { get; set; }

        [Display(Order = 255)]
        public Double TotalQuantity { get; set; }

        [Display(Order = 256)]
        public Double FreightTonne { get; set; }

        [Display(Order = 257)]
        public Double NoOfPallets { get; set; }

        [Display(Order = 258), MyStringLength(3)]
        public String SlacIndicator { get; set; }

        [Display(Order = 259), MyStringLength(9)]
        public String ContractCarriageCondition { get; set; }

        [Display(Order = 260), MyStringLength(600)]
        public String Remarks { get; set; }

        public override string ToString()
        {

            return this.GetType().Name + " [BillOfLadingNo: " + this.BillOfLadingNo + "] ";
        }
    }
}