using NobelBizTest.Console.Shared.WebServices.SampleAPI.Response;
using System.Net.Http.Headers;

namespace NobelBizTest.Console.Shared.WebServices.SampleAPI
{
    public class SampleApiService : ISampleApiService
    {
        static HttpClient _httpClient = new HttpClient();
        public SampleApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<CodingResourcesResponse>> GetCodingResourcesAsync()
        {
            var codingResourcesEndpoint = "codingresources/codingResources";

            try
            {
                var response = await _httpClient.GetAsync(codingResourcesEndpoint);
                if(response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadAsAsync<IEnumerable<CodingResourcesResponse>>();
                }
                else
                {
                    throw new HttpRequestException($"Status Code: {(int)response.StatusCode} Exception: {response.StatusCode}");
                }
                
            }
            catch (HttpRequestException ex)
            {
                throw new Exception($"Exception: {ex.Message}");
            }
        }
    }
}
