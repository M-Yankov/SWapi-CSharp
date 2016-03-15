namespace StarWarsApiCSharp
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    internal class Helper<T> where T : BaseEntity
    {
        [JsonProperty]
        public ICollection<T> Results { get; set; }

        [JsonProperty]
        public int Count { get; set; }

        [JsonProperty]
        public string Next { get; set; }

        [JsonProperty]
        public string Previous { get; set; }
    }
}
