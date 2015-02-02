using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Manifest.Template
{
    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class DataManifestBLSBLConsigneeExtraInfo
    {
        private string consigneeEmailField;

        private string consigneeFaxField;

        private string consigneeMobileField;

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ConsigneeEmail
        {
            get { return consigneeEmailField; }
            set { consigneeEmailField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ConsigneeFax
        {
            get { return consigneeFaxField; }
            set { consigneeFaxField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ConsigneeMobile
        {
            get { return consigneeMobileField; }
            set { consigneeMobileField = value; }
        }
    }
}