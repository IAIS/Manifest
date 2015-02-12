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
            MessageType = "MFI";
        }

        [Required]
        public String LineCode { get; set; }

        [Required]
        public String VoyageAgentCode { get; set; }

        [Required]
        public String VesselName { get; set; }

        [Required]
        public String AgentsVoyageNumber { get; set; }

        [Required]
        public String PortCodeOfDischarge { get; set; }

        [Required]
        public String ExpectedToArriveDate { get; set; }

        public String RotationNumber { get; set; }

        public String MessageType { get; set; }

        public Int32 NoOfInstalment { get; set; }

        [Required]
        public Int32 AgentsManifestSequenceNumber { get; set; }

        public ObservableCollection<BillOfLading> BillOfLadings;

        public override string ToString()
        {
            return this.GetType().Name + " [LineCode: " + this.LineCode + "] ";
        }
    }
}