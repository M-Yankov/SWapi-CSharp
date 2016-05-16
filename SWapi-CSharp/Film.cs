// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-27-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="Film.cs" company="M.Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Contains Film model.</summary>
// ***********************************************************************

namespace StarWarsApiCSharp
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    /// Class Film.
    /// </summary>
    /// <seealso cref="StarWarsApiCSharp.BaseEntity" />
    public class Film : BaseEntity
    {
        /// <summary>
        /// The path that will be added to base API URL.
        /// </summary>
        private const string PathToEntity = "films/";

        /// <summary>
        /// Gets the title.
        /// </summary>
        /// <value>The title.</value>
        [JsonProperty]
        public string Title { get; internal set; }

        /// <summary>
        /// Gets the episode identifier.
        /// </summary>
        /// <value>The episode identifier.</value>
        [JsonProperty(PropertyName = "episode_id")]
        public string EpisodeId { get; internal set; }

        /// <summary>
        /// Gets the opening crawl.
        /// </summary>
        /// <value>The opening crawl.</value>
        [JsonProperty(PropertyName = "opening_crawl")]
        public string OpeningCrawl { get; internal set; }

        /// <summary>
        /// Gets the director.
        /// </summary>
        /// <value>The director.</value>
        [JsonProperty]
        public string Director { get; internal set; }

        /// <summary>
        /// Gets the producer.
        /// </summary>
        /// <value>The producer.</value>
        [JsonProperty]
        public string Producer { get; internal set; }

        /// <summary>
        /// Gets the release date.
        /// </summary>
        /// <value>The release date.</value>
        [JsonProperty(PropertyName = "release_date")]
        public string ReleaseDate { get; internal set; }

        /// <summary>
        /// Gets the species.
        /// </summary>
        /// <value>The species.</value>
        [JsonProperty]
        public ICollection<string> Species { get; internal set; }

        /// <summary>
        /// Gets the starships URLs.
        /// </summary>
        /// <value>The starships.</value>
        [JsonProperty]
        public ICollection<string> Starships { get; internal set; }

        /// <summary>
        /// Gets the vehicles URLs.
        /// </summary>
        /// <value>The vehicles.</value>
        [JsonProperty]
        public ICollection<string> Vehicles { get; internal set; }

        /// <summary>
        /// Gets the characters URLs.
        /// </summary>
        /// <value>The characters.</value>
        [JsonProperty]
        public ICollection<string> Characters { get; internal set; }

        /// <summary>
        /// Gets the planets URLs.
        /// </summary>
        /// <value>The planets.</value>
        [JsonProperty]
        public ICollection<string> Planets { get; internal set; }

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
