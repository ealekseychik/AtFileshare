namespace AtFileshare.API.Common.Mapping
{
    using AtFileshare.Application.Auth.Common;
    using AtFileshare.Contracts.Auth;
    using AutoMapper;

    public class AuthMappingConfig : Profile
    {
        public AuthMappingConfig()
        {
            CreateMap<AuthResult, AuthResponse>()
                .ForMember(dest => dest, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.Token, opt => opt.MapFrom(src => src.Token));
        }
    }
}
