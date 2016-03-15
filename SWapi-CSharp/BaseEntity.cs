namespace StarWarsApiCSharp
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Base entity class contains common data.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// URL from where was downloaded the entity.
        /// </summary>
        [JsonProperty]
        public string Url { get; set; }

        /// <summary>
        /// Date of creation of the entity.
        /// </summary>
        [JsonProperty]
        public DateTime Created { get; set; }

        /// <summary>
        /// Date of last modification.
        /// </summary>
        [JsonProperty]
        public DateTime Edited { get; set; }
        
        /// <summary>
        /// Gets the path.
        /// </summary>
        protected abstract string Path { get; }

        /// <summary>
        /// Gets the path for extending base URL API.
        /// </summary>
        /// <returns>System.String.</returns>
        public string GetPath()
        {
            return this.Path;
        }
    }
}
