using FirstFloor.ModernUI.Windows.Controls;
using Manifest.Shared;

namespace Manifest.UI.Details
{
    /// <summary>
    /// Interaction logic for ReationDetails.xaml
    /// </summary>
    public partial class ReationDetails : ModernWindow
    {
        public ReationDetails()
        {
            InitializeComponent();
        }

        public void Init(JRelation relation)
        {
            ucRelation.Init(relation);
        }
    }
}
