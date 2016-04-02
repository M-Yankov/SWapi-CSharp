namespace Example
{
    using System;
    using System.Linq;
    using ServiceDemo;
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

            ProcessExecuteCommand(new FilmsFromFileDemo(), template, "Another service example", backgroundColor);

            //ProcessExecuteCommand(new FilmsExample(), template, "Films", backgroundColor);
            //ProcessExecuteCommand(new StarshipsExample(), template, "Starhips", backgroundColor);
            //ProcessExecuteCommand(new People(), template, "People", backgroundColor);
            //ProcessExecuteCommand(new Planets(), template, "Planets", backgroundColor);
            //ProcessExecuteCommand(new Species(), template, "Species", backgroundColor);
            //ProcessExecuteCommand(new Vehicles(), template, "Vehicles", backgroundColor);
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
