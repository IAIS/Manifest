using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media.Imaging;
using FirstFloor.ModernUI.Presentation;
using FirstFloor.ModernUI.Windows.Controls;
using Manifest.Shared;
using Manifest.Utils;
using Microsoft.Win32;

namespace Manifest.UI.Template
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : DetailsPage
    {
        public Main()
        {
            InitializeComponent();
            if (Utils.ConfiguraionManager.GetInstance().GetApplicaionType() == ApplicaionType.Hoopad)
            {
                ModernTab modernTab = new ModernTab()
                {
                    Layout = TabLayout.List,
                    FlowDirection = FlowDirection.RightToLeft,
                    SelectedSource = new Uri(@"/Manifest;component/UI\Steps\Hoopad\Intro.xaml", UriKind.Relative)
                };
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "توضیحات اولیه",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/lightbulb.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Hoopad\Intro.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "بارگذاری فایل",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/upload_page.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Hoopad\UploadFile.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "اطلاعات بارنامه",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/world.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Hoopad\UploadBL.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "اطلاعات کانتینر",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/truck.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Hoopad\UploadContainer.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "اطلاعات کالا",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/tag.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Hoopad\UploadConsignment.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "تایید و ثبت نهایی",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/check_mark.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Hoopad\Confirmation.xaml", UriKind.Relative)
                });
                this.AddChild(modernTab);
            }
            if (Utils.ConfiguraionManager.GetInstance().GetApplicaionType() == ApplicaionType.Lotka)
            {
                ModernTab modernTab = new ModernTab()
                {
                    Layout = TabLayout.List,
                    FlowDirection = FlowDirection.RightToLeft,
                    SelectedSource = new Uri(@"/Manifest;component/UI\Steps\Lotka\Intro.xaml", UriKind.Relative)
                };
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "توضیحات اولیه",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/lightbulb.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Lotka\Intro.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "اطلاعات مانیفست",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/support.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Lotka\UploadVoyage.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "اطلاعات بارنامه",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/world.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Lotka\UploadBL.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "تعیین ارتباطات",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/link.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Lotka\UploadRelation.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "اطلاعات کانتینر",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/truck.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Lotka\UploadContainer.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "اطلاعات کالا",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/tag.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Lotka\UploadConsignment.xaml", UriKind.Relative)
                });
                modernTab.Links.Add(new Link()
                {
                    DisplayName = "تایید و ثبت نهایی",
                    ImageSource = new BitmapImage(new Uri(@"/Manifest;component/Assets/check_mark.png", UriKind.Relative)),
                    Source = new Uri(@"/Manifest;component/UI\Steps\Lotka\Confirmation.xaml", UriKind.Relative)
                });
                this.AddChild(modernTab);
            }
        }

        private void NewCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ParameterUtility.SetVoyage(new Voyage());
            Wrapper window = (Wrapper)Window.GetWindow(this);
            Wrapper newWindows = new Wrapper();
            newWindows.Show();
            window.Close();


        }

        private void NewCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void OpenCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Multiselect = false;
            dialog.Filter = "Manifest files (*.man)|*.man|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                IsLoading();
                BackgroundWorker openWorker = new BackgroundWorker();
                openWorker.DoWork += WorkerDoOpen;
                openWorker.RunWorkerCompleted += WorkerOpenCompleted;
                openWorker.RunWorkerAsync(dialog.FileName);
            }
        }

        private void WorkerOpenCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsLoaded();
        }

        private void WorkerDoOpen(object sender, DoWorkEventArgs e)
        {
            String path = e.Argument as String;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            String hexContent = File.ReadAllText(path);
            String plainContent = Utils.CommonUtility.HexStringToString(hexContent, Encoding.UTF8);
            Voyage voyage = serializer.Deserialize<Voyage>(plainContent);
            ParameterUtility.SetVoyage(voyage);
        }

        private void OpenCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void SaveAsCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "Manifest files (*.man)|*.man|All files (*.*)|*.*";
            if (dialog.ShowDialog() == true)
            {
                IsLoading();
                BackgroundWorker saveAsWorker = new BackgroundWorker();
                saveAsWorker.DoWork += SaveAsWorkerOnDoWork;
                saveAsWorker.RunWorkerCompleted += SaveAsWorkerOnRunWorkerCompleted;
                saveAsWorker.RunWorkerAsync(dialog.FileName);
            }
        }

        private void SaveAsWorkerOnRunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            IsLoaded();
        }

        private void SaveAsWorkerOnDoWork(object sender, DoWorkEventArgs e)
        {
            String path = e.Argument as String;
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            serializer.MaxJsonLength = Int32.MaxValue;
            String plainContent = serializer.Serialize(ParameterUtility.GetVoyage());
            String hexContent = Utils.CommonUtility.StringToHexString(plainContent, Encoding.UTF8);
            File.WriteAllText(path, hexContent);
        }

        private void SaveCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }

        private void PropertiesCommand_Executed(object sender, ExecutedRoutedEventArgs e)
        {

        }

        private void ProperitesCommand_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = true;
        }
    }
}
