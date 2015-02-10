using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manifest.Utils
{
    public class PackageTypeConverter
    {
        private Dictionary<String, String> _dictionary; 
        public PackageTypeConverter()
        {
            _dictionary = new Dictionary<String, String>(StringComparer.OrdinalIgnoreCase)
            {
                {"BAGS", "BAG"},
                {"BALES", "BAL"},
                {"BUNDLES", "BDL"},
                {"BLOCKS", "BLK"},
                {"BOBBIN", "BOB"},
                {"BOATS", "BOT"},
                {"BOXES", "BOX"},
                {"BARREL", "BRL"},
                {"BRIQUETTES", "BRQ"},
                {"CANS", "CAN"},
                {"CARBOY", "CBY"},
                {"CABLE DRUM", "CDR"},
                {"COLLI", "CLI"},
                {"COILS", "COI"},
                {"CRATES", "CRT"},
                {"CASES", "CSE"},
                {"CASKS", "CSK"},
                {"CARTONS", "CTN"},
                {"CONTAINERS", "CTR"},
                {"CYLINDERS", "CYL"},
                {"DRUMS", "DRM"},
                {"DOZENS", "DZN"},
                {"FIBRE DRUM", "FDR"},
                {"ITEM", "ITM"},
                {"JOTTAS", "JOT"},
                {"KEGS", "KEG"},
                {"MODULES", "MDL"},
                {"METAL DRUM", "MDR"},
                {"PAIL", "PAL"},
                {"PARCEL", "PCL"},
                {"PIECES", "PCS"},
                {"PLASTIC DRUM", "PDR"},
                {"PACKAGES", "PKG"},
                {"PACKET", "PKT"},
                {"PALLET", "PLT"},
                {"REEL", "REL"},
                {"ROLLS", "ROL"},
                {"SACKS", "SAK"},
                {"SETS", "SET"},
                {"SHEETS", "SHT"},
                {"SKID", "SKD"},
                {"STEEL PACKAGES", "SPK"},
                {"STEEL PLATES", "SPL"},
                {"STEEL TRUNKS", "STR"},
                {"TEA CHEST", "TCH"},
                {"TONS", "TON"},
                {"UNIT", "UNT"}
            };
        }
        public String GetPackageTypeCode(String packageType)
        {
            if (packageType == null)
            {
                return null;
            }
            if (this._dictionary.ContainsKey(packageType))
            {
                return _dictionary[packageType];
            }
            if (!String.IsNullOrWhiteSpace(packageType))
            {
                if (packageType.Length > 3)
                {
                    String singlePackageType = packageType.Substring(0, packageType.Length - 3) + "S";
                    if (this._dictionary.ContainsKey(singlePackageType))
                    {
                        return _dictionary[singlePackageType];
                    }
                }
            }
            return "-";
        }
    }
}
