using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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

    }
}
