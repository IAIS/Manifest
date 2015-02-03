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
    public class NotifyExtraInfo
    {
        private string notifyEmailField;

        private string notifyFaxField;

        private string notifyMobileField;

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string NotifyEmail
        {
            get { return notifyEmailField; }
            set { notifyEmailField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string NotifyFax
        {
            get { return notifyFaxField; }
            set { notifyFaxField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string NotifyMobile
        {
            get { return notifyMobileField; }
            set { notifyMobileField = value; }
        }
    }
}