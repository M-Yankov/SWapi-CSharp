namespace StarWarsApiCSharp
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Film : BaseEntity
    {
        private const string PathToEntity = "films/";

        [JsonProperty]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "episode_id")]
        public string EpisodeId { get; set; }

        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; set; }

        [JsonProperty]
        public string Director { get; set; }

        [JsonProperty]
        public string Producer { get; set; }

        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; set; }

        [JsonProperty]
        public ICollection<string> Species { get; set; }

        [JsonProperty]
        public ICollection<string> Starships { get; set; }

        [JsonProperty]
        public ICollection<string> Vehicles { get; set; }

        [JsonProperty]
        public ICollection<string> Characters { get; set; }

        [JsonProperty]
        public ICollection<string> Planets { get; set; }
        
        protected override string Path
        {
            get
            {
                return PathToEntity;
            }
        }
    }
}
