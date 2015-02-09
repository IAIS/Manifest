using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace Manifest.Template.Hoopad
{
    /// <remarks />
    [GeneratedCode("xsd", "2.0.50727.3038")]
    [Serializable]
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(AnonymousType = true)]
    public class Manifest
    {
        private BLSBL[] bLSField;
        private string manifestDateField;
        private string masterNameField;

        private string projectCodeField;

        private string projectVesselNameField;
        private string referenceField;


        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ManifestDate
        {
            get { return manifestDateField; }
            set { manifestDateField = value; }
        }

        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Reference
        {
            get { return referenceField; }
            set { referenceField = value; }
        }

        /// <summary>
        /// LineCode
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ProjectCode
        {
            get { return projectCodeField; }
            set { projectCodeField = value; }
        }

        /// <summary>
        /// VesselName
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ProjectVesselName
        {
            get { return projectVesselNameField; }
            set { projectVesselNameField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MasterName
        {
            get { return masterNameField; }
            set { masterNameField = value; }
        }

        /// <remarks />
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("BL", typeof (BLSBL), Form = XmlSchemaForm.Unqualified, IsNullable = false)]
        public BLSBL[] BLS
        {
            get { return bLSField; }
            set { bLSField = value; }
        }


    }
}