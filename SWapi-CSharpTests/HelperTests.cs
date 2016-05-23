namespace SWapi_CSharpTests
{
    using System;
    using System.IO;
    using System.Net;
    using System.Reflection;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using Moq;
    using Newtonsoft.Json;
    using StarWarsApiCSharp;

    [TestClass]
    public class HelperTests
    {
        [TestMethod]
        public void ExpectGettingRequestObjectToWorkCorrect()
        {
            const string ValidUrl = "http://testsite.com/";
            WebRequest request = new WebHelper().GetRequest(ValidUrl);
            Assert.AreEqual(ValidUrl, request.RequestUri.ToString());
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
