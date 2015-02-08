using System;
using System.ComponentModel.DataAnnotations;

namespace Manifest.Shared
{
    public class Consignment
    {
        //TODO: Should Be Number Based On JEA
        [Required]
        public String SerialNumber { get; set; }

        public String MarksAndNumbers { get; set; }

        [Required]
        public String CargoDescription { get; set; }

        public String UsedOrNewIndicator { get; set; }

        [Required]
        public String CommodityCode { get; set; }

        //TODO: Should Be Integer Based on JEA!
        [Required]
        public Double ConsignmentPackages { get; set; }

        [Required]
        public String PackageType { get; set; }

        [Required]
        public String PackageTypeCode { get; set; }

        [Required]
        public Double NoOfPallets { get; set; }

        [Required]
        public Double ConsignmentWeightInKg { get; set; }

        [Required]
        public Double ConsignmentVolumeInCubicMeters { get; set; }

        [Required]
        public String DangerousGoodIndicator { get; set; }

        public String IMOClassNumber { get; set; }

        public String UnNumberOfDangerousGoods { get; set; }

        public Double FlashPoint { get; set; }

        public String UnitOfTemperature { get; set; }

        public String StorageRequestedForDangerousGoods { get; set; }

        [Required]
        public String RefrigerationRequired { get; set; }

        public Double MinimumTemperatureOfRefrigeration { get; set; }

        public Double MaximumTemperatureOfRefrigeration { get; set; }

        public String UnitOfRefregerationTemperature { get; set; }

        public Consignment()
        {
            RefrigerationRequired = "0";
            UnitOfTemperature = "C";
            DangerousGoodIndicator = "";
        }

        public override string ToString()
        {
            return this.GetType().Name + " [SerialNumber: " + this.SerialNumber + "] ";
        }
    }
}