using System;
using System.ComponentModel.DataAnnotations;

namespace Manifest.Shared
{
    public class Consignment
    {
        //TODO: Should Be Number Based On JEA
        [Required, MaxLength(50)]
        public String SerialNumber { get; set; }

        [MaxLength(600)]
        public String MarksAndNumbers { get; set; }

        [Required, MaxLength(300)]
        public String CargoDescription { get; set; }

        [MaxLength(3)]
        public String UsedOrNewIndicator { get; set; }

        [Required, MaxLength(30)]
        public String CommodityCode { get; set; }

        //TODO: Should Be Integer Based on JEA!
        [Required]
        public Double ConsignmentPackages { get; set; }

        [Required, MaxLength(90)]
        public String PackageType { get; set; }

        [Required, MaxLength(9)]
        public String PackageTypeCode { get; set; }

        [Required]
        public Double NoOfPallets { get; set; }

        [Required]
        public Double ConsignmentWeightInKg { get; set; }

        [Required]
        public Double ConsignmentVolumeInCubicMeters { get; set; }

        [Required, MaxLength(1)]
        public String DangerousGoodIndicator { get; set; }

        [MaxLength(9)]
        public String IMOClassNumber { get; set; }

        [MaxLength(15)]
        public String UnNumberOfDangerousGoods { get; set; }

        public Double FlashPoint { get; set; }

        [MaxLength(1)]
        public String UnitOfTemperature { get; set; }

        [MaxLength(1)]
        public String StorageRequestedForDangerousGoods { get; set; }

        [Required, MaxLength(1)]
        public String RefrigerationRequired { get; set; }

        public Double MinimumTemperatureOfRefrigeration { get; set; }

        public Double MaximumTemperatureOfRefrigeration { get; set; }

        [MaxLength(1)]
        public String UnitOfRefregerationTemperature { get; set; }
    }
}