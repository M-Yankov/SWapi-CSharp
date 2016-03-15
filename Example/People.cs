namespace Example
{
    using System;
    using StarWarsApiCSharp;

    public class People
    {
        public void Execute()
        {
            IRepository<MyPerson> peopleRepo = new Repository<MyPerson>();
            MyPerson justSomeOne = peopleRepo.GetById(10);
            Console.WriteLine(justSomeOne.ToString());
        }
    }
}
