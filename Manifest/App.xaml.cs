﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Windows;
using Manifest.Shared;

namespace Manifest
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public List<BillOfLading> BillOfLadings { get; set; } 
    }
}
