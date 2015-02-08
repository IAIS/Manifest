﻿using System;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Web.Script.Serialization;
using System.Windows;
using System.Windows.Input;
using Manifest.Shared;
using Manifest.Utils;
using Microsoft.Win32;

namespace Manifest.UI.Steps.Hoopad
{
    /// <summary>
    /// Interaction logic for Main.xaml
    /// </summary>
    public partial class Main : MyControl
    {
        public Main()
        {
            InitializeComponent();
        }

        private void NewCommand_OnExecuted(object sender, ExecutedRoutedEventArgs e)
        {
            ParameterUtility.SetVoyage(new Voyage());
            Wrapper window = (Wrapper) Window.GetWindow(this);
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
