﻿/// <remarks/>
[System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.3038")]
[System.SerializableAttribute()]
[System.Diagnostics.DebuggerStepThroughAttribute()]
[System.ComponentModel.DesignerCategoryAttribute("code")]
[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true)]
public partial class mapsMap {
    
    private string sourceClassField;
    
    private string destinationClassField;
    
    private mapsMapProperty[] propertyField;
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string sourceClass {
        get {
            return this.sourceClassField;
        }
        set {
            this.sourceClassField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute(Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public string destinationClass {
        get {
            return this.destinationClassField;
        }
        set {
            this.destinationClassField = value;
        }
    }
    
    /// <remarks/>
    [System.Xml.Serialization.XmlElementAttribute("property", Form=System.Xml.Schema.XmlSchemaForm.Unqualified)]
    public mapsMapProperty[] property {
        get {
            return this.propertyField;
        }
        set {
            this.propertyField = value;
        }
    }
}