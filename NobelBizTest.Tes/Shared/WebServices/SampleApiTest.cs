using Moq;
using Moq.Protected;
using NobelBizTest.Console.Shared.WebServices.SampleAPI;
using NobelBizTest.Tes.Fixtures;
using System.Text;
using System.Text.Json;

namespace NobelBizTest.Test.Shared.WebServices
{
    public class SampleApiTest
    {
        private readonly Mock<HttpMessageHandler> _httpMessageHandler;
        private readonly HttpClient _httpClient;
        private readonly ISampleApiService _sampleApiService;

        public SampleApiTest()
        {
            _httpMessageHandler = new Mock<HttpMessageHandler>();
            _httpClient = new HttpClient(_httpMessageHandler.Object);
            _httpClient.BaseAddress = new Uri("https://api.sampleapis.com/");
            _sampleApiService = new SampleApiService(_httpClient);
        }

        [Fact]
        public async void Get_OnSuccess_ReturnsCodingResources()
        {
            string jsonString = JsonSerializer.Serialize(CodingResourcesFixture.GetCodingResourcesMock());
            var content = new StringContent(jsonString, Encoding.UTF8, "application/json");

            var expectedResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.OK,
                Content = content,
            };

            _httpMessageHandler.Protected()
                    .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(expectedResponse);

            var result = await _sampleApiService.GetCodingResourcesAsync();

            Assert.Equal(result.FirstOrDefault().Id, CodingResourcesFixture.GetCodingResourcesMock().FirstOrDefault().Id);
        }

        [Fact]
        public async void Get_OnStatus404_ReturnsException()
        {
            var expectedResponse = new HttpResponseMessage
            {
                StatusCode = System.Net.HttpStatusCode.NotFound
            };

            _httpMessageHandler.Protected()
                    .Setup<Task<HttpResponseMessage>>("SendAsync", ItExpr.IsAny<HttpRequestMessage>(), ItExpr.IsAny<CancellationToken>())
                    .ReturnsAsync(expectedResponse);

            await Assert.ThrowsAsync<Exception>(() => _sampleApiService.GetCodingResourcesAsync());
        }
    }
}
