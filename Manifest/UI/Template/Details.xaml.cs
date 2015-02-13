using System;
using FirstFloor.ModernUI.Windows.Controls;
using Manifest.Shared;
using Manifest.Utils;

namespace Manifest.UI.Template
{
    /// <summary>
    /// Interaction logic for Details.xaml
    /// </summary>
    public partial class Details : ModernWindow
    {
        public Details()
        {
            InitializeComponent();
        }

        public void Init(Object instance, Filters filter)
        {
            uDetails.Init(instance, filter);
        }
    }
}
