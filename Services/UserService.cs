using System.Net.Http;
using System.Threading.Tasks;
using Hackaton.DataAccess;

namespace Services
{
    public class UserService
    {
        // ReSharper disable once InconsistentNaming
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public async Task GetUsersEvents()
        {
            try
            {

            }
            catch (HttpRequestException)
            {
            }
        }
    }
}