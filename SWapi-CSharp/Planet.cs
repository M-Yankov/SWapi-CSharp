namespace StarWarsApiCSharp
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Class Planet.
    /// </summary>
    /// <seealso cref="StarWarsApiCSharp.BaseEntity" />
    public class Planet : BaseEntity
    {
        private const string PathToEntity = "planets/";

        /// <summary>
        /// Gets or sets the name.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the diameter.
        /// </summary>
        /// <value>The diameter.</value>
        [JsonProperty]
        public string Diameter { get; set; }

        /// <summary>
        /// Gets or sets the rotation period.
        /// </summary>
        /// <value>The rotation period.</value>
        [JsonProperty(PropertyName = "rotation_period")]
        public string RotationPeriod { get; set; }

        /// <summary>
        /// Gets or sets the orbital period.
        /// </summary>
        /// <value>The orbital period.</value>
        [JsonProperty(PropertyName = "orbital_period")]
        public string OrbitalPeriod { get; set; }

        /// <summary>
        /// Gets or sets the gravity.
        /// </summary>
        /// <value>The gravity.</value>
        [JsonProperty]
        public string Gravity { get; set; }

        /// <summary>
        /// Gets or sets the climate.
        /// </summary>
        /// <value>The climate.</value>
        [JsonProperty]
        public string Climate { get; set; }

        /// <summary>
        /// Gets or sets the terrain. Joined by comma and space.
        /// </summary>
        /// <value>The terrain.</value>
        [JsonProperty]
        public string Terrain { get; set; }

        /// <summary>
        /// Gets or sets the surface water.
        /// </summary>
        /// <value>The surface water.</value>
        [JsonProperty(PropertyName = "surface_water")]
        public string SurfaceWater { get; set; }

        /// <summary>
        /// Gets or sets the residents URLs.
        /// </summary>
        /// <value>The residents.</value>
        [JsonProperty]
        public ICollection<string> Residents { get; set; }

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
