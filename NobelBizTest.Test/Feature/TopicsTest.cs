using Moq;
using NobelBizTest.Console.Feature.Topics;
using NobelBizTest.Console.Shared.WebServices.SampleAPI;
using NobelBizTest.Console.Shared.WebServices.SampleAPI.Response;

namespace NobelBizTest.Test.Feature
{
    public class TopicsTests
    {
        private readonly Mock<ISampleApiService> _sampleApiServiceMock;
        private readonly Topics _topics;
        public TopicsTests()
        {
            _sampleApiServiceMock = new Mock<ISampleApiService>();
            _topics = new Topics(_sampleApiServiceMock.Object);
        }

        [Fact]
        public async Task Get_OnSuccess_GetTopicsList()
        {
            var expectedCodingResources = new List<CodingResourcesResponse>
            {
                new CodingResourcesResponse
                {
                    Topics = new List<string> { "Topic1", "Topic2" }
                }
            };

            _sampleApiServiceMock.Setup(service => service.GetCodingResourcesAsync())
                .ReturnsAsync(expectedCodingResources);

            var result = await _topics.GetTopicsAsync();

            Assert.NotNull(result);
            Assert.Collection(result,
                topic => Assert.Equal("Topic1", topic),
                topic => Assert.Equal("Topic2", topic)
            );
        }

        [Fact]
        public async Task Get_OnSuccess_EmptyResponse()
        {
            _sampleApiServiceMock.Setup(service => service.GetCodingResourcesAsync())
                .ReturnsAsync(new List<CodingResourcesResponse>());

            var result = await _topics.GetTopicsAsync();

            Assert.Empty(result);
        }

        [Fact]
        public async Task Get_OnError_GetException()
        {
            _sampleApiServiceMock.Setup(service => service.GetCodingResourcesAsync())
                .ThrowsAsync(new Exception("Simulated exception"));

            await Assert.ThrowsAsync<Exception>(() => _topics.GetTopicsAsync());
        }
    }
}
