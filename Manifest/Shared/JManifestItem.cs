using System;
using System.ComponentModel.DataAnnotations;

namespace Manifest.Shared
{
    public class JManifestItem
    {
        [Required, MaxLength(24)]
        public String id { get; set; }

        [MaxLength(600)]
        public String marksAndNumbers { get; set; }

        [Required, MaxLength(300)]
        public String description { get; set; }

        [MaxLength(3)]
        public String usedOrNewIndicator { get; set; }

        [MaxLength(30)]
        public String tarrifHeadingNumber { get; set; }

        [Required, MaxLength(33)]
        public Double quantityInConsignment { get; set; }

        [Required, MaxLength(9)]
        public String packageTypeCode { get; set; }

        [Required, MaxLength(18)]
        public Double noOfPallets { get; set; }

        [Required, MaxLength(39)]
        public Double consignmentWeightInKg { get; set; }

        [Required, MaxLength(39)]
        public Double consignmentVolumeInCubicMeters { get; set; }

        [Required, MaxLength(3)]
        public String dangerousGoodIndicator { get; set; }

        [MaxLength(9)]
        public String iMOClassNumber { get; set; }

        [MaxLength(15)]
        public String uNNumberOfDangerousGoods { get; set; }

        [MaxLength(18)]
        public Double flashPoint { get; set; }

        [MaxLength(3)]
        public String unitOfTemperature { get; set; }

        [MaxLength(3)]
        public String storageRequestForDangerousGoods { get; set; }

        [Required, MaxLength(3)]
        public String refrigerationRequired { get; set; }

        [MaxLength(18)]
        public Double minimumTemperatureOfRefrigeration { get; set; }

        [MaxLength(18)]
        public Double maximumTemperatureOfRefrigeration { get; set; }

        [MaxLength(1)]
        public String unitOfRefregerationTemperature { get; set; }
    }
}