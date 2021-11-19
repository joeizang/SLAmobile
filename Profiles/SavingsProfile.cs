using AutoMapper;
using SLAMobileApi.DomainModels;
using SLAMobileApi.Dtos;

namespace SLAMobileApi.Profiles;

public class SavingsProfile : Profile
{
    public SavingsProfile()
    {
        CreateMap<CreateSavingsInputModel, Savings>();
    }
}