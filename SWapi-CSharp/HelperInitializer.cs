// ***********************************************************************
// Assembly         : StarWarsApiCSharp
// Author           : M.Yankov
// Created          : 02-27-2016
//
// Last Modified By : M.Yankov
// Last Modified On : 05-23-2016
// ***********************************************************************
// <copyright file="HelperInitializer.cs" company="M-Yankov">
//     Copyright ©  2016
// </copyright>
// <summary>Contains HelperInitializer class.</summary>
// ***********************************************************************
namespace StarWarsApiCSharp
{
    using System;
    using System.Linq.Expressions;

    /// <summary>
    /// This static helper initializer is 3x faster than <see cref="System.Activator.CreateInstance{T}"/>.
    /// </summary>
    /// <typeparam name="T">Generic object inherits <see cref="StarWarsApiCSharp.BaseEntity"/></typeparam>
    public static class HelperInitializer<T> where T : BaseEntity
    {
        /// <summary>
        /// Gets the instance of T.
        /// </summary>
        /// <value>
        /// The instance.
        /// </value>
        public static readonly Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
    }
}
