using FirstFloor.ModernUI.Windows.Controls;
using Manifest.Shared;

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
