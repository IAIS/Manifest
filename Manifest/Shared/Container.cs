using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Manifest.Utils;

namespace Manifest.Shared
{
    [MetadataType(typeof(Container))]
    public class Container
    {
        public Container()
        {
            Consignments = new List<Consignment>();
            CheckDigit = "1";
        }

        [Required, Display(Order = 41), MyStringLength(30)]
        public String ContainerNumber { get; set; }

        [Required, Display(Order = 42), MyStringLength(3)]
        public String CheckDigit { get; set; }

        [Required, Display(Order = 43)]
        public Double TareWeightInMT { get; set; }

        [Required, Display(Order = 44), MyStringLength(30)]
        public String SealNo { get; set; }

        // ReSharper disable once FieldCanBeMadeReadOnly.Global
        public List<Consignment> Consignments;

        protected bool Equals(Container other)
        {
            return string.Equals(ContainerNumber, other.ContainerNumber);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((Container)obj);
        }

        public override int GetHashCode()
        {
            return (ContainerNumber != null ? ContainerNumber.GetHashCode() : 0);
        }

        public override string ToString()
        {
            return this.GetType().Name + " [ContainerNumber: " + this.ContainerNumber + "] ";
        }

        public void Finalize()
        {
            // DO Nothnig
        }
    }
}