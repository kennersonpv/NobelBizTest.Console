using NobelBizTest.Console.Shared.WebServices.SampleAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelBizTest.Tes.Fixtures
{
    public static class CodingResourcesFixture
    {
        public static IEnumerable<CodingResourcesResponse> GetCodingResourcesMock()
        {
            return new[]
            {
                new CodingResourcesResponse()
                {
                    Id = 1,
                    Description = "South Florida's Best Meetups on Youtube",
                    Url = "https://www.youtube.com/bocajs",
                    Types = new List<string>()
                    {
                        "tutorial"
                    },
                    Topics = new List<string>()
                    {
                        "js",
                        "html"
                    },
                    levels = new List<string>()
                    {
                        "beginner",
                        "intermediate",
                        "advanced"
                    }
                },
                new CodingResourcesResponse()
                {
                    Id = 2,
                    Description = "BocaJS - South Florida's Largest Developer Meetup",
                    Url = "https://Meetup.com/bocajs",
                    Types = new List<string>()
                    {
                        "tutorial"
                    },
                    Topics = new List<string>()
                    {
                        "js",
                        "html"
                    },
                    levels = new List<string>()
                    {
                        "beginner",
                        "intermediate",
                        "advanced"
                    }
                }
            };
        }
    }
}
