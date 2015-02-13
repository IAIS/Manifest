using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Manifest.Utils
{
    public class DetailsManager
    {
        private static DetailsManager _instance;
        
        private Filters _billOfLadingFilter;
        private Filters _consignmentFilter;

        private DetailsManager()
        {
            _billOfLadingFilter = Filters.AllFields;
            _consignmentFilter = Filters.AllFields;
        }

        public static DetailsManager GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DetailsManager();
            }
            return _instance;
        }

        public Filters GetBillOfLadingFilters()
        {
            return _billOfLadingFilter;
        }

        private void SetBillOfLadingFilters(Filters filter)
        {
            _billOfLadingFilter = filter;
        }

        public Filters GetConsignmentFilter()
        {
            return _consignmentFilter;
        }

        private void SetCosignmentFilter(Filters filter)
        {
            _consignmentFilter = filter;
        }

        public void SetFilter(String className, Filters filter)
        {
            if (className.Equals("BillOfLading"))
            {
                SetBillOfLadingFilters(filter);
            }
            if (className.Equals("Consignment"))
            {
                SetCosignmentFilter(filter);
            }
        }
    }
}
