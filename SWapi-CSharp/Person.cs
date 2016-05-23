// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-27-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="Person.cs" company="M-Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Contains Person model.</summary>
// ***********************************************************************
namespace StarWarsApiCSharp
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Class Person.
    /// </summary>
    /// <seealso cref="StarWarsApiCSharp.BaseEntity" />
    public class Person : BaseEntity
    {
        /// <summary>
        /// The path that will be added to base API URL.
        /// </summary>
        private const string PathToEntity = "people/";

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the birth year. It can return "unknown" as value.
        /// </summary>
        /// <value>The birth year.</value>
        [JsonProperty(PropertyName = "birth_year")]
        public string BirthYear { get; set; }

        /// <summary>
        /// Gets or sets the color of the eye. It can return "unknown" as value.
        /// </summary>
        /// <value>The color of the eye.</value>
        [JsonProperty(PropertyName = "eye_color")]
        public string EyeColor { get; set; }

        /// <summary>
        /// Gets or sets the gender. It can return "n/a" as value
        /// </summary>
        /// <value>The gender.</value>
        [JsonProperty]
        public string Gender { get; set; }

        /// <summary>
        /// Gets or sets the color of the hair. It can return "unknown" as value.
        /// </summary>
        /// <value>The color of the hair.</value>
        [JsonProperty(PropertyName = "hair_color")]
        public string HairColor { get; set; }

        /// <summary>
        /// Gets or sets the height. It can return "unknown" as value.
        /// </summary>
        /// <value>The height.</value>
        [JsonProperty]
        public string Height { get; set; }

        /// <summary>
        /// Gets or sets the mass. It can return "unknown" as value.
        /// </summary>
        /// <value>The mass.</value>
        [JsonProperty]
        public string Mass { get; set; }

        /// <summary>
        /// Gets or sets the color of the skin. It can return "unknown" as value.
        /// </summary>
        /// <value>The color of the skin.</value>
        [JsonProperty(PropertyName = "skin_color")]
        public string SkinColor { get; set; }

        /// <summary>
        /// Gets or sets the home world.
        /// </summary>
        /// <value>The home world.</value>
        [JsonProperty]
        public string Homeworld { get; set; }

        /// <summary>
        /// Gets or sets the films URLs.
        /// </summary>
        /// <value>The films.</value>
        [JsonProperty]
        public ICollection<string> Films { get; set; }

        /// <summary>
        /// Gets or sets the species URLs.
        /// </summary>
        /// <value>The species.</value>
        [JsonProperty]
        public ICollection<string> Species { get; set; }

        /// <summary>
        /// Gets or sets the star ships URLs.
        /// </summary>
        /// <value>The star ships.</value>
        [JsonProperty]
        public ICollection<string> Starships { get; set; }

        /// <summary>
        /// Gets or sets the vehicles URLs.
        /// </summary>
        /// <value>The vehicles.</value>
        [JsonProperty]
        public ICollection<string> Vehicles { get; set; }

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
