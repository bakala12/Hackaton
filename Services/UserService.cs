﻿using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
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

        //public async Task<ActionResult> UpdateUser(UserDto userDto)
        //{
        //    var userStore = new UserStore<User>(context);
        //    var userManager = new UserManager<User>(userStore);
        //    var user = AutoMapper.Instance.Map<UserDto, User>(userDto);
        //    await userManager.UpdateAsync(user);
        //    await context.SaveChangesAsync();
        //    return new HttpStatusCodeResult(HttpStatusCode.OK);
        //}

        public async Task<UserDto> GetUser(string id)
        {
            var user = await context.Users.FirstAsync(u => u.ApplicationUserId == id);
            return AutoMapper.Instance.Map<User, UserDto>(user);
        }

        public void RegisterUser(string id, string name, string surname)
        {
            var user = new User()
            {
                Name = name,
                Surname = surname,
                ApplicationUserId = id
            };
            context.Users.Add(user);
            context.SaveChanges();
        }
    }
}