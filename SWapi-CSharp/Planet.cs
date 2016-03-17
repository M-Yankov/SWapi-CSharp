// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-27-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="Planet.cs" company="M-Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Contains Planet model.</summary>
// ***********************************************************************
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
        /// <summary>
        /// The path that will be added to base API URL.
        /// </summary>
        private const string PathToEntity = "planets/";

        /// <summary>
        /// Gets the name. It can return "unknown" as value.
        /// </summary>
        /// <value>The name.</value>
        [JsonProperty]
        public string Name { get; internal set; }

        /// <summary>
        /// Gets the diameter. It can return "unknown" as value.
        /// </summary>
        /// <value>The diameter.</value>
        [JsonProperty]
        public string Diameter { get; internal set; }

        /// <summary>
        /// Gets the rotation period. It can return "unknown" as value.
        /// </summary>
        /// <value>The rotation period.</value>
        [JsonProperty(PropertyName = "rotation_period")]
        public string RotationPeriod { get; internal set; }

        /// <summary>
        /// Gets the orbital period. It can return "unknown" as value.
        /// </summary>
        /// <value>The orbital period.</value>
        [JsonProperty(PropertyName = "orbital_period")]
        public string OrbitalPeriod { get; internal set; }

        /// <summary>
        /// Gets the gravity. It can return "unknown" or "N/A" as value.
        /// </summary>
        /// <value>The gravity.</value>
        [JsonProperty]
        public string Gravity { get; internal set; }

        /// <summary>
        /// Gets the climate. Variables joined by comma and space. It can return "unknown" as value.
        /// </summary>
        /// <value>The climate.</value>
        [JsonProperty]
        public string Climate { get; internal set; }

        /// <summary>
        /// Gets the terrain. Variables joined by comma and space. It can return "unknown" as value.
        /// </summary>
        /// <value>The terrain.</value>
        [JsonProperty]
        public string Terrain { get; internal set; }

        /// <summary>
        /// Gets the surface water quantity. It can return "unknown" as value.
        /// </summary>
        /// <value>The surface water.</value>
        [JsonProperty(PropertyName = "surface_water")]
        public string SurfaceWater { get; internal set; }

        /// <summary>
        /// Gets the residents URLs.
        /// </summary>
        /// <value>The residents.</value>
        [JsonProperty]
        public ICollection<string> Residents { get; internal set; }

        /// <summary>
        /// Gets the films URLs.
        /// </summary>
        /// <value>The films.</value>
        [JsonProperty]
        public ICollection<string> Films { get; internal set; }

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
