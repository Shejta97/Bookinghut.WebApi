using AutoMapper;
using Bookinghun.Models;
using Bookinghun.Models.Request;
using Bookinghut.Models;
using Bookinghut.Models.Request;
using Bookinghut.WebApi.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookinghut.WebApi.Mapper
{
    public class BookinghutProfile : Profile
    {
        public BookinghutProfile()
        {
            CreateMap<Event, MEvents>();
            CreateMap<Event, EventUpsertRequest>().ReverseMap();

            CreateMap<User, MUser>();
            CreateMap<User, UserUpsertRequestdto>().ReverseMap();
        }
    }
}
