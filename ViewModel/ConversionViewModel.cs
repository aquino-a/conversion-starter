using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Conversion;

namespace Conversion.ViewModel
{
    /// <summary>
    /// View model for converting.
    /// </summary>
    public class ConversionViewModel : ViewModelBase
    {
        private readonly IConverter _converter;
        private string _filePath;
        private string _textResult;
        private string _arguments;
        private bool _showArguments;

        /// <summary>
        /// Initializes a new instance of the <see cref="ConversionViewModel"/> class.
        /// Constructs a view model for receiving convert commands and getting a file path.
        /// </summary>
        /// <param name="converter">will be used to convert the file.</param>
        public ConversionViewModel(IConverter converter)
        {
            this._converter = converter;
            this.SetupCommands();
        }

        /// <summary>
        /// Gets or sets the label text to show next to the current file path.
        /// </summary>
        public string FileLabel { get; set; } = "Default Label";

        /// <summary>
        /// Gets or sets the file path.
        /// </summary>
        public string FilePath
        {
            get => this._filePath;
            set
            {
                this._filePath = value;
                this.OnPropertyChanged("FilePath");
            }
        }

        /// <summary>
        /// Gets or sets the text shown in the view.
        /// </summary>
        public string TextResult
        {
            get => this._textResult;
            set
            {
                this._textResult = value;
                this.OnPropertyChanged("TextResult");
            }
        }

        /// <summary>
        /// Gets or sets a value indicating whether the arguments are shown in the view.
        /// </summary>
        public bool ShowArguments
        {
            get => this._showArguments;
            set
            {
                this._showArguments = value;
                this.OnPropertyChanged("ShowArguments");
            }
        }

        /// <summary>
        /// Gets or sets the arguments shown in the view.
        /// </summary>
        public string Arguments
        {
            get => this._arguments;
            set
            {
                this._arguments = value;
                this.OnPropertyChanged("Arguments");
            }
        }

        /// <summary>
        /// Gets or sets the convert command.
        /// Converts the current file.
        /// </summary>
        public ICommand Convert { get; set; }

        /// <summary>
        /// Gets or sets the copy command.
        /// Copies the text to the clipboard.
        /// </summary>
        public ICommand Copy { get; set; }

        private void SetupCommands()
        {
            this.Convert = new RelayCommand(this.ConvertFile, this.CanCovert);
            this.Copy = new RelayCommand(o => Clipboard.SetText(this.TextResult), o => !string.IsNullOrWhiteSpace(this.TextResult));
        }

        private void ConvertFile(object obj)
        {
            var converted = string.IsNullOrWhiteSpace(this.Arguments)
                ? this._converter.Convert(this.FilePath)
                : this._converter.Convert(this.FilePath, this.Arguments);
            this.TextResult = string.Join(Environment.NewLine, converted);
        }

        private bool CanCovert(object obj)
        {
            var hasFileName = !string.IsNullOrWhiteSpace(this.FilePath);
            if (!hasFileName)
            {
                return false;
            }

            return File.Exists(this.FilePath);
        }
    }
}
