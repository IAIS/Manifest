using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Manifest.Converter;
using Manifest.Resources;
using Manifest.Shared;
using Microsoft.Win32;
using Newtonsoft.Json;
using Warehouse.Exceptions;

namespace Manifest.UI
{
    /// <summary>
    /// Interaction logic for UploadRelation.xaml
    /// </summary>
    public partial class UploadRelation : UserControl
    {
        private readonly ObservableCollection<JRelation> _relations = new ObservableCollection<JRelation>(); 

        public UploadRelation()
        {
            InitializeComponent();
            gridRelation.ItemsSource = _relations;
        }

        private void BtnUploadContainer_OnClick(object sender, RoutedEventArgs e)
        {
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Multiselect = false;
                dialog.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";

                if (dialog.ShowDialog() == true)
                {
                    List<JRelation> relations = SimpleConverter.Convert<JRelation>(dialog.FileName, "Manifest.Shared.JRelation");
                    _relations.Clear();
                    foreach (JRelation relation in relations)
                    {
                        _relations.Add(relation);
                    }
                    btnNext.IsEnabled = true;
                }
            }
            catch (Exception ex)
            {
                throw new UserInterfaceException(10201, ExceptionMessage.RelationOpen, ex);
            }
        }

        private void BtnNext_OnClick(object sender, RoutedEventArgs e)
        {
            File.WriteAllText("temp3.txt", JsonConvert.SerializeObject(_relations), Encoding.UTF8);
        }
    }
}
