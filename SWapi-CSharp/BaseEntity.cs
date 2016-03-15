namespace StarWarsApiCSharp
{
    using System;
    using Newtonsoft.Json;

    public abstract class BaseEntity
    {
        [JsonProperty]
        public string Url { get; set; }

        [JsonProperty]
        public DateTime Created { get; set; }

        [JsonProperty]
        public DateTime Edited { get; set; }

        protected abstract string Path { get; }

        public string GetPath()
        {
            return this.Path;
        }
    }
}
