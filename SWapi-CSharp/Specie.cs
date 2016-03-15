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
        private const string PathToEntity = "species/";

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the classification.
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
        /// Gets or sets the average height.
        /// </summary>
        /// <value>The average height.</value>
        [JsonProperty(PropertyName = "average_height")]
        public string AverageHeight { get; set; }

        /// <summary>
        /// Gets or sets the average lifespan.
        /// </summary>
        /// <value>The average lifespan.</value>
        [JsonProperty(PropertyName = "average_lifespan")]
        public string AverageLifespan { get; set; }

        /// <summary>
        /// Gets or sets the eye colors.
        /// </summary>
        /// <value>The eye colors.</value>
        [JsonProperty(PropertyName = "eye_colors")]
        public string EyeColors { get; set; }

        /// <summary>
        /// Gets or sets the hair colors.
        /// </summary>
        /// <value>The hair colors.</value>
        [JsonProperty(PropertyName = "hair_colors")]
        public string HairColors { get; set; }

        /// <summary>
        /// Gets or sets the skin colors.
        /// </summary>
        /// <value>The skin colors.</value>
        [JsonProperty(PropertyName = "skin_colors")]
        public string SkinColors { get; set; }

        /// <summary>
        /// Gets or sets the language.
        /// </summary>
        /// <value>The language.</value>
        [JsonProperty]
        public string Language { get; set; }

        /// <summary>
        /// Gets or sets the homeworld.
        /// </summary>
        /// <value>The homeworld.</value>
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
        protected override string Path
        {
            get
            {
                return PathToEntity;
            }
        }
    }
}
