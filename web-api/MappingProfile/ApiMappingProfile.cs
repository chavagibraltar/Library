using AutoMapper;
using web_api.Core.Entities;
using web_api.Models;

namespace web_api.MappingProfile
{
    public class ApiMappingProfile:Profile
    {
        public ApiMappingProfile()
        {
            CreateMap<BookPostModel, Book>().ReverseMap();
            CreateMap<BranchPostModel, Branch>().ReverseMap();
            CreateMap<ClientPostModel, Client>().ReverseMap();
        }
    }
}
