namespace Example
{
    using System;
    using StarWarsApiCSharp;

    public class PlanetsExample : IExecutor
    {
        public void Execute()
        {
            int page = 2;
            int size = 5;
            var plnetsRepository = new Repository<Planet>();

            var planets = plnetsRepository.GetEntities(page, size);

            if (planets == null)
            {
                Console.WriteLine("There are no planets on page {0}", page);
                return;
            }

            int index = 1;
            foreach (var planet in planets)
            {
                Console.WriteLine(index + ". Name: " + planet.Name);
                Console.WriteLine("   Terrain: " + planet.Terrain);
                index++;
            }
        }
    }
}
