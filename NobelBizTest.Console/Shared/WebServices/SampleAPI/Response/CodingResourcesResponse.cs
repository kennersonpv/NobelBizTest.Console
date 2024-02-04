using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NobelBizTest.Console.Shared.WebServices.SampleAPI.Response
{
    public class CodingResourcesResponse
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public List<string> Types { get; set; }
        public List<string> Topics { get; set; }
        public List<string> levels { get; set; }
    }
}
