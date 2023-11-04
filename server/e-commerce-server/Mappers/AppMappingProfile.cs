using AutoMapper;
using e_commerce_server;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<AccountModel, Account>().ReverseMap();
    }
}