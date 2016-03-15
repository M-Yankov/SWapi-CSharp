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
            IRepository<Vehicle> vehicleRepo = new Repository<Vehicle>();
            IRepository<Specie> speciesRepo = new Repository<Specie>();

            ConsoleColor backgroundColor = ConsoleColor.DarkBlue;
            string template = "Press [Enter] to process with {0} example";
            
            ProcessExecuteCommand(new Films(), template, "Films", backgroundColor);
            ProcessExecuteCommand(new Starships(), template, "Starhips", backgroundColor);
            ProcessExecuteCommand(new People(), template, "People", backgroundColor);
            ProcessExecuteCommand(new Planets(), template, "Planets", backgroundColor);

            /*
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

        private static void ProcessExecuteCommand(
            IExecutor executor,
            string template, 
            string typeName,
            ConsoleColor backgroundColor)
        {
            ConsoleColor defaultColor = Console.BackgroundColor;

            Console.BackgroundColor = backgroundColor;
            Console.WriteLine(template, typeName);
            Console.BackgroundColor = defaultColor;
            Console.ReadLine();

            executor.Execute();
        }
    }
}
