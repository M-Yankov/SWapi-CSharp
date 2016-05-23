namespace SWapi_CSharpTests
{
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Runtime.Serialization;
    using System.Text;

    public class TestWebResponse : WebResponse
    {
        private string returnValue;

        public TestWebResponse(string returnValue)
        {
            this.returnValue = returnValue;
        }

        public override Stream GetResponseStream()
        {
            var bytes = Encoding.UTF8.GetBytes(this.returnValue).ToList();
            var memoryStream = new MemoryStream();
            bytes.ForEach(b => memoryStream.WriteByte(b));
            memoryStream.Seek(0, SeekOrigin.Begin);
            return memoryStream;
        }
    }
}
