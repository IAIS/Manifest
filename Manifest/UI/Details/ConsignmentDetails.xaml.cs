﻿using System;
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
using FirstFloor.ModernUI.Windows.Controls;
using Manifest.Shared;

namespace Manifest.UI.Details
{
    /// <summary>
    /// Interaction logic for ConsignmentDetails.xaml
    /// </summary>
    public partial class ConsignmentDetails : ModernWindow
    {
        public ConsignmentDetails()
        {
            InitializeComponent();
        }

        public void Init(Consignment consignment)
        {
            this.ucConsignment.Init(consignment);
        }
    }
}
