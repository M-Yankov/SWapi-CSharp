namespace Example
{
    using System;
    using StarWarsApiCSharp;

    public class Planets : IExecutor
    {
        public void Execute()
        {
            int page = 2;
            var plnetsRepository = new Repository<Planet>();
            var planets = plnetsRepository.GetAll(page, 5);

            if (planets == null)
            {
                Console.WriteLine("There are no planets on page {0}", page);
            }
            else
            {
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
}
