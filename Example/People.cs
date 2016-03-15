namespace Example
{
    using System;
    using StarWarsApiCSharp;

    public class People : IExecutor
    {
        public void Execute()
        {
            IRepository<MyPerson> peopleRepo = new Repository<MyPerson>();
            MyPerson kenobi = peopleRepo.GetById(10);

            if (kenobi != null)
            {
                Console.WriteLine(kenobi.ToString());
            }
            else
            {
                Console.WriteLine("Cannot find this person!");
            }
        }
    }
}
