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
using Services;
using Shared.Dtos;

// ReSharper disable InconsistentNaming

namespace Hackaton.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventService eventService = new EventService();
        private readonly TreeService treeService = new TreeService();
        

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
            await eventService.AddEvent(eventDto);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<ActionResult> CreatePageNearTree(int id)
        {
            var eventDto = new EventDto();
            eventDto.Tree = await treeService.GetTree(id);
            return View(eventDto);
        }
    }
}
