namespace Example
{
    using System;
    using System.Linq;
    using StarWarsApiCSharp;

    public class Program
    {
        public static void Main(string[] args)
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
            ProcessExecuteCommand(new Species(), template, "Species", backgroundColor);
            ProcessExecuteCommand(new Vehicles(), template, "Vehicles", backgroundColor);
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
