namespace Example
{
    using System;
    using System.Linq;
    using StarWarsApiCSharp;
    public class Program
    {
        static void Main(string[] args)
        {
            IRepository<Planet> planetsRepo = new Repository<Planet>();
            IRepository<Person> peopleRepo = new Repository<Person>();
            IRepository<Vehicle> vehicleRepo = new Repository<Vehicle>();
            IRepository<Specie> speciesRepo = new Repository<Specie>();

            // new Films().Execute();
            // new Starships().Execute();
            new People().Execute();
            
            /*var starships = starshipRepo.GetAll();
            foreach (var ship in starships)
            {
                Console.WriteLine(new string('#', 25));
                Console.WriteLine(ship.Name);
                Console.WriteLine(ship.Model);
                Console.WriteLine(ship.StarshipClass);
                Console.WriteLine(ship.Manufacturer);
                Console.WriteLine(ship.CostInCredits);
                Console.WriteLine(ship.Length);
                Console.WriteLine(ship.Crew);
                Console.WriteLine(ship.Passengers);
                Console.WriteLine(ship.MaxAtmospheringSpeed);
                Console.WriteLine(ship.HyperdriveRating);
                Console.WriteLine(ship.MegaLights);
                Console.WriteLine(ship.CargoCapacity);
                Console.WriteLine(ship.Consumables);
                Console.WriteLine(ship.Films.Count);
                Console.WriteLine(ship.Pilots.Count);
                Console.WriteLine(ship.Created);
                Console.WriteLine(ship.Edited);
                Console.WriteLine(new string('#', 25));
            }

            var planets = planetsRepo.GetAll(size: int.MaxValue);
            foreach (var planet in planets)
            {
                Console.WriteLine(new string('#', 25));
                Console.WriteLine(planet.Name);
                Console.WriteLine(planet.Terrain);
                Console.WriteLine(planet.Climate);
                Console.WriteLine(planet.Created);
                Console.WriteLine(planet.Diameter);
                Console.WriteLine(planet.Edited);
                Console.WriteLine(planet.Films.Count);
                Console.WriteLine(planet.Gravity);
                Console.WriteLine(planet.OrbitalPeriod);
                Console.WriteLine(planet.Residents.Count);
                Console.WriteLine(planet.RotationPeriod);
                Console.WriteLine(planet.SurfaceWater);
                Console.WriteLine(planet.Url);

                Console.WriteLine(new string('#', 25));
            }

            var people = peopleRepo.GetAll(size: int.MaxValue);
            foreach (var person in people)
            {
                Console.WriteLine(new string('#', 25));
                Console.WriteLine(person.Name);
                Console.WriteLine(person.BirthYear);
                Console.WriteLine(person.Created);
                Console.WriteLine(person.Edited);
                Console.WriteLine(person.EyeColor);
                Console.WriteLine(person.Films.Count);
                Console.WriteLine(person.Gender);
                Console.WriteLine(person.HairColor);
                Console.WriteLine(person.Height);
                Console.WriteLine(person.Homeworld);
                Console.WriteLine(person.Mass);
                Console.WriteLine(person.SkinColor);
                Console.WriteLine(person.Species.Count);
                Console.WriteLine(person.Starships.Count);
                Console.WriteLine(person.Url);
                Console.WriteLine(person.Vehicles.Count);
                Console.WriteLine(new string('#', 25));
            }

            var vehicles = vehicleRepo.GetAll(size: int.MaxValue);
            foreach (var vehicle in vehicles)
            {
                Console.WriteLine(new string('#', 25));
                Console.WriteLine(vehicle.Name);
                Console.WriteLine(vehicle.CargoCapacity);
                Console.WriteLine(vehicle.Consumables);
                Console.WriteLine(vehicle.CostInCredits);
                Console.WriteLine(vehicle.Created);
                Console.WriteLine(vehicle.Crew);
                Console.WriteLine(vehicle.Edited);
                Console.WriteLine(vehicle.Films.Count);
                Console.WriteLine(vehicle.Length);
                Console.WriteLine(vehicle.Manufacturer);
                Console.WriteLine(vehicle.MaxAtmospheringSpeed);
                Console.WriteLine(vehicle.Model);
                Console.WriteLine(vehicle.Passengers);
                Console.WriteLine(vehicle.Pilots.Count);
                Console.WriteLine(vehicle.Url);
                Console.WriteLine(vehicle.VehicleClass);
            }

            var species = speciesRepo.GetAll(size: int.MaxValue);
            foreach (var specie in species)
            {
                Console.WriteLine(new string('#', 25));
                Console.WriteLine(specie.AverageHeight);
                Console.WriteLine(specie.AverageLifespan);
                Console.WriteLine(specie.Classification);
                Console.WriteLine(specie.Created);
                Console.WriteLine(specie.Designation);
                Console.WriteLine(specie.Edited);
                Console.WriteLine(specie.EyeColors);
                Console.WriteLine(specie.Films.Count);
                Console.WriteLine(specie.HairColors);
                Console.WriteLine(specie.Homeworld);
                Console.WriteLine(specie.Language);
                Console.WriteLine(specie.Name);
                Console.WriteLine(specie.People.Count);
                Console.WriteLine(specie.SkinColors);
            }
            return;*/
        }
    }
}
