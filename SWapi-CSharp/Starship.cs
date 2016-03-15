namespace StarWarsApiCSharp
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Starship : BaseEntity 
    {
        private const string PathToEntity = "starships/";

        [JsonProperty]
        public string Name { get; set; }

        public string Model { get; set; }

        [JsonProperty(PropertyName = "starship_class")]
        public string StarshipClass { get; set; }

        public string Manufacturer { get; set; }

        /// <summary>
        /// Some times return unknown.
        /// </summary>
        [JsonProperty(PropertyName = "cost_in_credits")]
        public string CostInCredits { get; set; }

        [JsonProperty]
        public string Length { get; set; }

        /// <summary>
        /// Some times return unknown.
        /// </summary>
        [JsonProperty]
        public string Crew { get; set; }

        /// <summary>
        /// Some times return unknown.
        /// </summary>
        [JsonProperty]
        public string Passengers { get; set; }

        /// <summary>
        /// Sometimes returns N/A
        /// </summary>
        [JsonProperty(PropertyName = "max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        /// <summary>
        /// Some times return unknown.
        /// </summary>
        [JsonProperty(PropertyName = "hyperdrive_rating")]
        public string HyperdriveRating { get; set; }

        [JsonProperty(PropertyName = "MGLT")]
        public string MegaLights { get; set; }

        [JsonProperty(PropertyName = "cargo_capacity")]
        public string CargoCapacity { get; set; }

        [JsonProperty]
        public string Consumables { get; set; }

        [JsonProperty]
        public ICollection<string> Films { get; set; }

        [JsonProperty]
        public ICollection<string> Pilots { get; set; }

        protected override string Path
        {
            get
            {
                return PathToEntity;
            }
        }
    }
}
