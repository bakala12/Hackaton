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
// ReSharper disable InconsistentNaming

namespace Hackaton.Controllers
{
    public class EventsController : Controller
    {
        private readonly EventService eventService = new EventService();
        

        // GET: Events
        public async Task<ActionResult> Index()
        {
            return View(await eventService.GetEventsDtoList());
        }

        public async Task<ActionResult> ForUser()
        {
            return View(await eventService.GetEventsDtoListForUser(User.Identity.GetUserId()));
        }

        //// GET: Events/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Event @event = await db.Events.FindAsync(id);
        //    if (@event == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(@event);
        //}

        //// GET: Events/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Events/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Name,Description,EventType,Date")] Event @event)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Events.Add(@event);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(@event);
        //}

        //// GET: Events/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Event @event = await db.Events.FindAsync(id);
        //    if (@event == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(@event);
        //}

        //// POST: Events/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Name,Description,EventType,Date")] Event @event)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(@event).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(@event);
        //}

        //// GET: Events/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Event @event = await db.Events.FindAsync(id);
        //    if (@event == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(@event);
        //}

        //// POST: Events/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Event @event = await db.Events.FindAsync(id);
        //    db.Events.Remove(@event);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
