using NobelBizTest.Console.Shared.WebServices.SampleAPI;

namespace NobelBizTest.Console.Feature.Topics
{
    public class Topics : ITopics
    {
        private readonly ISampleApiService _sampleApiService;
        public Topics(ISampleApiService sampleApiService)
        {
            _sampleApiService = sampleApiService;
        }

        public async Task<IEnumerable<string>> GetTopicsAsync()
        {
            var codingResources = await _sampleApiService.GetCodingResourcesAsync();

            var topics = codingResources
                .SelectMany(resource => resource.Topics)
                .Distinct();

            return topics;
        }
    }
}
