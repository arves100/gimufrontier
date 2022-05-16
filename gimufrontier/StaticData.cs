using gimufrontier.Models;
using gimufrontier.Serializations;
using System.Reflection;
using System.Text.Json;

namespace gimufrontier
{
    /// <summary>
    /// Holds static configuration/data of the application that should be immutable
    /// </summary>
    public class StaticData
    {
        /// <summary>
        /// Cached default JSON options
        /// </summary>
        public static readonly JsonSerializerOptions DefaultOptions = new()
        {
            IncludeFields = false,
        };

    }
}
