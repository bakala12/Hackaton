using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Hackaton.DataAccess;
using Hackaton.DataAccess.Entities;
using Services;
using Shared.Dtos;

namespace Hackaton.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserService userService = new UserService();       

        // GET: Users/Edit/5
        public async Task<ActionResult> Edit(UserDto userDto)
        {
            return await userService.UpdateUser(userDto);
        }     
    }
}
