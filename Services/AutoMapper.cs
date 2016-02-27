using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Hackaton.DataAccess.Entities;
using Shared.Dtos;

// ReSharper disable InconsistentNaming

namespace Services
{

    public static class AutoMapper
    {
        private static volatile IMapper instance;
        private static readonly object syncRoot = new object();

        public static IMapper Instance
        {
            get
            {
                if (instance != null) return instance;
                lock (syncRoot)
                {
                    if (instance != null) return instance;
                    var config = new MapperConfiguration(cfg =>
                    {
                        cfg.CreateMap<User, UserDto>();
                        cfg.CreateMap<UserDto, User>();
                        cfg.CreateMap<Event, EventDto>();
                        cfg.CreateMap<EventDto, Event>();
                        cfg.CreateMap<TreeDto, TreeDto>();
                        cfg.CreateMap<Tree, TreeDto>();
                    });
                    instance = config.CreateMapper();
                }

                return instance;
            }
        }
    }
}
