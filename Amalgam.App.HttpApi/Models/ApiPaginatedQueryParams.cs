using Amalgam.Core.Contracts.Repositories.Parameters;

namespace Amalgam.App.HttpApi.Models
{
    public class ApiPaginatedQueryParams
    {
        public int O { get; set; }
        public int Q { get; set; }

        public PaginatedQueryParams ToQueryParams()
            => new PaginatedQueryParams(O, Q);
    }
}