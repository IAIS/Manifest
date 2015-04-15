using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manifest.Utils
{
    public class ComboBoxesValues
    {
        public static ArrayList comboListCreator(string type)
        {
            ArrayList comboList = new ArrayList();

            if (type.CompareTo("TradeCode") == 0)
            {
                comboList.Add("I"); //"I - IMPORT"
                comboList.Add("T"); //"T - TRANS-SHIPMENT"
            }
            else if (type.CompareTo("TransShipmentMode") == 0)
            {
                comboList.Add("S"); //"S - SEA"
                comboList.Add("A"); //"A - AIR"
                comboList.Add("R"); //"R - ROAD"
            }
            else if (type.CompareTo("CargoCode") == 0)
            {
                comboList.Add("F"); //F: FCL Container
                comboList.Add("L"); //L: LCL Container
                comboList.Add("M"); //M: Empty Container
                comboList.Add("B"); //B: Bulk Solid
                comboList.Add("Q"); //Q: Bulk Liquid
                comboList.Add("R"); //R: RO-RO Unit
                comboList.Add("P"); //P: Passanger
                comboList.Add("G"); //G: General Cargo (Break Bulk)
            }
            else if (type.CompareTo("ConsolidatedCargoIndicator") == 0)
            {
                comboList.Add("Y"); //Y: Yes for Consolidation Cargo (Groupage Cargo)
                comboList.Add("N"); //N: NO Otherwise
            }
            else if (type.CompareTo("StorageRequestCode") == 0)
            {
                comboList.Add("D"); //D: Direct Delivey
                comboList.Add("S"); //S: Storage in Sheds
                comboList.Add("Y"); //Y: Storage in Yards
            }
            else if (type.CompareTo("SlacIndicator") == 0)
            {
                comboList.Add("Y"); //Y: Yes
                comboList.Add("N"); //N: NO
            }
            /****** Consignment.cs ******/
            else if (type.CompareTo("UsedOrNewIndicator") == 0)
            {
                comboList.Add("U"); //U: Used Commodity
                comboList.Add("N"); //N: New Commodity
            }
            else if (type.CompareTo("DangerousGoodIndicator") == 0)
            {
                comboList.Add("Y"); //Y: Yes
                comboList.Add("N"); //N: NO
            }
            else if (type.CompareTo("UnitOfTemperature") == 0)
            {
                comboList.Add("C"); //C: Centigrade
                comboList.Add("F"); //F: Farenheit
            }
            else if (type.CompareTo("StorageRequestedForDangerousGoods") == 0)
            {
                comboList.Add("D"); //D: Direct Delivey
                comboList.Add("S"); //S: Storage in Sheds
                comboList.Add("Y"); //Y: Storage in Yards
            }
            else if (type.CompareTo("RefrigerationRequired") == 0)
            {
                comboList.Add("Y"); //Y: Yes
                comboList.Add("N"); //N: NO
            }
            else if (type.CompareTo("UnitOfRefregerationTemperature") == 0)
            {
                comboList.Add("C"); //C: Centigrade
                comboList.Add("F"); //F: Farenheit
            }
            return comboList;
        }
    }
}
