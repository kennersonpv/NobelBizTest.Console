using Moq;

namespace NobelBizTest.Test.WebServices
{
    public class SampleApiTest
    {
        private readonly Mock<HttpClient> _httpClientMock;
        public SampleApiTest()
        {
            _httpClientMock = new Mock<HttpClient>();
        }


    }
}
