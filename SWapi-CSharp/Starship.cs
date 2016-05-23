// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-06-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="Starship.cs" company="M-Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Contains Starship model.</summary>
// ***********************************************************************
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
        /// <summary>
        /// The path that will be added to base API URL.
        /// </summary>
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
        /// Gets or sets the cost in credits. It can return "unknown" as value.
        /// </summary>
        /// <value>The cost in credits.</value>
        [JsonProperty(PropertyName = "cost_in_credits")]
        public string CostInCredits { get; set; }

        /// <summary>
        /// Gets or sets the length. It can return "unknown" as value.
        /// </summary>
        /// <value>The length.</value>
        [JsonProperty]
        public string Length { get; set; }

        /// <summary>
        /// Gets or sets the Crew count as string. It can return "unknown" as value.
        /// </summary>
        /// <value>The crew.</value>
        [JsonProperty]
        public string Crew { get; set; }

        /// <summary>
        /// Gets or sets the passengers count as string. It can return "unknown" as value.
        /// </summary>
        /// <value>The passengers.</value>
        [JsonProperty]
        public string Passengers { get; set; }

        /// <summary>
        /// Gets or sets the max atmospheric speed. It can return "N/A" as value.
        /// </summary>
        /// <value>The maximum atmospheric speed.</value>
        [JsonProperty(PropertyName = "max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        /// <summary>
        /// Gets or sets the hyper drive rating. It can return "unknown" as value.
        /// </summary>
        /// <value>The hyper drive rating.</value>
        [JsonProperty(PropertyName = "hyperdrive_rating")]
        public string HyperdriveRating { get; set; }

        /// <summary>
        /// Gets or sets the mega lights. It can return "unknown" as value.
        /// </summary>
        /// <value>The mega lights.</value>
        [JsonProperty(PropertyName = "MGLT")]
        public string MegaLights { get; set; }

        /// <summary>
        /// Gets or sets the cargo capacity. It can return "unknown" as value.
        /// </summary>
        /// <value>The cargo capacity.</value>
        [JsonProperty(PropertyName = "cargo_capacity")]
        public string CargoCapacity { get; set; }

        /// <summary>
        /// Gets or sets the consumables period. It can return "unknown" as value.
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
        protected override string EntryPath
        {
            get
            {
                return PathToEntity;
            }
        }
    }
}
