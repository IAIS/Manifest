using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace Manifest.Shared
{
    /// <summary>
    ///     VOYAGE DETAILS
    /// </summary>
    public class Voyage
    {
        public Voyage()
        {
            BillOfLadings = new ObservableCollection<BillOfLading>();
        }

        [Required, MaxLength(18)]
        public String LineCode { get; set; }

        [Required, MaxLength(18)]
        public String VoyageAgentCode { get; set; }

        [Required, MaxLength(90)]
        public String VesselName { get; set; }

        [Required, MaxLength(30)]
        public String AgentsVoyageNumber { get; set; }

        [Required, MaxLength(15)]
        public String PortCodeOfDischarge { get; set; }

        [Required, MaxLength(33)]
        public String ExpectedToArriveDate { get; set; }

        [MaxLength(18)]
        public String RotationNumber { get; set; }

        [Required, MaxLength(9)]
        public String MessageType { get; set; }

        [Required]
        public Int32 NoOfInstalment { get; set; }

        [Required, MaxLength(15)]
        public Int32 AgentsManifestSequenceNumber { get; set; }

        public ObservableCollection<BillOfLading> BillOfLadings;
    }
}