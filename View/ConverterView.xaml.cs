using Conversion.ViewModel;
using System.Windows;
using System.Windows.Controls;

namespace Conversion.View
{
    /// <summary>
    /// Interaction logic for ConverterView.xaml.
    /// </summary>
    public partial class ConverterView : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ConverterView"/> class.
        /// </summary>
        public ConverterView()
        {
            this.InitializeComponent();
        }

        private string OpenFileDialog()
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt|All Files (*.*)|*.*",
            };

            var result = (bool)fileDialog.ShowDialog();
            if (result)
            {
                return fileDialog.FileName;
            }
            else
            {
                return null;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            (this.DataContext as ConversionViewModel).FilePath = this.OpenFileDialog();
        }
    }
}
