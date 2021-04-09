using System.Windows;
using System.Windows.Controls;
using Parsing.ViewModel;

namespace Parsing.View
{
    /// <summary>
    /// Interaction logic for Parser.xaml.
    /// </summary>
    public partial class Parser : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Parser"/> class.
        /// </summary>
        public Parser()
        {
            this.InitializeComponent();
        }

        private string OpenFileDialog()
        {
            var fileDialog = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".csv",
                Filter = "CSV Files (*.csv)|*.csv|Text Files (*.txt)|*.txt",
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
            (this.DataContext as ParserViewModel).FilePath = this.OpenFileDialog();
        }
    }
}
