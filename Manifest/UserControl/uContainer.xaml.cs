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
using Manifest.Utils;

namespace Manifest.UserControl
{
    /// <summary>
    /// Interaction logic for uContainer.xaml
    /// </summary>
    public partial class uContainer : System.Windows.Controls.UserControl
    {
        public Container Container { get; set; }

        public uContainer()
        {
            InitializeComponent();
            Container = new Container();
        }

        public void Init(Container container)
        {
            this.Container = container;
            Panel panel = Utils.ControlCreator<Container>.GetInstance().CreateControl(container, Filters.AllFields);
            this.AddChild(panel);
        }
    }
}
