namespace SWapi_CSharpTests
{
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using StarWarsApiCSharp;

    [TestClass]
    public class ParsingTests
    {
        [TestMethod]
        public void ExpectParisingAllPropertisOfPerson()
        {
            var testUrl = "testUrl";
            string returnResult = $@"{{
    name: ""Test person"",
      height: ""1.999999 m"",
      mass: ""70 Kg"",
      hair_color: ""Black"",
      skin_color: ""Caucasian"",
      eye_color: ""Brown"",
      birth_year: ""19 BBY"",
      gender: ""Male"",
      homeworld: ""http://test/planets/1441/"",
      films: [
          ""http://{ testUrl }/film/1/"",
          ""http://{ testUrl }/film/2/"",
          ""http://{ testUrl }/film/3/"",
          ""http://{ testUrl }/film/10/"",
          ""http://{ testUrl }/film/4/"",
          ""http://{ testUrl }/film/7/""
      ],
      species: [
          ""http://{ testUrl }/species/156/""
          ""http://{ testUrl }/species/114/""
          ""http://{ testUrl }/species/1124/""
          ""http://{ testUrl }/species/1624/""
      ],
      vehicles: [
          ""http://{ testUrl }/vehicles/14234/"",
          ""http://{ testUrl }/vehicles/1030/""
      ],
      starships: [
          ""http://{ testUrl }/starships/12412/"",
          ""http://{ testUrl }/starships/4522/""
      ],
      created: ""2014-12-09T13:50:51.644000Z"",
      edited: ""2014-12-10T13:52:43.172000Z"",
      url: ""http://{ testUrl }/""
}}";

            var mock = new Mock<IDataService>();
            mock.Setup(c => c.GetDataResult(It.IsAny<string>()))
                .Returns(returnResult);

            Person testObject = new Repository<Person>(mock.Object).GetById(2);

            Assert.IsNotNull(testObject.HairColor);
            Assert.IsNotNull(testObject.Name);
            Assert.IsNotNull(testObject.SkinColor);
            Assert.IsNotNull(testObject.Homeworld);
            Assert.IsNotNull(testObject.BirthYear);
            Assert.IsNotNull(testObject.Created);
            Assert.IsNotNull(testObject.Edited);
            Assert.IsNotNull(testObject.EyeColor);
            Assert.IsNotNull(testObject.Gender);
            Assert.IsNotNull(testObject.Mass);
            Assert.IsNotNull(testObject.Url);
            Assert.IsNotNull(testObject.Height);

            var allCollectionsContainsTestUrl =
                testObject.Starships.All(s => s.Contains(testUrl)) &&
                testObject.Vehicles.All(s => s.Contains(testUrl)) &&
                testObject.Films.All(s => s.Contains(testUrl)) &&
                testObject.Species.All(s => s.Contains(testUrl)) &&
                testObject.Url.Contains(testUrl);

            Assert.IsTrue(allCollectionsContainsTestUrl);
        }

        [TestMethod]
        public void ExpectToParseSomeOfPropertiesOfStarship()
        {
            const string NotAvailable = "n/a";

            string returnResultData = $@"{{
    name: ""CR90 corvette"",
    model: """",
	manufacturer: ""Corellian Engineering Corporation"",
	cost_in_credits: ""3500000"",
	length: ""{ NotAvailable }"",
	max_atmosphering_speed: ""950"",
	crew: ""165"",
	passengers: ""{ NotAvailable }"",
	cargo_capacity: ""3000000"",
	consumables: ""1 year"",
	hyperdrive_rating: ""2.0"",
	starship_class: ""corvette"",
	pilots: [],
	films: [
		""http://swapi.co/api/films/6/"",
		""http://swapi.co/api/films/3/"",
		""http://swapi.co/api/films/1/""
	],
	created: ""2014-12-10T14:20:33.369000Z"",
	edited: ""2014-12-22T17:35:45.408368Z"",
	url: ""http://swapi.co/api/starships/2/""
}}";

            var mock = new Mock<IDataService>();
            mock.Setup(c => c.GetDataResult(It.IsAny<string>()))
                .Returns(returnResultData);

            Starship testStarship = new Repository<Starship>(mock.Object).GetById(3);
            const int ExpectedFilmsCount = 3;
            Assert.AreEqual(string.Empty, testStarship.Model);
            Assert.AreEqual(NotAvailable, testStarship.Length);
            Assert.AreEqual(NotAvailable, testStarship.Passengers);
            Assert.AreEqual(ExpectedFilmsCount, testStarship.Films.Count);

            Assert.IsNull(testStarship.MegaLights);
            testStarship.MegaLights = string.Empty;
            Assert.IsNotNull(testStarship.MegaLights);

            Assert.IsNotNull(testStarship.CargoCapacity);
            Assert.IsNotNull(testStarship.Consumables);
            Assert.IsNotNull(testStarship.CostInCredits);
            Assert.IsNotNull(testStarship.Created);
            Assert.IsNotNull(testStarship.Crew);
            Assert.IsNotNull(testStarship.Edited);
            Assert.IsNotNull(testStarship.HyperdriveRating);
            Assert.IsNotNull(testStarship.Manufacturer);
            Assert.IsNotNull(testStarship.Model);
            Assert.IsNotNull(testStarship.MaxAtmospheringSpeed);
            Assert.IsNotNull(testStarship.Name);
            Assert.IsNotNull(testStarship.Pilots);
            Assert.IsNotNull(testStarship.StarshipClass);
            Assert.IsNotNull(testStarship.Url);
        }

        [TestMethod]
        public void ExpectToParseCorrectlyAllPropertiesOfPlanet()
        {
            string returnResultData = $@"{{
    name: ""Alderaan"",
    rotation_period: ""24"",
	orbital_period: ""364"",
	diameter: ""12500"",
	climate: ""temperate"",
	gravity: ""1 standard"",
	terrain: ""grasslands, mountains"",
	surface_water: ""40"",
	population: ""2000000000"",
	residents: [
		""http://swapi.co/api/people/5/"",
		""http://swapi.co/api/people/68/"",
		""http://swapi.co/api/people/81/""
	],
	films: [
		""http://swapi.co/api/films/6/"",
		""http://swapi.co/api/films/1/""
	],
	created: ""2014-12-10T11:35:48.479000Z"",
	edited: ""2014-12-20T20:58:18.420000Z"",
	url: ""http://swapi.co/api/planets/2/""
}}";

            var mock = new Mock<IDataService>();
            mock.Setup(c => c.GetDataResult(It.IsAny<string>()))
                .Returns(returnResultData);

            Planet testPlanet = new Repository<Planet>(mock.Object).GetById(3);

            var properties = testPlanet.GetType().GetProperties();
            foreach (var property in properties)
            {
                var value = property.GetValue(testPlanet);
                Assert.IsNotNull(value, property.Name);
            }

            Assert.AreEqual(2, testPlanet.Films.Count);
            Assert.AreEqual(3, testPlanet.Residents.Count);
        }

        [TestMethod]
        public void ExpectToParseCorrectlyAllPropertiesOfSpecie()
        {
            string returnResultData = $@"{{
    name: ""Droid"",
    classification: ""artificial"",
	designation: ""sentient"",
	average_height: ""n/a"",
	skin_colors: ""n/a"",
	hair_colors: ""n/a"",
	eye_colors: ""n/a"",
	average_lifespan: ""indefinite"",
	homeworld: ""someTestWorld"",
	language: ""n/a"",
	people: [
		""http://swapi.co/api/people/2/"",
		""http://swapi.co/api/people/3/"",
		""http://swapi.co/api/people/8/"",
		""http://swapi.co/api/people/23/"",
		""http://swapi.co/api/people/87/""
	],
	films: [
		""http://swapi.co/api/films/7/"",
		""http://swapi.co/api/films/5/"",
		""http://swapi.co/api/films/4/"",
		""http://swapi.co/api/films/6/"",
		""http://swapi.co/api/films/3/"",
		""http://swapi.co/api/films/2/"",
		""http://swapi.co/api/films/1/""
	],
	created: ""2014-12-10T15:16:16.259000Z"",
	edited: ""2015-04-17T06:59:43.869528Z"",
	url: ""http://swapi.co/api/species/2/""
}}";

            var mock = new Mock<IDataService>();
            mock.Setup(c => c.GetDataResult(It.IsAny<string>()))
                .Returns(returnResultData);

            Specie testSpecie = new Repository<Specie>(mock.Object).GetById(2);

            var specieProperties = testSpecie.GetType().GetProperties();
            foreach (var property in specieProperties)
            {
                var value = property.GetValue(testSpecie);
                Assert.IsNotNull(value, property.Name);
            }

            Assert.AreEqual(7, testSpecie.Films.Count);
            Assert.AreEqual(5, testSpecie.People.Count);
        }

        [TestMethod]
        public void ExpectToParseCorrectlyAllProperiesOfVehicle()
        {
            string returnResultData = $@"{{
    name: ""Sand Crawler"",
    model: ""Digger Crawler"",
	manufacturer: ""Corellia Mining Corporation"",
	cost_in_credits: ""150000"",
	length: ""36.8"",
	max_atmosphering_speed: ""30"",
	crew: ""46"",
	passengers: ""30"",
	cargo_capacity: ""50000"",
	consumables: ""2 months"",
	vehicle_class: ""wheeled"",
	pilots: [],
	films: [
		""http://swapi.co/api/films/5/"",
		""http://swapi.co/api/films/1/""
	],
	created: ""2014-12-10T15:36:25.724000Z"",
	edited: ""2014-12-22T18:21:15.523587Z"",
	url: ""http://swapi.co/api/vehicles/4/""
}}";

            var mock = new Mock<IDataService>();
            mock.Setup(c => c.GetDataResult(It.IsAny<string>()))
                .Returns(returnResultData);

            Vehicle testVehicle = new Repository<Vehicle>(mock.Object).GetById(2);

            var vehicleProrpeties = testVehicle.GetType().GetProperties();
            foreach (var property in vehicleProrpeties)
            {
                var value = property.GetValue(testVehicle);
                Assert.IsNotNull(value, property.Name);
            }

            Assert.AreEqual(0, testVehicle.Pilots.Count);
            Assert.AreEqual(2, testVehicle.Films.Count);
        }

        [TestMethod]
        public void ExpectToParseCorrectlyAllPropetiesOfFilm()
        {
            string returnResultData = $@"{{
    title: ""Return of the Jedi"",
    episode_id: 6,
	opening_crawl: ""Luke Skywalker has returned to\r\nhis home planet of Tatooine in\r\nan attempt to rescue his\r\nfriend Han Solo from the\r\nclutches of the vile gangster\r\nJabba the Hutt.\r\n\r\nLittle does Luke know that the\r\nGALACTIC EMPIRE has secretly\r\nbegun construction on a new\r\narmored space station even\r\nmore powerful than the first\r\ndreaded Death Star.\r\n\r\nWhen completed, this ultimate\r\nweapon will spell certain doom\r\nfor the small band of rebels\r\nstruggling to restore freedom\r\nto the galaxy..."",
	director: ""Richard Marquand"",
	producer: ""Howard G. Kazanjian, George Lucas, Rick McCallum"",
	release_date: ""1983-05-25"",
	characters: [],
	planets: [],
	starships: [],
	vehicles: [],
	species: [],
	created: ""2014-12-18T10:39:33.255000Z"",
	edited: ""2015-04-11T09:46:05.220365Z"",
	url: ""http://swapi.co/api/films/3/""
}}";
            var mock = new Mock<IDataService>();
            mock.Setup(c => c.GetDataResult(It.IsAny<string>()))
                .Returns(returnResultData);

            Film testFilm = new Repository<Film>(mock.Object).GetById(3);

            var filmProperties = testFilm.GetType().GetProperties();
            foreach (var property in filmProperties)
            {
                var value = property.GetValue(testFilm);
                Assert.IsNotNull(value, property.Name);
            }

            Assert.AreEqual(0, testFilm.Characters.Count);
            Assert.AreEqual(0, testFilm.Vehicles.Count);
            Assert.AreEqual(0, testFilm.Species.Count);
            Assert.AreEqual(0, testFilm.Planets.Count);
            Assert.AreEqual(0, testFilm.Starships.Count);
        }
    }
}
