namespace StarWarsApiCSharp
{
    using System;
    using System.Linq.Expressions;

    public static class HelperInitializer<T>  where T : BaseEntity
    {
        public static Func<T> Instance = Expression.Lambda<Func<T>>(Expression.New(typeof(T))).Compile();
    }
}
