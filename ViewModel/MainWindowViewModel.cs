﻿using System.Collections.ObjectModel;
using Parsing.Model;

namespace Parsing.ViewModel
{
    /// <summary>
    /// The view model for the main window of the application.
    /// </summary>
    public sealed class MainWindowViewModel : ViewModelBase
    {
        /// <summary>
        /// Gets or sets the tabs in the application.
        /// </summary>
        public ObservableCollection<TabItem> Tabs { get; set; } = new ObservableCollection<TabItem>();
    }
}