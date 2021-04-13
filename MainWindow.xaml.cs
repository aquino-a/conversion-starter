using System.Windows;
using Conversion.ViewModel;

namespace Conversion
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainWindowViewModel _mainWindowViewModel;

        /// <summary>
        /// Initializes a new instance of the <see cref="MainWindow"/> class.
        /// </summary>
        /// <param name="mainWindowViewModel">the view model behind the view.</param>
        public MainWindow(MainWindowViewModel mainWindowViewModel)
        {
            this.DataContext = mainWindowViewModel;
            this.InitializeComponent();
            this._mainWindowViewModel = mainWindowViewModel;
        }
    }
}
