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
    /// <typeparam name="T"><see cref="StarWarsApiCSharp.IRepository{T}" /></typeparam>
    /// <seealso cref="StarWarsApiCSharp.IRepository{T}" />
    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private const string Api = "http://swapi.co/api/";
        private const int DefaultPage = 1;
        private const int DefaultSize = 10;
        private T entity;

        /// <summary>
        /// Initializes a new instance of the <see cref="Repository{T}"/> class.
        /// </summary>
        public Repository()
        {
            this.entity = (T)Activator.CreateInstance<T>();
        }

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
        /// Gets all entities.
        /// </summary>
        /// <param name="page">The page.</param>
        /// <param name="size">The size of the entities.</param>
        /// <returns>ICollection&lt; <see cref="StarWarsApiCSharp.IRepository{T}" /> &gt;.</returns>
        public ICollection<T> GetAll(int page = DefaultPage, int size = DefaultSize)
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
