﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Documents;

namespace Manifest.Shared
{
    public class Container
    {
        public Container()
        {
            Consignments = new List<Consignment>();   
        }

        [Required, MaxLength(30)]
        public String ContainerNumber { get; set; }

        [Required, MaxLength(1)]
        public String CheckDigit { get; set; }

        [Required]
        public Double TareWeightInMT { get; set; }

        [Required, MaxLength(30)]
        public String SealNo { get; set; }

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
            return Equals((Container) obj);
        }

        public override int GetHashCode()
        {
            return (ContainerNumber != null ? ContainerNumber.GetHashCode() : 0);
        }
    }
}