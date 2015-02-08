using System;
using System.ComponentModel.DataAnnotations;

namespace Manifest.Shared
{
    public class JManifestVehicle
    {
        [Required]
        public String vehicleEquipmentIndicator { get; set; }

        [Required]
        public String usedOrNew { get; set; }

        public String chassisNumber { get; set; }

        public String caseNumber { get; set; }

        [Required]
        public String make { get; set; }

        [Required]
        public String model { get; set; }

        public String engineNumber { get; set; }

        public String yearBuilt { get; set; }

        public String color { get; set; }

        [Required]
        public String rollingOrStatic { get; set; }

        [Required]
        public String descriptionOfGood { get; set; }

        public String additionalAccessories { get; set; }

        public Double weightInKG { get; set; }

        public Double volume { get; set; }

        public String remarks { get; set; }
    }
}