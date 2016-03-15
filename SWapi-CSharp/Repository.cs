namespace StarWarsApiCSharp
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using Newtonsoft.Json;

    public class Repository<T> : IRepository<T> where T : BaseEntity
    {
        private const string Api = "http://swapi.co/api/";
        private const int DefaultPage = 1;
        private const int DefaultSize = 10;
        private T entity;

        public Repository()
        {
            this.entity = (T)Activator.CreateInstance<T>();
        }

        protected virtual string Path { get; }

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
                helper = JsonConvert.DeserializeObject<Helper<T>>(jsonResponse);
                results = results.Union(helper.Results);

                if (results.Count() >= size)
                {
                    return results.Take(size).ToList();
                }
            }

            return results.ToList();
        }

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
                return null;
            }
        }
    }
}
