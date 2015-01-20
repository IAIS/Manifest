using System;
using System.ComponentModel.DataAnnotations;

namespace Manifest.Shared
{
    /// <summary>
    ///     VOYAGE DETAILS
    /// </summary>
    public class VoyageDetails
    {
        [Required, MaxLength(18)]
        public String manifestOwner { get; set; }

        [Required, MaxLength(18)]
        public String voyageAgentCode { get; set; }

        [Required, MaxLength(90)]
        public String nameOfCarrier { get; set; }

        [Required, MaxLength(30)]
        public String agentsVoyageNumber { get; set; }

        [Required, MaxLength(15)]
        public String portCodeOfDischarge { get; set; }

        [Required, MaxLength(33)]
        public String expectedToArriveDate { get; set; }

        [MaxLength(18)]
        public String rotationNumber { get; set; }

        [Required, MaxLength(15)]
        public String agentsManifestReferenceNumber { get; set; }
    }
}