namespace Example
{
    using System;
    using StarWarsApiCSharp;

    public class StarshipsExample : IExecutor
    {
        public void Execute()
        {
            int starshipId = 3;
            int nonExistingId = 1;
            IRepository<Starship> starshipRepo = new Repository<Starship>();

            Starship starshipDetails = starshipRepo.GetById(starshipId);
            Starship anotherStarship = starshipRepo.GetById(nonExistingId);

            this.PrintStarshipName(starshipDetails, starshipId);
            this.PrintStarshipName(anotherStarship, nonExistingId);
        }

        //// if anotherStarship is null this will throw an exception.
        //// Console.WriteLine(another.Name);
        //// So make sure starship is found!
        private void PrintStarshipName(Starship starship, int starshipID)
        {
            if (starship != null)
            {
                Console.WriteLine(starship.Name);
            }
            else
            {
                Console.WriteLine("Cannot find starship with id: " + starshipID);
            }
        }
    }
}
