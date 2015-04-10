using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manifest.Utils
{
    //TODO: Complete List Of Port Code Based On http://freightforum.com/portcodes
    public class PortCodeConverter
    {
        private readonly Dictionary<String, String> _emirates;
        private readonly Dictionary<String, String> _iran; 
        public PortCodeConverter()
        {
            _emirates = new Dictionary<String, String>()
            {
                {"AAN", "Al Ain"},
                {"ABU", "Abu al Bukhoosh"},
                {"AJM", "Ajman"},
                {"AMU", "Abu Musa"},
                {"AUH", "Abu Dhabi"},
                {"DAS", "Das Island"},
                {"DBP", "Dibba"},
                {"DHF", "Al Dhafra"},
                {"DUY", "Ras Zubbaya (Ras Dubayyah)"},
                {"DXB", "Dubai"},
                {"FAT", "Fateh Terminal"},
                {"FJR", "Al Fujayrah"},
                {"FMZ", "Musafa"},
                {"HAM", "Al Hamriyah"},
                {"IND", "Indooroodilly"},
                {"JEA", "Jebel Ali"},
                {"JED", "Jebel Dhanna"},
                {"JYH", "Jumayrah"},
                {"KHA", "Khalidia"},
                {"KLF", "Khor al Fakkan"},
                {"MAS", "Masfut"},
                {"MBS", "Mubarras Island"},
                {"MKH", "Mina Khalid"},
                {"MSA", "Mina Saqr"},
                {"MUB", "Mubarek Terminal"},
                {"MZD", "Mina Zayed/Abu Dhabi"},
                {"NHD", "Minhad"},
                {"PRA", "Port Rashid"},
                {"QIW", "Umm al Qaiwain"},
                {"RKT", "Ras al Khaimah"},
                {"RUW", "Ar Ruways"},
                {"SHJ", "Sharjah"},
                {"ULR", "Umm Al Nar"},
                {"ZUR", "Zirku Island"},
            };
            _iran = new Dictionary<String, String>()
            {
                {"ABD", "Abadan"},
                {"ACZ", "Zabol"},
                {"ADU", "Ardabil"},
                {"AMR", "Amara"},
                {"ARA", "Arak"},
                {"ASA", "Asaluyeh"},
                {"ASR", "Astara"},
                {"AWZ", "Ahwaz"},
                {"AZD", "Yazd"},
                {"BAH", "Bandar Assaluyeh"},
                {"BAJ", "Bajgiran"},
                {"BAZ", "Bandar-e Anzali"},
                {"BBL", "Babolsar"},
                {"BDH", "Bandar-e Lengeh"},
                {"BJB", "Bojnurd"},
                {"BKM", "Bandar Khomeini"},
                {"BMR", "Bandar Mashur"},
                {"BND", "Bandar Abbas"},
                {"BRG", "Bandar-e Gaz"},
                {"BSR", "Bandar Shahid Rajaee"},
                {"BUZ", "Bushehr"},
                {"BXR", "Bam"},
                {"CKT", "Sarakhs"},
                {"DAM", "Damavand"},
                {"DGN", "Basargan"},
                {"DJU", "Jolfa"},
                {"DOG", "Do Gharun"},
                {"ESF", "Esfahan"},
                {"GHA", "Ghazvin (Qazwin)"},
                {"GSM", "Gheshm"},
                {"HDM", "Hamadan"},
                {"HEJ", "Henjam"},
                {"HOR", "Hormuz"},
                {"IAQ", "Bahregan"},
                {"IFN", "Isfahan"},
                {"IMH", "Imam Hasan"},
                {"IQH", "Islam Qal'eh"},
                {"JAK", "Jask"},
                {"KAS", "Kashan"},
                {"KER", "Kerman"},
                {"KHA", "Khaneh"},
                {"KHD", "Khorramabad"},
                {"KHK", "Khark Island"},
                {"KHO", "Khorramshahr"},
                {"KHS", "Khosravi"},
                {"KHY", "Khvoy"},
                {"KIH", "Kish Island"},
                {"KMS", "Kermanshah"},
                {"KNR", "Kangan"},
                {"KSH", "Kermanshah (Bakhtaran)"},
                {"LIN", "Lingah"},
                {"LRR", "Lar"},
                {"LVP", "Lavan"},
                {"MHD", "Mashad"},
                {"MRX", "Bandar-e M?h Shahr"},
                {"NKW", "Nakhjav?n Tappeh"},
                {"NSH", "Now Shahr"},
                {"OMH", "Orumiyeh"},
                {"ORU", "Orumiyeh"},
                {"OSM", "Mosul"},
                {"QAZ", "Qazvin"},
                {"QKC", "Karaj"},
                {"QSH", "Qeshm island"},
                {"QSM", "Qeshm"},
                {"QUM", "Qum"},
                {"RAS", "Rasht"},
                {"RBA", "Ras Bahrgan"},
                {"RJN", "Rafsanjan"},
                {"RTM", "Ratawi"},
                {"RZR", "Ramsar"},
                {"SAN", "Sahlan"},
                {"SDG", "Sanandaj"},
                {"SEK", "Shahr-e Kord"},
                {"SEM", "Semnan"},
                {"SIX", "Sari"},
                {"SMW", "Samawa"},
                {"SRA", "Sarooj Anchorage"},
                {"SRJ", "Sirjan"},
                {"SRY", "Sary"},
                {"SVH", "Saveh"},
                {"SXI", "Sirri Island"},
                {"SYZ", "Shiraz"},
                {"TAJ", "Tajabad"},
                {"TBZ", "Tabriz"},
                {"TCX", "Tabas"},
                {"THR", "Tehran"},
                {"TMB", "Tombak"},
                {"UZA", "Al Uzsayr"},
                {"WPS", "Persepolis"},
                {"XBJ", "Birjand"},
                {"ZAH", "Zahedan"},
                {"ZAN", "Zanjan"},
                {"ZBR", "Chah Bahar"},
            };
        }
        /// <summary>
        /// Return Origin Country Based On Port Code, If No Country Has Found Return dash.
        /// </summary>
        /// <param name="portCode"></param>
        /// <returns></returns>
        public String GetCountry(String portCode)
        {
            if (portCode.Length == 5)   // e.g IRBND
            {
                return portCode.Substring(0, 2);
            }
            else if (portCode.Length == 3)  // e.g JEA
            {
                if (_emirates.ContainsKey(portCode))
                {
                    return "United Arab Emirates";
                }
                else if (_iran.ContainsKey(portCode))
                {
                    return "Iran";
                }
            }
            return "-";
        }
    }
}
