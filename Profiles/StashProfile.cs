using AutoMapper;
using SLAMobileApi.DomainModels;
using SLAMobileApi.Dtos;

namespace SLAMobileApi.Profiles;

public class StashProfile : Profile
{
    public StashProfile()
    {
        CreateMap<CreateStashInputModel, Stash>();
    }
}