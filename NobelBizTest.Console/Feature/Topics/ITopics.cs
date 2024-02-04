namespace NobelBizTest.Console.Feature.Topics
{
    internal interface ITopics
    {
        Task<IEnumerable<string>> GetTopicsAsync();
    }
}
