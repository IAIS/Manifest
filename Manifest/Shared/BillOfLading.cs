using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;


namespace Manifest.Shared
{
    [MetadataType(typeof(BillOfLading))]
    public class BillOfLading
    {
        public BillOfLading()
        {
            Containers = new ObservableCollection<Container>();
        }

        public ObservableCollection<Container> Containers { get; set; }

        [Required]
        public String BillOfLadingNo { get; set; }

        [Required]
        public String BoxPartenringLineCode { get; set; }

        [Required]
        public String BoxPartenringAgentCode { get; set; }

        [Required]
        public String PortCodeOfOrigin { get; set; }

        [Required]
        public String PortCodeOfLoading { get; set; }

        [Required]
        public String PortCodeOfDischarge { get; set; }

        [Required]
        public String PortCodeOfDestination { get; set; }
        
        public String DateOfLoading { get; set; }

        public String ManifestRegistrationNumber { get; set; }

        [Required]
        public String TradeCode { get; set; }

        public String TransShipmentMode { get; set; }

        public String BillOfLadingOwnerName { get; set; }

        public String BillOfLadingOwnerAddress { get; set; }

        [Required]
        public String CargoCode { get; set; }

        public String ConsolidatedCargoIndicator { get; set; }

        public String StorageRequestCode { get; set; }

        public String ContainerServiceType { get; set; }

        [Required]
        public String CountryOfOrigin { get; set; }

        public String OriginalConsigneeName { get; set; }

        public String OriginalConsigneeAddress { get; set; }

        public String OriginalVesselName { get; set; }
        
        public String OriginalVoyageNumber { get; set; }

        public String OriginalBolNumber { get; set; }

        public String OriginalShipperName { get; set; }

        [Required]
        public String OriginalShipperAddess { get; set; }

        public String ShipperName { get; set; }

        [Required]
        public String ShipperAddess { get; set; }

        public String ShipperCountryCode { get; set; }

        [Required]
        public String ConsigneeCode { get; set; }

        [Required]
        public String ConsigneeName { get; set; }

        [Required]
        public String ConsigneeAddress { get; set; }

        public String Notify1Code { get; set; }

        [Required]
        public String Notify1Name { get; set; }

        [Required]
        public String Notify1Address { get; set; }

        public String Notify2Code { get; set; }

        public String Notify2Name { get; set; }

        public String Notify2Address { get; set; }

        public String Notify3Code { get; set; }

        public String Notify3Name { get; set; }

        public String Notify3Address { get; set; }

        [Required]
        public String MarksAndNumbers { get; set; }

        [Required]
        public String CommodityCode { get; set; }

        [Required]
        public String CommodityDescription { get; set; }

        [Required]
        public Double Packages { get; set; }

        [Required]
        public String PackageType { get; set; }

        [Required]
        public String PackageTypeCode { get; set; }

        public String ContainerNumber { get; set; }

        public String CheckDigit { get; set; }

        public Double NoOfContainers { get; set; }

        public Double NoOfTeus { get; set; }

        public Double TotalTareWeightInMT { get; set; }

        [Required]
        public Double CargoWeightInKg { get; set; }

        [Required]
        public Double GrossWeightInKg { get; set; }

        public Double CargoVolumeInCubicMetre { get; set; }

        public Double TotalQuantity { get; set; }

        public Double FreightTonne { get; set; }

        public Double NoOfPallets { get; set; }

        public String SlacIndicator { get; set; }

        public String ContractCarriageCondition { get; set; }

        public String Remarks { get; set; }

        public override string ToString()
        {

            return this.GetType().Name + " [BillOfLadingNo: " + this.BillOfLadingNo + "] ";
        }
    }
}