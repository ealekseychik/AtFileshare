namespace AtFileshare.API.Common.Mapping
{
    using AtFileshare.Application.Auth.Commands.Register;
    using AtFileshare.Application.Auth.Common;
    using AtFileshare.Application.Auth.Queries.Login;
    using AtFileshare.Contracts.Auth;
    using AtFileshare.Domain.Entities;
    using AutoMapper;

    public class AuthMappingConfig : Profile
    {
        public AuthMappingConfig()
        {
            CreateMap<RegisterRequest, RegisterCommand>();
            CreateMap<LoginRequest, LoginQuery>();

            CreateMap<User, AuthResponse>();

            // https://stackoverflow.com/a/74555743/11278567
            CreateMap<AuthResult, AuthResponse>()
                .AfterMap((src, dest, context) => context.Mapper.Map(src.User, dest));
        }
    }
}
