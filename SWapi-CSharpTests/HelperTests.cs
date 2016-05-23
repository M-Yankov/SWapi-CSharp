using Microsoft.VisualStudio.TestTools.UnitTesting;
namespace SWapi_CSharpTests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Net;
    using Moq;
    using StarWarsApiCSharp;
    using System.IO;

    [TestClass]
    public class HelperTests
    {
        [TestMethod]
        public void ExpectGettingRequestObjectToWorkCorrect()
        {
            const string validUrl = "http://testsite.com/";
            WebRequest request = new WebHelper().GetRequest(validUrl);
            Assert.AreEqual(validUrl, request.RequestUri.ToString());
        }

        [TestMethod]
        public void ExpectRetreiveResponseFromRequestReturnsCorrectValue()
        {
            var mock = new Mock<WebRequest>();

            const string ExpectedReturnValue = "Testing";
            mock.Setup(r => r.GetResponse())
                .Returns(new TestWebResponse(ExpectedReturnValue));

            WebResponse response = new WebHelper().GetResponse(mock.Object);
            StreamReader stream = new StreamReader(response.GetResponseStream());
            var actial = stream.ReadToEnd();

            stream.Dispose();

            Assert.AreEqual(ExpectedReturnValue, actial);
        }
    }
}
