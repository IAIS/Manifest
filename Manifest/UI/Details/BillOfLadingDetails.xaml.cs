using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;
using FirstFloor.ModernUI.Windows.Controls;
using Manifest.Shared;
using Manifest.UserControl;

namespace Manifest.UI.Details
{
    /// <summary>
    /// Interaction logic for BillOfLadingDetails.xaml
    /// </summary>
    public partial class BillOfLadingDetails : ModernWindow
    {
        public BillOfLadingDetails()
        {
            InitializeComponent();
        }

        public void Init(BillOfLading billOfLading)
        {
            ucBillOfLadingDetails.Init(billOfLading);
        }
    }
}
