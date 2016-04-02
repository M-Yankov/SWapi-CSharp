// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-27-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 04-01-2016
// ***********************************************************************
// <copyright file="DefaultDataService.cs" company="M.Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Default data service.</summary>
// ***********************************************************************
namespace StarWarsApiCSharp
{
    using System.IO;
    using System.Net;

    /// <summary>
    /// This is the default service for consuming data from web.
    /// </summary>
    /// <seealso cref="StarWarsApiCSharp.IDataService" />
    public class DefaultDataService : IDataService
    {
        /// <summary>
        /// Gets the result from response helper method.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>System.String or null if there are error while processing the request.</returns>
        public string GetDataResult(string url)
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
