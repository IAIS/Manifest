using System;
using System.ComponentModel.DataAnnotations;

namespace Manifest.Shared
{
    public class JManifestContainer
    {
        [Required, MaxLength(30)]
        public String number { get; set; }

        [Required, MaxLength(3)]
        public String checkDigit { get; set; }

        [Required]
        public Double weight { get; set; }

        [Required, MaxLength(30)]
        public String sealNo { get; set; }
    }
}