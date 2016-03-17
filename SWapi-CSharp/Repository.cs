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
        /// The base API URL from where entities are downloaded.
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
        /// The base entity.
        /// <seealso cref="StarWarsApiCSharp.BaseEntity" />
        /// </summary>
        private T entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}" /> class.
        /// </summary>
        public Repository()
        {
            this.entity = (T)Activator.CreateInstance<T>();
        }

        /// <summary>
        /// Gets the path.
        /// </summary>
        /// <value>The path.</value>
        protected virtual string Path { get; }

        /// <summary>
        /// Gets the entity by it's identifier.
        /// </summary>
        /// <param name="id">The identifier.</param>
        /// <returns><see cref="StarWarsApiCSharp.IRepository{T}" /></returns>
        public T GetById(int id)
        {
            string url = Api + this.entity.GetPath() + id;
            string jsonResponse = this.GetResultFromResponse(url);
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
            string url = Api + this.entity.GetPath() + "?page=" + page;
            IEnumerable<T> results = new List<T>();
            var helper = new Helper<T>()
            {
                Next = url
            };

            string jsonResponse = string.Empty;

            while (helper.Next != null)
            {
                jsonResponse = this.GetResultFromResponse(helper.Next);
                if (jsonResponse == null)
                {
                    return null;
                }

                helper = JsonConvert.DeserializeObject<Helper<T>>(jsonResponse);
                results = results.Union(helper.Results);

                if (results.Count() >= size)
                {
                    return results.Take(size).ToList();
                }
            }

            return results.ToList();
        }

        /// <summary>
        /// Gets the result from response helper method.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.String or null if there are error while processing the request.</returns>
        private string GetResultFromResponse(string url)
        {
            WebRequest request = WebRequest.Create(url);
            WebResponse response = null;

            try
            {
                response = request.GetResponse();
                string json = string.Empty;
                using (StreamReader reader = new StreamReader(response.GetResponseStream()))
                {
                    json = reader.ReadToEnd();
                }

                return json;
            }
            catch (WebException ex)
            {
                //// TODO: Check status when there are no Internet connection. 
                return null;
            }
        }
    }
}
