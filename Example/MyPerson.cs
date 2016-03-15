namespace Example
{
    using System;
    using StarWarsApiCSharp;

    public class MyPerson : Person
    {
        public override string ToString()
        {
            return this.Name + Environment.NewLine +
                "Birth year: " + this.BirthYear + Environment.NewLine +
                "Has " + this.Starships.Count + " starships"; 
        }
    }
}
