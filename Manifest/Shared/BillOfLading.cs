using System;
using System.Collections.Generic;
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

        [Required, MaxLength(60)]
        public String BillOfLadingNo { get; set; }

        [Required, MaxLength(18)]
        public String BoxPartenringLineCode { get; set; }

        [Required, MaxLength(18)]
        public String BoxPartenringAgentCode { get; set; }

        [Required, MaxLength(15)]
        public String PortCodeOfOrigin { get; set; }

        [Required, MaxLength(15)]
        public String PortCodeOfLoading { get; set; }

        [Required, MaxLength(15)]
        public String PortCodeOfDischarge { get; set; }

        [Required, MaxLength(15)]
        public String PortCodeOfDestination { get; set; }
        
        [MaxLength(33)]
        public String DateOfLoading { get; set; }

        [MaxLength(24)]
        public String ManifestRegistrationNumber { get; set; }

        [Required, MaxLength(3)]
        public String TradeCode { get; set; }

        [MaxLength(3)]
        public String TransShipmentMode { get; set; }

        [MaxLength(90)]
        public String BillOfLadingOwnerName { get; set; }

        [MaxLength(720)]
        public String BillOfLadingOwnerAddress { get; set; }

        [Required, MaxLength(3)]
        public String CargoCode { get; set; }

        [MaxLength(3)]
        public String ConsolidatedCargoIndicator { get; set; }

        [MaxLength(3)]
        public String StorageRequestCode { get; set; }

        [MaxLength(21)]
        public String ContainerServiceType { get; set; }

        [Required, MaxLength(6)]
        public String CountryOfOrigin { get; set; }

        [MaxLength(90)]
        public String OriginalConsigneeName { get; set; }

        [MaxLength(720)]
        public String OriginalConsigneeAddress { get; set; }

        [MaxLength(90)]
        public String OriginalVesselName { get; set; }
        
        [MaxLength(30)]
        public String OriginalVoyageNumber { get; set; }

        [MaxLength(60)]
        public String OriginalBolNumber { get; set; }

        [MaxLength(90)]
        public String OriginalShipperName { get; set; }

        [Required, MaxLength(90)]
        public String OriginalShipperAddess { get; set; }

        [MaxLength(300)]
        public String ShipperName { get; set; }

        [Required, MaxLength(90)]
        public String ShipperAddess { get; set; }

        [MaxLength(6)]
        public String ShipperCountryCode { get; set; }

        [Required, MaxLength(15)]
        public String ConsigneeCode { get; set; }

        [Required, MaxLength(144)]
        public String ConsigneeName { get; set; }

        [Required, MaxLength(720)]
        public String ConsigneeAddress { get; set; }

        [MaxLength(18)]
        public String Notify1Code { get; set; }

        [Required, MaxLength(144)]
        public String Notify1Name { get; set; }

        [Required, MaxLength(720)]
        public String Notify1Address { get; set; }

        [MaxLength(18)]
        public String Notify2Code { get; set; }

        [MaxLength(144)]
        public String Notify2Name { get; set; }

        [MaxLength(720)]
        public String Notify2Address { get; set; }

        [MaxLength(18)]
        public String Notify3Code { get; set; }

        [MaxLength(144)]
        public String Notify3Name { get; set; }

        [MaxLength(720)]
        public String Notify3Address { get; set; }

        [Required, MaxLength(600)]
        public String MarksAndNumbers { get; set; }

        [Required, MaxLength(30)]
        public String CommodityCode { get; set; }

        [Required, MaxLength(300)]
        public String CommodityDescription { get; set; }

        [Required]
        public Double Packages { get; set; }

        [Required, MaxLength(90)]
        public String PackageType { get; set; }

        [Required, MaxLength(9)]
        public String PackageTypeCode { get; set; }

        [MaxLength(30)]
        public String ContainerNumber { get; set; }

        [MaxLength(3)]
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

        [MaxLength(3)]
        public String SlacIndicator { get; set; }

        [MaxLength(9)]
        public String ContractCarriageCondition { get; set; }

        [MaxLength(600)]
        public String Remarks { get; set; }
    }
}