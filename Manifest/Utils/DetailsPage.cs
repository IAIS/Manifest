using System;
using System.Windows;
using System.Windows.Controls;
using FirstFloor.ModernUI.Windows;
using FirstFloor.ModernUI.Windows.Controls;
using FirstFloor.ModernUI.Windows.Navigation;
using Warehouse.Exceptions;

namespace Manifest.Utils
{
    public class DetailsPage : System.Windows.Controls.UserControl, IContent
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

        public virtual void IsLoading()
        {
            ((ModernFrame)this.Parent).IsLoadingContent = true;
            ((Panel)((ModernFrame)this.Parent).Parent).IsEnabled = false;
        }

        public virtual void IsLoaded()
        {
            ((ModernFrame)this.Parent).IsLoadingContent = false;
            ((Panel) ((ModernFrame) this.Parent).Parent).IsEnabled = true;
        }
    }
}
