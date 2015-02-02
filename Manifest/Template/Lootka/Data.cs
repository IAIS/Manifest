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
    [XmlRoot(Namespace = "", IsNullable = false)]
    public class Data
    {
        public DataManifest[] itemsField;

        /// <remarks />
        [XmlElement("Manifest", Form = XmlSchemaForm.Unqualified)]
        public DataManifest[] Items
        {
            get { return itemsField; }
            set { itemsField = value; }
        }
    }
}