// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-06-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 03-17-2016
// ***********************************************************************
// <copyright file="Repository.cs" company="M-Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Contains generic repository class.</summary>
// ***********************************************************************
namespace StarWarsApiCSharp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;

    /// <summary>
    /// Class Repository holds <see cref="StarWarsApiCSharp.IRepository{T}" /> entities to work with them.
    /// </summary>
    /// <typeparam name="T"><see cref="StarWarsApiCSharp.IRepository{T}" />Base entity.</typeparam>
    /// <seealso cref="StarWarsApiCSharp.IRepository{T}" />
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        /// <summary>
        /// The default API URL from where entities are downloaded.
        /// </summary>
        private const string Api = "http://swapi.co/api/";

        /// <summary>
        /// The default page.
        /// </summary>
        private const int DefaultPage = 1;

        /// <summary>
        /// The default size of entities.
        /// </summary>
        private const int DefaultSize = 10;

        /// <summary>
        /// The URL end character. By default is "/" slash.
        /// </summary>
        private string urlEndCharacter = "/";

        /// <summary>
        /// The URL data that will be used in data service.
        /// </summary>
        private string urlData;

        /// <summary>
        /// The data service for entities.
        /// </summary>
        private IDataService dataService;

        /// <summary>
        /// The base entity.
        /// <seealso cref="StarWarsApiCSharp.BaseEntity" />
        /// </summary>
        private T entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}" /> class. 
        /// Uses the default data service and URL for gather data.
        /// </summary>
        public Repository()
            : this(new DefaultDataService(new WebHelper()), Api)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class. Uses a default URL for gather data.
        /// </summary>
        /// <param name="dataService">The data service to get entities.</param>
        /// <example>Data service getting data from JSON document, other database etc.</example>
        public Repository(IDataService dataService)
            : this(dataService, Api)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        /// <param name="dataService">The data service to get entities.</param>
        /// <param name="url">The URL for consuming. It will be used in the service. Examples: http://mySite.com, http://mySite.com/ .</param>
        /// <example>Data service getting data from JSON document, other database etc.</example>
        public Repository(IDataService dataService, string url)
        {
            this.entity = HelperInitializer<T>.Instance();
            this.dataService = dataService;

            if (!url.EndsWith(this.urlEndCharacter))
            {
                url += this.urlEndCharacter;
            }

            this.urlData = url;
        }

        /// <summary>
        /// Gets the base path for consuming entities.
        /// </summary>
        /// <value>The path.</value>
        public string Path
        {
            get
            {
                return this.urlData;
            }
        }

        /// <summary>
        /// Gets the entity by it's identifier.
        /// </summary>
        /// <param name="id">The identifier of the entity.</param>
        /// <returns><see cref="StarWarsApiCSharp.IRepository{T}" /></returns>
        public T GetById(int id)
        {
            // TODO: override-able GetPath Method ??
            // TODO: separate UrlBuilderClass
            string url = this.urlData + this.entity.GetPath() + id;
            string jsonResponse = this.dataService.GetDataResult(url);
            if (jsonResponse == null)
            {
                return null;
            }

            return JsonConvert.DeserializeObject<T>(jsonResponse);
        }

        /// <summary>
        /// Gets entities.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size of the entities.</param>
        /// <returns>ICollection&lt; <see cref="StarWarsApiCSharp.IRepository{T}" /> &gt;.</returns>
        public ICollection<T> GetEntities(int page = DefaultPage, int size = DefaultSize)
        {
            // TODO: separate UrlBuilderClass
            string url = this.urlData + this.entity.GetPath() + "?page=" + page;
            IEnumerable<T> results = new List<T>();
            var helper = new Helper<T>()
            {
                Next = url
            };

            string jsonResponse = string.Empty;

            while (helper.Next != null)
            {
                jsonResponse = this.dataService.GetDataResult(helper.Next);
                if (jsonResponse == null)
                {
                    return null;
                }

                helper = JsonConvert.DeserializeObject<Helper<T>>(jsonResponse);
                if (helper == null)
                {
                    return null;
                }

                results = results.Union(helper.Results);

                if (results.Count() >= size)
                {
                    return results.Take(size).ToList();
                }
            }

            return results.ToList();
        }
    }
}
