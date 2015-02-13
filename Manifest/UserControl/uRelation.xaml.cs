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
    /// Interaction logic for uRelation.xaml
    /// </summary>
    public partial class uRelation : System.Windows.Controls.UserControl
    {
        public uRelation()
        {
            InitializeComponent();
        }

        public void Init(JRelation relation)
        {
            Panel panel = Utils.ControlCreator<JRelation>.GetInstance().CreateControl(relation, Filters.AllFields);
            this.AddChild(panel);
        }
    }
}
