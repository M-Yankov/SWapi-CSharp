// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-27-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 04-01-2016
// ***********************************************************************
// <copyright file="IDataService.cs" company="M.Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Interface service.</summary>
// ***********************************************************************
namespace StarWarsApiCSharp
{
    /// <summary>
    /// A Service for consuming data from remote source. 
    /// </summary>
    public interface IDataService
    {
        /// <summary>
        /// Gets the data result as JSON. The syntax and format of the result should be valid. 
        /// </summary>
        /// <param name="url">The URL for consuming.</param>
        /// <returns>JSON data as string.</returns>
        string GetDataResult(string url);
    }
}
