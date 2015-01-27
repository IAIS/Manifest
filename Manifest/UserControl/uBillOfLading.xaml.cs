using System;
using System.Reflection;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using Manifest.Shared;

namespace Manifest.UserControl
{
    /// <summary>
    /// Interaction logic for uBillOfLading.xaml
    /// </summary>
    public partial class uBillOfLading : System.Windows.Controls.UserControl
    {
        private BillOfLading BillOfLading { get; set; }

        public uBillOfLading()
        {
            BillOfLading = new BillOfLading();
            InitializeComponent();
        }

        public void Init(BillOfLading billOfLading)
        {
            this.BillOfLading = billOfLading;
            CreateControls();
        }

        private void CreateControls()
        {
            Panel panel = Utils.ControlCreator<BillOfLading>.CreateControl(BillOfLading);
            this.AddChild(panel);
        }
    }
}

