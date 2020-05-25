namespace Example.ServiceDemo
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using StarWarsApiCSharp;

    public class FilmsFromFileDemo : IExecutor
    {
        public void Execute()
        {
            var service = new JsonFileService();
            var path = Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(path);

            var d = new DirectoryInfo(path);

            while (!d.FullName.EndsWith("Example"))
            {
                d = d.Parent;
            }

            path = $"{d.FullName}\\";

            var filmsRepository = new Repository<Film>(service, path);
            var filmsFromFile = filmsRepository.GetEntities().ToList();

            var starshipsRepo = new Repository<Starship>(service, path);

            for (int i = 0; i < filmsFromFile.Count; i++)
            {
                Console.WriteLine((i + 1) + ". " + filmsFromFile[i].Title);
                if (filmsFromFile[i].Starships.Count > 0)
                {
                    foreach (string starshipUrl in filmsFromFile[i].Starships)
                    {
                        int id = this.GetFilmId(starshipUrl);
                        var starship = starshipsRepo.GetById(id);

                        if (starship != null)
                        {
                            Console.WriteLine("\t" + starship.Name);
                        }
                        else
                        {
                            Console.WriteLine("\tNot found with id {0}!", id);
                        }
                    }
                }
            }
        }

        private int GetFilmId(string filmUrl)
        {
            //// filmUrl = http://swapi.co/api/starships/<Id>/

            int secondSlash = filmUrl.LastIndexOf("/");
            int firstSlash = filmUrl.LastIndexOf("/", secondSlash - 1);
            int lengthOfSubstring = (secondSlash - firstSlash) - 1;
            string stringId = filmUrl.Substring(firstSlash + 1, lengthOfSubstring);

            int result = int.Parse(stringId);
            return result;
        }
    }
}
