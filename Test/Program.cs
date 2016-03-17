using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using StarWarsApiCSharp;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            var repository = new Repository<Person>();
            var entities = repository.GetEntities(size: int.MaxValue);
            if (entities == null)
            {
                return;
            }

            foreach (var entity in entities)
            {
                Console.WriteLine(entity.Name);
                Console.WriteLine(entity.Created);
                Console.WriteLine(entity.EyeColor);
            }

        }
    }
}
