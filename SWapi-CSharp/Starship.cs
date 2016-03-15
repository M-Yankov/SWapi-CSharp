namespace StarWarsApiCSharp
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Class Starship. Some of properties can have unknown as a value.
    /// </summary>
    /// <seealso cref="StarWarsApiCSharp.BaseEntity" />
    public class Starship : BaseEntity 
    {
        private const string PathToEntity = "starships/";

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the model.
        /// </summary>
        /// <value>The model.</value>
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the starship class.
        /// </summary>
        /// <value>The starship class.</value>
        [JsonProperty(PropertyName = "starship_class")]
        public string StarshipClass { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        public string Manufacturer { get; set; }

        /// <summary>
        /// Some times return unknown.
        /// </summary>
        [JsonProperty(PropertyName = "cost_in_credits")]
        public string CostInCredits { get; set; }

        /// <summary>
        /// Gets or sets the length.
        /// </summary>
        /// <value>The length.</value>
        [JsonProperty]
        public string Length { get; set; }

        /// <summary>
        /// Gets or sets the Crew. Some times return unknown.
        /// </summary>
        [JsonProperty]
        public string Crew { get; set; }

        /// <summary>
        /// Gets or sets the passengers. Some times return unknown.
        /// </summary>
        [JsonProperty]
        public string Passengers { get; set; }

        /// <summary>
        /// Gets or sets the mega hyper drive max atmospheric speed. Sometimes returns N/A
        /// </summary>
        [JsonProperty(PropertyName = "max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        /// <summary>
        /// Gets or sets the mega hyper drive rating. Some times return unknown.
        /// </summary>
        [JsonProperty(PropertyName = "hyperdrive_rating")]
        public string HyperdriveRating { get; set; }

        /// <summary>
        /// Gets or sets the mega lights.
        /// </summary>
        /// <value>The mega lights.</value>
        [JsonProperty(PropertyName = "MGLT")]
        public string MegaLights { get; set; }

        /// <summary>
        /// Gets or sets the cargo capacity.
        /// </summary>
        /// <value>The cargo capacity.</value>
        [JsonProperty(PropertyName = "cargo_capacity")]
        public string CargoCapacity { get; set; }

        /// <summary>
        /// Gets or sets the consumables.
        /// </summary>
        /// <value>The consumables.</value>
        [JsonProperty]
        public string Consumables { get; set; }

        /// <summary>
        /// Gets or sets the films URLs.
        /// </summary>
        /// <value>The films.</value>
        [JsonProperty]
        public ICollection<string> Films { get; set; }

        /// <summary>
        /// Gets or sets the pilots URLs.
        /// </summary>
        /// <value>The pilots.</value>
        [JsonProperty]
        public ICollection<string> Pilots { get; set; }

        /// <summary>
        /// Gets the path for extending base URL API.
        /// </summary>
        /// <value>The path.</value>
        protected override string Path
        {
            get
            {
                return PathToEntity;
            }
        }
    }
}
