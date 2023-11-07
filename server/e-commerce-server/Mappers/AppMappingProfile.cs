using AutoMapper;
using e_commerce_server;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<AccountModel, Account>()
            .ForMember(dest => dest.Salt, opt => opt.Ignore())
            .ForMember(dest => dest.HashPassword, opt => opt.Ignore())
            .ForMember(dest => dest.Tokens, opt => opt.Ignore())
            .ReverseMap();
    }
}