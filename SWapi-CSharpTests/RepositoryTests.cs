namespace SWapi_CSharpTests
{
    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using StarWarsApiCSharp;
    using System.Linq;
    using System.Text;
    using System.Diagnostics;

    [TestClass]
    public class RepositoryTests
    {
        [TestMethod]
        public void ExpectDefaultRepositoryToWorks()
        {
            var mock = new Mock<IDataService>();
            mock.Setup(c => c.GetDataResult(It.IsAny<string>())).Returns(() => null);

            var starshipsRepository = new Repository<Starship>(mock.Object);
            var nullResult = starshipsRepository.GetEntities();
            Assert.IsNull(nullResult);

            // verify mock setup.
            const string Expcted = "http://swapi.co/api/starships/?page=1";

            mock.Verify(c =>
                c.GetDataResult(It.Is<string>(url => url == Expcted)),
                Times.Once());
        }

        [TestMethod]
        public void ExpectDefaultGetDataMethodToBeCalledWithCorrectUrlWithPage()
        {
            var mock = new Mock<IDataService>();
            mock.SetupSequence(c => c.GetDataResult(It.IsAny<string>()))
                .Returns(string.Empty);

            var filmsRepository = new Repository<Film>(mock.Object);
            const int Page = 5;

            var nullResult = filmsRepository.GetEntities(Page);
            Assert.IsNull(nullResult);

            string expcted = "http://swapi.co/api/films/?page=" + Page;
            mock.Verify(c =>
                c.GetDataResult(It.Is<string>(url => url == expcted)),
                Times.Once());
        }

        [TestMethod]
        public void ExpectDefaultGetDataMethodToBeCalledWithCorrectUrlWithPageAndSize()
        {
            var mock = new Mock<IDataService>();
            mock.SetupSequence(c => c.GetDataResult(It.IsAny<string>()))
                .Returns("{ \"next\" : \"someUrl\", \"count\" : 2, \"results\": [ { }, { }]}");

            var peopleRepository = new Repository<Person>(mock.Object);
            const int Page = 5;
            const int Size = 1;

            var people = peopleRepository.GetEntities(Page, Size);
            Assert.AreEqual(Size, people.Count);

            string expcted = "http://swapi.co/api/people/?page=" + Page;
            mock.Verify(c =>
                c.GetDataResult(It.Is<string>(url => url == expcted)),
                Times.Once());
        }

        [TestMethod]
        public void ExpectDefaultGetDataMethodToReturnCorrectDataWithPageAndSize()
        {
            var mock = new Mock<IDataService>();
            const string UrlData = "testUrl";
            mock.SetupSequence(c => c.GetDataResult(It.IsAny<string>()))
                .Returns("{ \"next\" : \"" + UrlData + "\", \"prev\": \"null\", \"count\" : 12, \"results\": [ { }, { }, { }, { },{ }, { }, { }, { }, { }, { }, { }, { }]}")
                .Returns("{ \"count\" : 12, \"results\": [ { }, { }, { }, { }, { }, { }, { }, { }, { }, { }, { }, { }]}");

            var speciesRepository = new Repository<Specie>(mock.Object);
            const int Page = 3;
            const int Size = 18;

            var people = speciesRepository.GetEntities(Page, Size);
            Assert.AreEqual(Size, people.Count);

            string expcted = "http://swapi.co/api/people/?page=" + Page;
            mock.Verify(c =>
                c.GetDataResult(It.Is<string>(url => url == expcted || url == UrlData)),
                Times.Once());
        }

        [TestMethod]
        public void ExpectInitializationOfRepositoryToBeCalledWithDefaultParameters()
        {
            var repository = new Repository<Film>();
            var privateFields = repository
                .GetType()
                .GetFields(System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);

            var urlDataField = privateFields.FirstOrDefault(f => f.Name == "urlData");
            if (urlDataField == null)
            {
                throw new NullReferenceException();
            }

            var urlDataFieldValue = urlDataField.GetValue(repository);
            const string Expected = "http://swapi.co/api/";
            Assert.AreEqual(Expected, urlDataFieldValue);

            var dataServiceField = privateFields.FirstOrDefault(f => f.Name == "dataService");
            if (dataServiceField == null)
            {
                throw new NullReferenceException();
            }
        }

        [TestMethod]
        public void ExpectToReutrnExaclyCountResultsWhenThereAreNotMorePages()
        {
            var mock = new Mock<IDataService>();
            var personRepository = new Repository<Person>(mock.Object);

            mock.Setup(x => x.GetDataResult(It.IsAny<string>()))
                .Returns("{ results: [ { }, { }]}");

            const int Page = 1;
            const int Size = 2;
            var results = personRepository.GetEntities(Page, Size);
            Assert.AreEqual(Size, results.Count);
        }

        [TestMethod]
        public void ExpectToReturnCorrectResultsWhenGetEntitiesIsCalledWithSizeZero()
        {
            var mock = new Mock<IDataService>();
            mock.Setup(x => x.GetDataResult(It.IsAny<string>()))
                .Returns("{ results: [ { }, { }, { }, { }, { }, { } ]}");

            var personRepository = new Repository<Starship>(mock.Object);

            const int Size = 0;
            var results = personRepository.GetEntities(size: Size);
            Assert.AreEqual(Size, results.Count);
        }

        [TestMethod]
        public void ExpectToReturnCorectResultsWhenHighValuePassedAs()
        {
            StringBuilder returnMockResult = new StringBuilder();
            returnMockResult.Append("{ next: \"Url\", results : [");

            const int Size = 5000;
            for (int i = 0; i < Size - 1; i++)
            {
                returnMockResult.Append("{ }, ");
            }

            returnMockResult.Append("{ } ] }");

            var mock = new Mock<IDataService>();
            mock.SetupSequence(x => x.GetDataResult(It.IsAny<string>()))
                .Returns(returnMockResult.ToString())
                .Returns("{ results: [ ] }");

            var repostitory = new Repository<Specie>(mock.Object);
            var result = repostitory.GetEntities(int.MaxValue, int.MaxValue);
            Assert.AreEqual(Size, result.Count);
        }

        [TestMethod]
        public void ExpectCallingConstuctorToSetCorrectConfigurationWithExtensionUrlEndsWithSlash()
        {
            const string TestUrl = "http://myTestUrl.com/";

            var mock = new Mock<IDataService>();
            mock.Setup(x => x.GetDataResult(It.IsAny<string>()))
                .Returns("{ results: [ ]}");
            var planetPath = new Planet().GetPath();
            var repository = new Repository<Planet>(mock.Object, TestUrl);
            repository.GetEntities();

            string expectedUrl = string.Format("{0}{1}{2}", TestUrl, planetPath, "?page=1");

            mock.Verify(c => c.GetDataResult(It.Is<string>(str => str == expectedUrl)), Times.AtLeastOnce);
        }

        [TestMethod]
        public void ExpectCallingConstructorToSetCorrectConfigurationWithExtensionUrlWithoutEndsWithSlash()
        {
            const string TestUrl = "http://myTestUrl.com";

            var mock = new Mock<IDataService>();
            mock.Setup(x => x.GetDataResult(It.IsAny<string>()))
                .Returns("{ results: [ ]}");
            var planetPath = new Planet().GetPath();
            var repository = new Repository<Planet>(mock.Object, TestUrl);
            repository.GetEntities();

            string expectedUrl = string.Format("{0}/{1}{2}", TestUrl, planetPath, "?page=1");

            mock.Verify(c => c.GetDataResult(It.Is<string>(str => str == expectedUrl)), Times.AtLeastOnce);
        }

        [TestMethod]
        public void ExpectPathToBeConfuguredCorrectFromConstructor()
        {
            const string UrlForPlanetRepository = "http://planets.com/api/swapi";
            const string UrlForFilmRepository = "http://films.com/";

            var mock = new Mock<IDataService>();

            var planetRepository = new Repository<Planet>(mock.Object, UrlForPlanetRepository);
            var filmRepository = new Repository<Film>(mock.Object, UrlForFilmRepository);

            Assert.AreEqual(UrlForPlanetRepository + "/", planetRepository.Path);
            Assert.AreEqual(UrlForFilmRepository, filmRepository.Path);
        }

        [TestMethod]
        public void ExpectThreeTimesFasterObjectInitialiingWithHelperInitializerClass()
        {
            Stopwatch timer = new Stopwatch();
            timer.Start();

            const int TestsCount = 1000000;
            for (int i = 0; i < TestsCount; i++)
            {
                Activator.CreateInstance<Person>();
                Activator.CreateInstance<Film>();
                Activator.CreateInstance<Starship>();
                Activator.CreateInstance<Vehicle>();
                Activator.CreateInstance<Planet>();
                Activator.CreateInstance<Specie>();
            }

            timer.Stop();
            var activatorTimer = timer.Elapsed;

            timer.Restart();

            for (int i = 0; i < TestsCount; i++)
            {
                HelperInitializer<Person>.Instance();
                HelperInitializer<Film>.Instance();
                HelperInitializer<Starship>.Instance();
                HelperInitializer<Vehicle>.Instance();
                HelperInitializer<Planet>.Instance();
                HelperInitializer<Specie>.Instance();
            }

            timer.Stop();
            var helperTimer = timer.Elapsed;
            long expectedTimesDifference = 3;

            Assert.IsTrue(
                expectedTimesDifference <= (activatorTimer.Ticks / helperTimer.Ticks),
                "Difference : " + (activatorTimer.Ticks / helperTimer.Ticks));
        }


        [TestMethod]
        public void ExpectGetByIdToPassDefaultUrlForGetDataSource()
        {
            var mock = new Mock<IDataService>();
            mock.Setup(x => x.GetDataResult(It.IsAny<string>()))
                .Returns("{ results: [ ]}");

            var entity = new Planet();
            int Id = 33;
            string expectUrl = $"http://swapi.co/api/{ entity.GetPath() }{ Id }";

            var repository = new Repository<Planet>(mock.Object);
            var result = repository.GetById(Id);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(Planet));

            mock.Verify(c => c.GetDataResult(It.Is<string>(str => str == expectUrl)), Times.AtLeastOnce);
        }

        [TestMethod]
        public void ExpectGetByIdToReturnCorrectResult()
        {
            string returnedResult = @"{
      name: ""Luke"",
      height: ""1.72 m"",
      mass: ""77 Kg"",
      hair_color: ""Blond"",
      skin_color: ""Caucasian"",
      eye_color: ""Blue"",
      birth_year: ""19 BBY"",
      gender: ""Male"",
      homeworld: ""http://swapi.co/api/planets/1/"",
      films: [
          ""http://swapi.co/api/films/1/"",
          ""http://swapi.co/api/films/2/"",
          ""http://swapi.co/api/films/3/""
      ],
      species: [
          ""http://swapi.co/api/species/1/""
      ],
      vehicles: [
          ""http://swapi.co/api/vehicles/14/"",
          ""http://swapi.co/api/vehicles/30/""
      ],
      starships: [
          ""http://swapi.co/api/starships/12/"",
          ""http://swapi.co/api/starships/22/""
      ],
      created: ""2014 -12-09T13:50:51.644000Z"",
      edited: ""2014 -12-10T13:52:43.172000Z"",
      url: ""http://swapi.co/api/people/1/""
}";

            var mock = new Mock<IDataService>();
            mock.Setup(c => c.GetDataResult(It.IsAny<string>()))
                .Returns(returnedResult);

            Person luke = new Repository<Person>(mock.Object).GetById(1);

            Assert.AreEqual(luke.Name, "Luke");
            Assert.AreEqual(luke.Gender, "Male");
            Assert.AreEqual(luke.Films.Count, 3);
            Assert.AreEqual(luke.Starships.Count, 2);
        }

        [TestMethod]
        public void ExpectToReturnNullValueWhenDataCannotBeFound()
        {
            string nullResult = null;
            var mock = new Mock<IDataService>();
            mock.Setup(c => c.GetDataResult(It.IsAny<string>()))
                .Returns(nullResult);

            Film result = new Repository<Film>(mock.Object).GetById(1);

            Assert.IsNull(result);
        }
        //// TODO: Parse objects test
    }
}
