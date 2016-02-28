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
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Services;
using Shared.Dtos;
using AutoMapper = Services.AutoMapper;

// ReSharper disable InconsistentNaming

namespace Hackaton.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventService eventService = new EventService();
        private readonly TreeService treeService = new TreeService();
        private readonly UserService userService = new UserService();

        // GET: Events
        public async Task<ActionResult> Index()
        {
            return View(await eventService.GetEventsDtoList());
        }
        [HttpGet]
        public async Task<ActionResult> ForUser()
        {
            return View(await eventService.GetEventsDtoListForUser(User.Identity.GetUserId()));
        }

        [HttpPost]
        public async Task<ActionResult> CreatePageNearTree(EventDto eventDto)
        {
            // to jest zjebane, ale dziala, w eventDto.Id jest id drzewa
            eventDto.Tree = await treeService.GetTree(eventDto.Id);
            Event @event = Services.AutoMapper.Instance.Map<EventDto, Event>(eventDto);
            var user = await userService.GetUser(User.Identity.GetUserId());
            eventDto.Organizer = user;
            eventDto.Participants = new List<UserDto> {user};
            await eventService.AddEvent(eventDto);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<ActionResult> CreatePageNearTree(int id)
        {
            var eventDto = new EventDto();
            eventDto.Tree = await treeService.GetTree(id);
            return View(eventDto);
        }

        [HttpPost]
        public bool IsEventInTree(int treeId)
        {
            var result= treeService.IsEventInTree(treeId);
            return result;
        }

        [HttpPost]
        public async Task<ActionResult> Join(int treeId)
        {
            return await eventService.JoinEvent(User.Identity.GetUserId(), treeId);
        }
    }
}
