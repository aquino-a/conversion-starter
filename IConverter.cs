using System.Collections.Generic;

namespace Conversion
{
    /// <summary>
    /// Interface used by the <c>ConverterViewModel</c> to convert the file.
    /// </summary>
    public interface IConverter
    {
        /// <summary>
        /// Convert a file.
        /// </summary>
        /// <param name="filePath">the path to the file to be converted.</param>
        /// <returns>a list of the converted and modified text lines.</returns>
        List<string> Convert(string filePath);

        /// <summary>
        /// Convert a file with arguments.
        /// </summary>
        /// <param name="filePath">the path to the file to be converted.</param>
        /// <param name="arguments">the arguments to be used when converting.</param>
        /// <returns>a list of the converted and modified text lines.</returns>
        List<string> Convert(string filePath, string arguments);
    }
}