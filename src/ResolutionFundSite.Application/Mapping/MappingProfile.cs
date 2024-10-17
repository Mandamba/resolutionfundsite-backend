using AutoMapper;
using ResolutionFundSite.Application.DTOs.Response;
using ResolutionFundSite.Domain.Entities;

namespace ResolutionFundSite.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Comment, CommentResponse>().ReverseMap();
        }
    }
}
