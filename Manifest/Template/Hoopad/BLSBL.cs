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
    public class BLSBL
    {
        private string bLDateField;
        private string bLNOField;
        private string bookingAgentField;

        private string bookingReferenceNOField;
        private ConsigneeExtraInfo consigneeExtraInfoField;

        private string consigneeField;
        private ContainerDataContainer[] containerContainerDataField;

        private string dESCRIPTIONField;

        private string destinationField;
        private string discPortField;
        private string fPNOField;
        private string finalPortField;
        private string goodsLCNoField;
        private string lDTermField;
        private string loadPortField;

        private string localVesselField;
        private string marksField;
        private string netWeightField;
        private string notifyAddressField;

        private NotifyExtraInfo notifyExtraInfoField;
        private string onwardInlandRoutingField;
        private string onwardInlandRoutingNameField;
        private string originField;
        private string originPortField;
        private string paymentField;
        private string pointCountryOrigionField;
        private string pointCountryOrigionNameField;

        private PricingDataPrice[] pricingPricingDataField;
        private string projectCodeField;
        private Shipper shipperField;
        private string termField;
        private string volumeField;
        private string volumeUnitField;
        private string wEIGHTField;
        private string weightUnitField;

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string BLNO
        {
            get { return bLNOField; }
            set { bLNOField = value; }
        }

        /// <summary>
        /// BillOfLadingNo
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string BookingReferenceNO
        {
            get { return bookingReferenceNOField; }
            set { bookingReferenceNOField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string BLDate
        {
            get { return bLDateField; }
            set { bLDateField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string GoodsLCNo
        {
            get { return goodsLCNoField; }
            set { goodsLCNoField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string FPNO
        {
            get { return fPNOField; }
            set { fPNOField = value; }
        }

        /// <summary>
        /// CargoWeightInKg
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string WEIGHT
        {
            get { return wEIGHTField; }
            set { wEIGHTField = value; }
        }

        /// <summary>
        /// GrossWeightInKg
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string NetWeight
        {
            get { return netWeightField; }
            set { netWeightField = value; }
        }

        /// <summary>
        /// CargoVolumeInCubicMetre
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Volume
        {
            get { return volumeField; }
            set { volumeField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string WeightUnit
        {
            get { return weightUnitField; }
            set { weightUnitField = value; }
        }

        /// <summary>
        /// 
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string VolumeUnit
        {
            get { return volumeUnitField; }
            set { volumeUnitField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Term
        {
            get { return termField; }
            set { termField = value; }
        }

        /// <summary>
        /// PortCodeOfOrigin
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string OriginPort
        {
            get { return originPortField; }
            set { originPortField = value; }
        }

        /// <summary>
        /// PortCodeOfLoading
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string LoadPort
        {
            get { return loadPortField; }
            set { loadPortField = value; }
        }

        /// <summary>
        /// PortCodeOfDischarge
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DiscPort
        {
            get { return discPortField; }
            set { discPortField = value; }
        }

        /// <summary>
        /// PortCodeOfDestination
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string FinalPort
        {
            get { return finalPortField; }
            set { finalPortField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string LDTerm
        {
            get { return lDTermField; }
            set { lDTermField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string ProjectCode
        {
            get { return projectCodeField; }
            set { projectCodeField = value; }
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
        public string PointCountryOrigionName
        {
            get { return pointCountryOrigionNameField; }
            set { pointCountryOrigionNameField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string PointCountryOrigion
        {
            get { return pointCountryOrigionField; }
            set { pointCountryOrigionField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string OnwardInlandRoutingName
        {
            get { return onwardInlandRoutingNameField; }
            set { onwardInlandRoutingNameField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string OnwardInlandRouting
        {
            get { return onwardInlandRoutingField; }
            set { onwardInlandRoutingField = value; }
        }

        /// <summary>
        /// BillOfLadingOwnerAddress
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Consignee
        {
            get { return consigneeField; }
            set { consigneeField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string NotifyAddress
        {
            get { return notifyAddressField; }
            set { notifyAddressField = value; }
        }

        /// <summary>
        /// MarksAndNumbers
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Marks
        {
            get { return marksField; }
            set { marksField = value; }
        }

        /// <summary>
        /// Remark
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string DESCRIPTION
        {
            get { return dESCRIPTIONField; }
            set { dESCRIPTIONField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Origin
        {
            get { return originField; }
            set { originField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string Destination
        {
            get { return destinationField; }
            set { destinationField = value; }
        }

        /// <summary>
        /// OriginalVesselName
        /// </summary>
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string LocalVessel
        {
            get { return localVesselField; }
            set { localVesselField = value; }
        }

        /// <remarks />
        [XmlElement(Form = XmlSchemaForm.Unqualified)]
        public string BookingAgent
        {
            get { return bookingAgentField; }
            set { bookingAgentField = value; }
        }

        /// <remarks />
        [XmlElement("Shipper", Form = XmlSchemaForm.Unqualified)]
        public Shipper Shipper
        {
            get { return shipperField; }
            set { shipperField = value; }
        }

        /// <remarks />
        [XmlElement("ConsigneeExtraInfo", Form = XmlSchemaForm.Unqualified)]
        public ConsigneeExtraInfo ConsigneeExtraInfo
        {
            get { return consigneeExtraInfoField; }
            set { consigneeExtraInfoField = value; }
        }

        /// <remarks />
        [XmlElement("NotifyExtraInfo", Form = XmlSchemaForm.Unqualified)]
        public NotifyExtraInfo NotifyExtraInfo
        {
            get { return notifyExtraInfoField; }
            set { notifyExtraInfoField = value; }
        }

        /// <remarks />
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Price", typeof (PricingDataPrice), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public PricingDataPrice[] PricingData
        {
            get { return pricingPricingDataField; }
            set { pricingPricingDataField = value; }
        }

        /// <remarks />
        [XmlArray(Form = XmlSchemaForm.Unqualified)]
        [XmlArrayItem("Container", typeof (ContainerDataContainer), Form = XmlSchemaForm.Unqualified,
            IsNullable = false)]
        public ContainerDataContainer[] ContainerData
        {
            get { return containerContainerDataField; }
            set { containerContainerDataField = value; }
        }
    }
}