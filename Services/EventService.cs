using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Mvc;
using Hackaton.DataAccess;
using Hackaton.DataAccess.Entities;
using Shared.Dtos;
// ReSharper disable InconsistentNaming

namespace Services
{
    public class EventService
    {
        private readonly ApplicationDbContext context = new ApplicationDbContext();


        public async Task<List<EventDto>> GetEventsDtoList()
        {
            return AutoMapper.Instance.Map<List<Event>, List<EventDto>>(await context.Events.ToListAsync());
        }

        public async Task<List<EventDto>> GetEventsDtoListForUser(string userId)
        {
            var userEvents = await context.Events.Where(e => e.Participants.Any(u => u.Id == userId)).ToListAsync();
            return AutoMapper.Instance.Map<List<Event>, List<EventDto>>(userEvents);
        }

        public async Task<ActionResult> AddEvent(EventDto eventDto)
        {
            try
            {
                var @event = AutoMapper.Instance.Map<EventDto, Event>(eventDto);
                context.Events.Add(@event);
                await context.SaveChangesAsync();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            try
            {
                var @event = await context.Events.FindAsync(id);
                context.Events.Remove(@event);
                await context.SaveChangesAsync();
                return new HttpStatusCodeResult(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }
    }
}
