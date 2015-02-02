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
    public class DataManifestBLSBLContainerDataContainer
    {
        private string aPartField;

        private string aPartPercentField;
        private string containerNoField;
        private string containerTypeField;

        private string gwField;
        private string monetaryRefField;
        private string overHeightField;
        private string overLenghtField;
        private string overWidthField;

        private string ownerShipField;

        private string packageQtyField;

        private string packageUnitField;
        private string remarksField;
        private string sealNoField;
        private string slotPositionField;
        private string twField;

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MonetaryRef
        {
            get { return monetaryRefField; }
            set { monetaryRefField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ContainerType
        {
            get { return containerTypeField; }
            set { containerTypeField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ContainerNo
        {
            get { return containerNoField; }
            set { containerNoField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SealNo
        {
            get { return sealNoField; }
            set { sealNoField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string OverWidth
        {
            get { return overWidthField; }
            set { overWidthField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string OverLenght
        {
            get { return overLenghtField; }
            set { overLenghtField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string OverHeight
        {
            get { return overHeightField; }
            set { overHeightField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string APart
        {
            get { return aPartField; }
            set { aPartField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string APartPercent
        {
            get { return aPartPercentField; }
            set { aPartPercentField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string TW
        {
            get { return twField; }
            set { twField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string GW
        {
            get { return gwField; }
            set { gwField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string OwnerShip
        {
            get { return ownerShipField; }
            set { ownerShipField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string SlotPosition
        {
            get { return slotPositionField; }
            set { slotPositionField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Remarks
        {
            get { return remarksField; }
            set { remarksField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PackageQty
        {
            get { return packageQtyField; }
            set { packageQtyField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PackageUnit
        {
            get { return packageUnitField; }
            set { packageUnitField = value; }
        }
    }
}