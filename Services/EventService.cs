using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
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
        private readonly IMapper mapper;

        public EventService()
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserDto>();
                cfg.CreateMap<UserDto, User>();
                cfg.CreateMap<Event, EventDto>();
                cfg.CreateMap<EventDto, Event>();
                cfg.CreateMap<TreeDto, TreeDto>();
                cfg.CreateMap<Tree, TreeDto>();
            });
            mapper = config.CreateMapper();
        }

        public async Task<List<EventDto>> GetEventsDtoList()
        {
            return mapper.Map<List<Event>, List<EventDto>>(await context.Events.ToListAsync());
        }

    }
}
