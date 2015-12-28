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

namespace Manifest.UI.Details
{
    /// <summary>
    /// Interaction logic for ContainerDetails.xaml
    /// </summary>
    public partial class ContainerDetails : ModernWindow
    {
        public ContainerDetails()
        {
            InitializeComponent();
        }

        public void Init(Container container)
        {
            ucContainer.Init(container);
        }
    }
}
