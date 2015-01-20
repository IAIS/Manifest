using System;
using System.ComponentModel.DataAnnotations;

namespace Manifest.Shared
{
    public class JFlightConsignment
    {
        [Required, MaxLength(18)]
        public String noOfInstalment { get; set; }

        [Required, MaxLength(60)]
        public String id { get; set; }

        public String boxPartenring { get; set; }

        [Required, MaxLength(15)]
        public String portCodeOfOrigin { get; set; }

        [Required, MaxLength(15)]
        public String portCodeOfLoading { get; set; }

        [Required, MaxLength(15)]
        public String portCodeOfDischarge { get; set; }

        [Required, MaxLength(15)]
        public String portCodeOfDestination { get; set; }

        [MaxLength(24)]
        public String manifestRegistrationNumber { get; set; }

        [Required, MaxLength(3)]
        public String tradeCode { get; set; }

        [MaxLength(3)]
        public String transShipmentMode { get; set; }

        [MaxLength(90)]
        public Employee consignor { get; set; }

        [Required, MaxLength(3)]
        public String cargoCode { get; set; }

        [MaxLength(3)]
        public String consolidatedCargoIndicator { get; set; }

        [MaxLength(3)]
        public String storageRequestCode { get; set; }

        [MaxLength(21)]
        public String containerServiceType { get; set; }

        [Required, MaxLength(6)]
        public String countryOfOrigin { get; set; }

        [MaxLength(90)]
        public Employee originalConsignee { get; set; }

        [MaxLength(30)]
        public String originalVesselName { get; set; }

        [MaxLength(60)]
        public String originalBolNumber { get; set; }

        [MaxLength(90)]
        public Employee originalShipper { get; set; }

        [Required, MaxLength(90)]
        public Employee shipper { get; set; }

        [Required, MaxLength(15)]
        public Employee consignee { get; set; }

        [MaxLength(18)]
        public Employee notify1 { get; set; }

        [MaxLength(18)]
        public Employee notify2 { get; set; }

        [MaxLength(18)]
        public Employee notify3 { get; set; }

        [Required, MaxLength(600)]
        public String marksAndNumbers { get; set; }

        [Required, MaxLength(30)]
        public String commodityCode { get; set; }

        [Required, MaxLength(300)]
        public String commodityDescription { get; set; }

        [Required, MaxLength(9)]
        public Double packages { get; set; }

        [Required, MaxLength(9)]
        public String packageTypeCode { get; set; }

        [MaxLength(30)]
        public String containerNumber { get; set; }

        [MaxLength(3)]
        public String checkDigit { get; set; }

        [MaxLength(9)]
        public Double noOfContainers { get; set; }

        [MaxLength(9)]
        public Double noOfTeus { get; set; }

        [MaxLength(18)]
        public Double totalTareWeightInMt { get; set; }

        [Required, MaxLength(39)]
        public Double cargoWeightInKg { get; set; }

        [Required, MaxLength(39)]
        public Double grossWeightInKg { get; set; }

        [MaxLength(39)]
        public Double cargoVolumeInCubicMetre { get; set; }

        [MaxLength(39)]
        public Double totalQuantity { get; set; }

        [MaxLength(39)]
        public Double freightTonne { get; set; }

        [MaxLength(12)]
        public Double noOfPallets { get; set; }

        [MaxLength(3)]
        public String slacIndicator { get; set; }

        [MaxLength(9)]
        public String contractCarriageCondition { get; set; }

        [MaxLength(600)]
        public String remarks { get; set; }
    }
}