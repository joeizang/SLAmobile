using AutoMapper;
using SLAMobileApi.DomainModels;
using SLAMobileApi.Dtos;

namespace SLAMobileApi.Profiles;

public class ChallengeProfile : Profile
{
    public ChallengeProfile()
    {
        CreateMap<CreateChallengeInputModel, Challenge>();
    }
}