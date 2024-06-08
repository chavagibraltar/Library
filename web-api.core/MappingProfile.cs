using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using web_api.core.Dtos;
using web_api.Core.Entities;

namespace web_api.core
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Branch, BranchDto>().ReverseMap();
            CreateMap<Client, ClientDto>().ReverseMap();
        }
    }
}
