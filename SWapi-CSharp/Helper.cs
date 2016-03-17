// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-27-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="Helper.cs" company="M-Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Contains Helper class.</summary>
// ***********************************************************************
namespace StarWarsApiCSharp
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Class Helper contains results and option to navigate to other pages.
    /// </summary>
    /// <typeparam name="T"><see cref="StarWarsApiCSharp.BaseEntity" />Base entity.</typeparam>
    internal class Helper<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets or sets the results downloaded from http://SWAPI.co.
        /// </summary>
        /// <value>The results.</value>
        [JsonProperty]
        public ICollection<T> Results { get; set; }

        /// <summary>
        /// Gets or sets the count of the results.
        /// </summary>
        /// <value>The count of the results.</value>
        [JsonProperty]
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the next page.
        /// </summary>
        /// <value>The next page.</value>
        [JsonProperty]
        public string Next { get; set; }

        /// <summary>
        /// Gets or sets the previous page.
        /// </summary>
        /// <value>The previous page.</value>
        [JsonProperty]
        public string Previous { get; set; }
    }
}
