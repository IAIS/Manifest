using System;
using System.ComponentModel.DataAnnotations;

namespace Manifest.Shared
{
    public class JManifestVehicle
    {
        [Required, MaxLength(1)]
        public String vehicleEquipmentIndicator { get; set; }

        [Required, MaxLength(1)]
        public String usedOrNew { get; set; }

        [MaxLength(72)]
        public String chassisNumber { get; set; }

        [MaxLength(72)]
        public String caseNumber { get; set; }

        [Required, MaxLength(60)]
        public String make { get; set; }

        [Required, MaxLength(60)]
        public String model { get; set; }

        [MaxLength(90)]
        public String engineNumber { get; set; }

        [MaxLength(12)]
        public String yearBuilt { get; set; }

        [MaxLength(48)]
        public String color { get; set; }

        [Required, MaxLength(1)]
        public String rollingOrStatic { get; set; }

        [Required, MaxLength(600)]
        public String descriptionOfGood { get; set; }

        [MaxLength(300)]
        public String additionalAccessories { get; set; }

        [MaxLength(39)]
        public Double weightInKG { get; set; }

        [MaxLength(39)]
        public Double volume { get; set; }

        [MaxLength(600)]
        public String remarks { get; set; }
    }
}