namespace StarWarsApiCSharp
{
    using System.Collections.Generic;
    using Newtonsoft.Json;

    public class Vehicle : BaseEntity
    {
        private const string PathToEntity = "vehicles/";

        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public string Model { get; set; }
       
        [JsonProperty(PropertyName = "vehicle_class")]
        public string VehicleClass { get; set; }

        [JsonProperty]
        public string Manufacturer { get; set; }

        [JsonProperty]
        public string Length { get; set; }

        [JsonProperty(PropertyName = "cost_in_credits")]
        public string CostInCredits { get; set; }

        [JsonProperty]
        public string Crew { get; set; }

        [JsonProperty]
        public string Passengers { get; set; }

        [JsonProperty(PropertyName = "max_atmosphering_speed")]
        public string MaxAtmospheringSpeed { get; set; }

        [JsonProperty(PropertyName = "cargo_capacity")]
        public string CargoCapacity { get; set; }

        [JsonProperty]
        public string Consumables { get; set; }

        [JsonProperty]
        public ICollection<string> Films { get; set; }

        [JsonProperty]
        public ICollection<string> Pilots { get; set; }

        protected override string Path
        {
            get
            {
                return PathToEntity;
            }
        }
    }
}
