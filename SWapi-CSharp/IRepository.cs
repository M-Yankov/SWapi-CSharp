namespace StarWarsApiCSharp
{
    using System.Collections.Generic;

    public interface IRepository<T>  where T : BaseEntity
    {
        T GetById(int id);

        ICollection<T> GetAll(int page = 1, int size = 10);
    }
}
