using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Manifest.Shared;

namespace Manifest.Utils
{
    public static class ParameterUtility
    {
        public static Voyage GetVoyage()
        {
            return ((App)Application.Current).Voyage;
        }

        public static void SetVoyage(Voyage voyage)
        {
            ((App) Application.Current).Voyage = voyage;
        }

        public static ObservableCollection<BillOfLading> GetBillOfLading()
        {
            return GetVoyage().BillOfLadings;
        }

        public static void SetBillOfLading(ObservableCollection<BillOfLading> billOfLadings)
        {
            GetVoyage().BillOfLadings = billOfLadings;
        }

        public static ObservableCollection<Consignment> GetConsignments()
        {
            IEnumerable<Consignment> consignments = GetVoyage().BillOfLadings.SelectMany(b => b.Containers).SelectMany(c => c.Consignments);
            ObservableCollection<Consignment> result = new ObservableCollection<Consignment>();
            foreach (Consignment consignment in consignments)
            {
                result.Add(consignment);
            }
            return result;
        }

        public static void SetRelations(ObservableCollection<JRelation> relations)
        {
            
        }

        public static ObservableCollection<JRelation> GetRelations()
        {
            ObservableCollection<BillOfLading> billOfLadings = GetBillOfLading();
            ObservableCollection<JRelation> result = new ObservableCollection<JRelation>();
            foreach (BillOfLading billOfLading in billOfLadings)
            {
                foreach (Container container in billOfLading.Containers)
                {
                    JRelation relation = new JRelation()
                    {
                        ConsignmentWeightInKg = 0,
                        Number = container.ContainerNumber,
                        BolNumber = billOfLading.BillOfLadingNo,
                        QuantityInConsignment = 0
                    };
                    result.Add(relation);
                }
            }
            return result;
        }

        public static void SetContainer(ObservableCollection<Container> containers)
        {
           throw new NotImplementedException(); 
        }

        public static ObservableCollection<Container> GetContainers()
        {
            // TODO: convert list without using foreach
            ObservableCollection<Container> result = new ObservableCollection<Container>();
            IEnumerable<Container> containers = GetBillOfLading().SelectMany(b => b.Containers);
            foreach (Container container in containers)
            {
                result.Add(container);
            }
            return result;
        }
    }
}
