namespace Example
{
    using System;
    using StarWarsApiCSharp;

    public class Films
    {
        public void Execute()
        {
            IRepository<Film> filmsRepo = new Repository<Film>();
            var films = filmsRepo.GetAll(size: int.MaxValue);

            foreach (var film in films)
            {
                Console.WriteLine(new string('#', 25));
                Console.WriteLine("Title: " + film.Title);
                Console.WriteLine("Opening crawl: " + film.OpeningCrawl);
                Console.WriteLine("Director: " + film.Director);
                Console.WriteLine("Release date: " + film.ReleaseDate);
                Console.WriteLine("Episode:  " + film.EpisodeId);
                Console.WriteLine("Producer: " + film.Producer);
                Console.WriteLine("Characters: " + film.Characters.Count);
                Console.WriteLine("Planets: " + film.Planets.Count + " :");

                foreach (var item in film.Planets)
                {
                    Console.WriteLine(new string('-', 3) + ">" + item);
                }

                Console.WriteLine("URL: " + film.Url);
                Console.WriteLine("Date edited: " + film.Edited);
                Console.WriteLine("Date created: " + film.Created);
            }
        }
    }
}
