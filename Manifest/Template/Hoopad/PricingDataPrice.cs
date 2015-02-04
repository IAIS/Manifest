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
    public class PricingDataPrice
    {
        private string amountField;
        private string amountTypeField;
        private string currencyField;
        private string monetaryRefField;

        private string officeField;

        private string otherAgentField;
        private string paymentField;

        private string qtyField;

        private string rateField;
        private string serviceExplainField;
        private string serviceTypeField;

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string MonetaryRef
        {
            get { return monetaryRefField; }
            set { monetaryRefField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ServiceType
        {
            get { return serviceTypeField; }
            set { serviceTypeField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Payment
        {
            get { return paymentField; }
            set { paymentField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Office
        {
            get { return officeField; }
            set { officeField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string OtherAgent
        {
            get { return otherAgentField; }
            set { otherAgentField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string AmountType
        {
            get { return amountTypeField; }
            set { amountTypeField = value; }
        }

        /// <summary>
        /// CargoDescription
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ServiceExplain
        {
            get { return serviceExplainField; }
            set { serviceExplainField = value; }
        }

        /// <summary>
        /// ConsignmentPackages
        /// NoOfPallets
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Qty
        {
            get { return qtyField; }
            set { qtyField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Rate
        {
            get { return rateField; }
            set { rateField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Amount
        {
            get { return amountField; }
            set { amountField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Currency
        {
            get { return currencyField; }
            set { currencyField = value; }
        }
    }
}