using Microsoft.Extensions.DependencyInjection;
using NobelBizTest.Console.Feature.Topics;
using NobelBizTest.Console.Shared.WebServices.SampleAPI;
using System.Net.Http.Headers;

class Program
{
    static async Task Main(string[] args)
    {
        var services = new ServiceCollection();

        services.AddHttpClient<ISampleApiService, SampleApiService>(client =>
        {
            client.BaseAddress = new Uri("https://api.sampleapis.com/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        });
        services.AddScoped<ITopics, Topics>();

        using (var serviceProvider = services.BuildServiceProvider())
        {
            var topicsService = serviceProvider.GetRequiredService<ITopics>();

            var topics = await topicsService.GetTopicsAsync();

            foreach (var topic in topics)
            {
                await Console.Out.WriteLineAsync(topic);
            }
        }
    }
}