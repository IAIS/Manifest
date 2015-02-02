using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Manifest.Template.Lootka
{
    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class DataManifestBLSBLShipper
    {
        private string shipperAddressField;
        private string shipperCodeField;
        private string shipperFaxField;

        private string shipperNameField;

        private string shipperTelField;

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ShipperCode
        {
            get { return shipperCodeField; }
            set { shipperCodeField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ShipperName
        {
            get { return shipperNameField; }
            set { shipperNameField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ShipperAddress
        {
            get { return shipperAddressField; }
            set { shipperAddressField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ShipperTel
        {
            get { return shipperTelField; }
            set { shipperTelField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ShipperFax
        {
            get { return shipperFaxField; }
            set { shipperFaxField = value; }
        }
    }
}