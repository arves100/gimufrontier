namespace gimufrontier.Serializations
{
    /// <summary>
    /// Attribute to define which methods handles functionalities of action.php
    /// </summary>
    [AttributeUsage(AttributeTargets.Class)]
    public class HandlerAttribute : Attribute
    {
        /// <summary>
        /// Request ID
        /// </summary>
        public string Id { get; private set; }

        /// <summary>
        /// AES Key
        /// </summary>
        public string Key { get; private set; }

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="id">request id</param>
        /// <param name="key">AES Key</param>
        public HandlerAttribute(string id, string key)
        {
            Id = id;
            Key = key;
        }
    }
}
