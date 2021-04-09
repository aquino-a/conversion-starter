using System.Collections.Generic;

namespace Parsing.Service
{
    /// <summary>
    /// Interface used by the <c>ParserViewModel</c> to parse the file.
    /// </summary>
    public interface IParseService
    {
        /// <summary>
        /// Parse a file.
        /// </summary>
        /// <param name="filePath">the path to the file to be parsed.</param>
        /// <returns>a list of the parsed and modified text lines.</returns>
        List<string> Parse(string filePath);
    }
}