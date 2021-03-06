﻿using System.Windows.Controls;
using Manifest.Shared;
using Manifest.Utils;

namespace Manifest.UserControl
{
    /// <summary>
    /// Interaction logic for uVoyage.xaml
    /// </summary>
    public partial class uVoyage : System.Windows.Controls.UserControl
    {
        private Voyage Voyage { get; set; }

        public uVoyage()
        {
            InitializeComponent();
            Voyage = new Voyage();
        }

        public void Init(Voyage voyage)
        {
            this.Voyage = voyage;
            Panel panel = Utils.ControlCreator<Voyage>.GetInstance().CreateControl(voyage, Filters.AllFields);
            this.Content = null;
            this.AddChild(panel);       
        }
    }
}
