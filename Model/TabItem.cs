namespace Conversion.Model
{
    /// <summary>
    /// A Tab to be displayed in the application.
    /// </summary>
    public sealed class TabItem
    {
        /// <summary>
        /// Gets or sets the header at the top of the tab.
        /// </summary>
        public string Header { get; set; }

        /// <summary>
        /// Gets or sets the content of the tab.
        /// </summary>
        public object Content { get; set; }
    }
}
