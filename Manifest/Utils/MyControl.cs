using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Navigation;
using Warehouse.Exceptions;

namespace Manifest.Utils
{
    public class MyControl : System.Windows.Controls.UserControl, IContent
    {
        public void ShowError(UserInterfaceException ex)
        {
            MessageBox.Show(ex.Message, "نقص اطلاعات", MessageBoxButton.OK, MessageBoxImage.Error,
                    MessageBoxResult.OK, MessageBoxOptions.RightAlign | MessageBoxOptions.RtlReading);
        }

        public virtual void OnFragmentNavigation(FragmentNavigationEventArgs e)
        {
            // Do Nothing !
        }

        public virtual void OnNavigatedFrom(NavigationEventArgs e)
        {
            // Do Nothing !
        }

        public virtual void OnNavigatedTo(NavigationEventArgs e)
        {
            // Do Nothing !
        }

        public virtual void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            // Do Nothing !
        }
    }
}
