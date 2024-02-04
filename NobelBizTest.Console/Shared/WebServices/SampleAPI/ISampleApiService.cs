using NobelBizTest.Console.Shared.WebServices.SampleAPI.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NobelBizTest.Console.Shared.WebServices.SampleAPI
{
    public interface ISampleApiService
    {
        Task<IEnumerable<CodingResourcesResponse>> GetCodingResourcesAsync();
    }
}
