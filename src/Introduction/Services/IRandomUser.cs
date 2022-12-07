using Introduction.Models;
using Refit;

namespace Introduction.Services
{
    public interface IRandomUser
    {
        [Get("/api/")]
        Task<Response> GetUsers(
            string seed,
            string format = "json",
            int page = 1,
            [AliasAs("results")] int pageSize = 25);
    }
}
