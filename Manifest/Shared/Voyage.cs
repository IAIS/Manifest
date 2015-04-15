using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using Manifest.Utils;

namespace Manifest.Shared
{
    /// <summary>
    ///     VOYAGE DETAILS
    /// </summary>
    public class Voyage
    {
        public Voyage()
        {
            BillOfLadings = new List<BillOfLading>();
            MessageType = "MFI";
            RotationNumber = "";
            NoOfInstalment = 1;
            PortCodeOfDischarge = "-";
            ExpectedToArriveDate = DateTime.Now;
            if (String.IsNullOrWhiteSpace(this.LineCode))
            {
                this.LineCode = ConfiguraionManager.GetInstance().GetLineCode();
            }
            if (String.IsNullOrWhiteSpace(this.VoyageAgentCode))
            {
                this.VoyageAgentCode = ConfiguraionManager.GetInstance().GetVoyageAgentCode();
            } 
        }

        public void Finalize(string portCodeOfLoading)
        {
            AgentsManifestSequenceNumber = portCodeOfLoading + AgentsVoyageNumber;

            int index = 1;
            foreach (BillOfLading billOfLading in BillOfLadings)
            {
                billOfLading.ManifestRegistrationNumber = AgentsManifestSequenceNumber;
                foreach (Container container in billOfLading.Containers)
                {
                    foreach (Consignment consignment in container.Consignments)
                    {
                        consignment.SerialNumber = index.ToString();
                        index ++;
                    }
                }
            }
        }

        [Required, Display(Order = 11), MyStringLength(18)]
        public String LineCode { get; set; }

        [Required, Display(Order = 12), MyStringLength(18)]
        public String VoyageAgentCode { get; set; }

        [Required, Display(Order = 13), MyStringLength(90)]
        public String VesselName { get; set; }

        [Required, Display(Order = 14), MyStringLength(30)]
        public String AgentsVoyageNumber { get; set; }

        [Required, Display(Order = 15), MyStringLength(15)]
        public String PortCodeOfDischarge { get; set; }

        [Required, Display(Order = 16), MyStringLength(33)]
        public DateTime ExpectedToArriveDate { get; set; }

        [Display(Order = 17), MyStringLength(18)]
        public String RotationNumber { get; set; }

        [Required, Display(Order = 18), MyStringLength(9)]
        public String MessageType { get; set; }

        [Required, Display(Order = 19)]
        public Int32 NoOfInstalment { get; set; }

        [Required, Display(Order = 110), MyStringLength(15)]
        public String AgentsManifestSequenceNumber { get; set; }

        public List<BillOfLading> BillOfLadings;

        public override string ToString()
        {
            return this.GetType().Name + " [LineCode: " + this.LineCode + "] ";
        }
    }
}