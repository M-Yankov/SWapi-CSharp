// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-27-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="Specie.cs" company="M-Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Contains Specie model.</summary>
// ***********************************************************************
namespace StarWarsApiCSharp
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Class Specie.
    /// </summary>
    /// <seealso cref="StarWarsApiCSharp.BaseEntity" />
    public class Specie : BaseEntity
    {
        /// <summary>
        /// The path that will be added to base API URL.
        /// </summary>
        private const string PathToEntity = "species/";

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the classification. It can return "unknown" as value.
        /// </summary>
        /// <value>The classification.</value>
        [JsonProperty]
        public string Classification { get; set; }

        /// <summary>
        /// Gets or sets the designation.
        /// </summary>
        /// <value>The designation.</value>
        [JsonProperty]
        public string Designation { get; set; }

        /// <summary>
        /// Gets or sets the average height. It can return "unknown" as value.
        /// </summary>
        /// <value>The average height.</value>
        [JsonProperty(PropertyName = "average_height")]
        public string AverageHeight { get; set; }

        /// <summary>
        /// Gets or sets the average lifespan. It can return "unknown" as value.
        /// </summary>
        /// <value>The average lifespan.</value>
        [JsonProperty(PropertyName = "average_lifespan")]
        public string AverageLifespan { get; set; }

        /// <summary>
        /// Gets or sets the eye colors. Variables joined by comma and space. It can return "unknown" as value.
        /// </summary>
        /// <value>The eye colors.</value>
        [JsonProperty(PropertyName = "eye_colors")]
        public string EyeColors { get; set; }

        /// <summary>
        /// Gets or sets the hair colors. Variables joined by comma and space. It can return "unknown" as value.
        /// </summary>
        /// <value>The hair colors.</value>
        [JsonProperty(PropertyName = "hair_colors")]
        public string HairColors { get; set; }

        /// <summary>
        /// Gets or sets the skin colors. Variables joined by comma and space.
        /// </summary>
        /// <value>The skin colors.</value>
        [JsonProperty(PropertyName = "skin_colors")]
        public string SkinColors { get; set; }

        /// <summary>
        /// Gets or sets the language. It can return "unknown" as value.
        /// </summary>
        /// <value>The language.</value>
        [JsonProperty]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the home world.
        /// </summary>
        /// <value>The home world.</value>
        [JsonProperty]
        public string Homeworld { get; set; }

        /// <summary>
        /// Gets or sets the people URLs.
        /// </summary>
        /// <value>The people.</value>
        [JsonProperty]
        public ICollection<string> People { get; set; }

        /// <summary>
        /// Gets or sets the films URLs.
        /// </summary>
        /// <value>The films.</value>
        [JsonProperty]
        public ICollection<string> Films { get; set; }

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
