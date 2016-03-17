namespace Example
{
    using System;
    using StarWarsApiCSharp;

    public class Vehicles : IExecutor
    {
        public void Execute()
        {
            IRepository<Vehicle> vehicleRepository = new Repository<Vehicle>();

            IRepository<Film> filmRepository = new Repository<Film>();

            int vehicleId = 8;
            Vehicle vehicle = vehicleRepository.GetById(vehicleId);

            if (vehicle != null && vehicle.Films.Count > 0)
            {
                Console.WriteLine("Vehicle {0} has {1} films:", vehicle.Name, vehicle.Films.Count);
                foreach (var film in vehicle.Films)
                {
                    int filmId = this.GetFilmId(film);
                    
                    //// getting related items should be done manual
                    Film relatedFilm = filmRepository.GetById(filmId);
                    Console.WriteLine(relatedFilm.Title);
                }
            }
        }

        //// Helper method for extract id from URL.
        private int GetFilmId(string filmUrl)
        {
            //// filmUrl = http://swapi.co/api/films/<Id>/

            int indexOfId = filmUrl.Length - 2;
            int result = int.Parse(filmUrl[indexOfId].ToString());
            return result;
        }
    }
}
