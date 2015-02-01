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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Manifest.Shared;

namespace Manifest.UserControl
{
    /// <summary>
    /// Interaction logic for uConsignment.xaml
    /// </summary>
    public partial class uConsignment : System.Windows.Controls.UserControl
    {
        private Consignment _consignment;

        public uConsignment()
        {
            InitializeComponent();
        }

        public void Init(Consignment consignment)
        {
            this._consignment = consignment;
            Panel panel = Utils.ControlCreator<Consignment>.GetInstance().CreateControl(consignment);
            this.Content = null;
            this.AddChild(panel);
        }
    }
}
