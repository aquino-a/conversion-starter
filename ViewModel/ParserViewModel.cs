using System;
using System.IO;
using System.Windows;
using System.Windows.Input;
using Parsing.Service;

namespace Parsing.ViewModel
{
    /// <summary>
    /// View model for parsing.
    /// </summary>
    public class ParserViewModel : ViewModelBase
    {
        private readonly IParseService _parseService;
        private string _filePath;
        private string _textResult;

        /// <summary>
        /// Initializes a new instance of the <see cref="ParserViewModel"/> class.
        /// Constructs a view model for receiving parse commands and getting a file path.
        /// </summary>
        /// <param name="parseService">will be used to parse the file.</param>
        public ParserViewModel(IParseService parseService)
        {
            this._parseService = parseService;
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
            get => this._filePath; set
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
            get => this._textResult; set
            {
                this._textResult = value;
                this.OnPropertyChanged("TextResult");
            }
        }

        /// <summary>
        /// Gets or sets the parse command.
        /// Parses the current file.
        /// </summary>
        public ICommand Parse { get; set; }

        /// <summary>
        /// Gets or sets the copy command.
        /// Copies the text to the clipboard.
        /// </summary>
        public ICommand Copy { get; set; }

        private void SetupCommands()
        {
            this.Parse = new RelayCommand(this.ParseFile, this.CanParse);
            this.Copy = new RelayCommand(o => Clipboard.SetText(this.TextResult), o => !string.IsNullOrWhiteSpace(this.TextResult));
        }

        private void ParseFile(object obj)
        {
            var parsed = this._parseService.Parse(this.FilePath);
            this.TextResult = string.Join(Environment.NewLine, parsed);
        }

        private bool CanParse(object obj)
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
