// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-27-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 05-23-2016
// ***********************************************************************
// <copyright file="IWebHelper.cs" company="M-Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Contains IWebHelper interface for implementing.</summary>
// ***********************************************************************
namespace StarWarsApiCSharp
{
    using System.Net;

    /// <summary>
    /// Helper for retrieve request and response.
    /// </summary>
    public interface IWebHelper
    {
        /// <summary>
        /// Gets instance of <see cref="System.Net.WebRequest"/>.
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>Initialized <see cref="System.Net.WebRequest"/>.</returns>
        WebRequest GetRequest(string url);

        /// <summary>
        /// Gets the instance of <see cref="System.Net.WebResponse"/> from request.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>Response from request.</returns>
        WebResponse GetResponse(WebRequest request);
    }
}