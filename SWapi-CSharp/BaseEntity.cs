// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-06-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="BaseEntity.cs" company="M-Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Base entity class contains common data.</summary>
// ***********************************************************************
namespace StarWarsApiCSharp
{
    using System;
    using Newtonsoft.Json;

    /// <summary>
    /// Base entity class contains common data.
    /// </summary>
    public abstract class BaseEntity
    {
        /// <summary>
        /// Gets the URL from where was downloaded the entity.
        /// </summary>
        [JsonProperty]
        public string Url { get; internal set; }

        /// <summary>
        /// Gets the date of creation of the entity.
        /// </summary>
        [JsonProperty]
        public DateTime Created { get; internal set; }

        /// <summary>
        /// Gets the date of last modification.
        /// </summary>
        [JsonProperty]
        public DateTime Edited { get; internal set; }
        
        /// <summary>
        /// Gets the path.
        /// </summary>
        protected abstract string EntryPath { get; }

        /// <summary>
        /// Gets the path for extending base URL API.
        /// </summary>
        /// <returns>System.String the path.</returns>
        public string GetPath()
        {
            return this.EntryPath;
        }
    }
}
