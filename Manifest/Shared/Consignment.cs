using System;
using System.ComponentModel.DataAnnotations;
using Manifest.Utils;

namespace Manifest.Shared
{
    public class Consignment
    {
        public Consignment()
        {
            RefrigerationRequired = "N";
            UnitOfTemperature = "C";
            DangerousGoodIndicator = "N";
            UsedOrNewIndicator = "N";
        }

        public void Finilize()
        {
            
        }

        [Required, Display(Order = 31), MyStringLength(18)]
        public String SerialNumber { get; set; }

        [Display(Order = 32), MyStringLength(600)]
        public String MarksAndNumbers { get; set; }

        [Required, Display(Order = 33), MyStringLength(300)]
        public String CargoDescription { get; set; }

        [Display(Order = 34), MyStringLength(3)]
        public String UsedOrNewIndicator { get; set; }

        [Required, Display(Order = 35), MyStringLength(30)]
        public String CommodityCode { get; set; }

        [Required, Display(Order = 36)]
        public Double ConsignmentPackages { get; set; }

        [Required, Display(Order = 37), MyStringLength(90)]
        public String PackageType { get; set; }

        [Required, Display(Order = 38), MyStringLength(9)]
        public String PackageTypeCode { get; set; }

        [Required, Display(Order = 39)]
        public Double NoOfPallets { get; set; }

        [Required, Display(Order = 310)]
        public Double ConsignmentWeightInKg { get; set; }

        [Required, Display(Order = 311)]
        public Double ConsignmentVolumeInCubicMeters { get; set; }

        [Required, Display(Order = 312), MyStringLength(1)]
        public String DangerousGoodIndicator { get; set; }

        [Display(Order = 313), MyStringLength(9)]
        public String IMOClassNumber { get; set; }

        [Display(Order = 314), MyStringLength(15)]
        public String UnNumberOfDangerousGoods { get; set; }

        [Display(Order = 315)]
        public Double FlashPoint { get; set; }

        [Display(Order = 316), MyStringLength(1)]
        public String UnitOfTemperature { get; set; }

        [Display(Order = 317), MyStringLength(3)]
        public String StorageRequestedForDangerousGoods { get; set; }

        [Required, Display(Order = 318), MyStringLength(3)]
        public String RefrigerationRequired { get; set; }

        [Display(Order = 319)]
        public Double MinimumTemperatureOfRefrigeration { get; set; }

        [Display(Order = 320)]
        public Double MaximumTemperatureOfRefrigeration { get; set; }

        [Display(Order = 321), MyStringLength(3)]
        public String UnitOfRefregerationTemperature { get; set; }

        public override string ToString()
        {
            return this.GetType().Name + " [SerialNumber: " + this.SerialNumber + "] ";
        }
    }
}