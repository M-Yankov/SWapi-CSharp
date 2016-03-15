namespace Example
{
    using System;
    using StarWarsApiCSharp;

    public class Starships
    {
        public void Execute()
        {
            int starshipId = 3;
            int nonExistingId = 1;
            IRepository<Starship> starshipRepo = new Repository<Starship>();

            Starship starshipDetails = starshipRepo.GetById(starshipId);
            Console.WriteLine("Starship name: " + starshipDetails.Name);

            Starship anotherStarship = starshipRepo.GetById(nonExistingId);
            
            //// if anotherStarship is null this will throw an exception.
            //// Console.WriteLine(another.Name);
            //// So make sure starship is found!
            if (anotherStarship != null)
            {
                Console.WriteLine(anotherStarship.Name);
            }
            else
            {
                Console.WriteLine("Cannot find starship with id: " + nonExistingId);
            }
        }
    }
}
