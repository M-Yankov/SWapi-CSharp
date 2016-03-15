namespace StarWarsApiCSharp
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Class Vehicle.
    /// </summary>
    /// <seealso cref="StarWarsApiCSharp.BaseEntity" />
    public class Vehicle : BaseEntity
    {
        private const string PathToEntity = "vehicles/";

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
        [JsonProperty]
        public string Model { get; set; }

        /// <summary>
        /// Gets or sets the vehicle class.
        /// </summary>
        /// <value>The vehicle class.</value>
        [JsonProperty(PropertyName = "vehicle_class")]
        public string VehicleClass { get; set; }

        /// <summary>
        /// Gets or sets the manufacturer.
        /// </summary>
        /// <value>The manufacturer.</value>
        [JsonProperty]
        public string Manufacturer { get; set; }

        [JsonProperty]
        public string Length { get; set; }

        /// <summary>
        /// Gets or sets the cost in credits.
        /// </summary>
        /// <value>The cost in credits.</value>
        [JsonProperty(PropertyName = "cost_in_credits")]
        public string CostInCredits { get; set; }

        /// <summary>
        /// Gets or sets the crew.
        /// </summary>
        /// <value>The crew.</value>
        [JsonProperty]
        public string Crew { get; set; }

        /// <summary>
        /// Gets or sets the passengers.
        /// </summary>
        /// <value>The passengers.</value>
        [JsonProperty]
        public string Passengers { get; set; }

        /// <summary>
        /// Gets or sets the maximum atmosphering speed.
        /// </summary>
        /// <value>The maximum atmosphering speed.</value>
        [JsonProperty(PropertyName = "max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

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
