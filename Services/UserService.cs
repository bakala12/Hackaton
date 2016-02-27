using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;
using Hackaton.DataAccess;
using Hackaton.DataAccess.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Shared.Dtos;

namespace Services
{
    public class UserService
    {
        // ReSharper disable once InconsistentNaming
        private readonly ApplicationDbContext context = new ApplicationDbContext();

        public async Task<ActionResult> UpdateUser(UserDto userDto)
        {
            var userStore = new UserStore<User>(context);
            var userManager = new UserManager<User>(userStore);
            var user = AutoMapper.Instance.Map<UserDto, User>(userDto);
            await userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
            return new HttpStatusCodeResult(HttpStatusCode.OK);
        }
    }
}