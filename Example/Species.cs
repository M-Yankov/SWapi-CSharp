namespace Example
{
    using System;
    using StarWarsApiCSharp;

    public class Species : IExecutor
    {
        public void Execute()
        {
            Repository<Specie> specieRepository = new Repository<Specie>();
            Specie specie = specieRepository.GetById(5);

            const string UnknownValue = "unknown";
            const int SpecialSpan = 2;

            if (specie != null && specie.AverageLifespan != UnknownValue)
            {
                int lifeSpan = int.Parse(specie.AverageLifespan);
                Console.WriteLine("Life span: " + (lifeSpan + SpecialSpan));
            }

            int lifeSpanAverage = 0;
            if (int.TryParse(specie.AverageLifespan, out lifeSpanAverage))
            {
                Console.WriteLine("Life span: " + (lifeSpanAverage + SpecialSpan));
            }
        }
    }
}
