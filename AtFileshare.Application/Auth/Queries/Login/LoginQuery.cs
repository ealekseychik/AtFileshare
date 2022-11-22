namespace AtFileshare.Application.Auth.Queries.Login
{
    using AtFileshare.Application.Auth.Common;
    using MediatR;

    public record LoginQuery(
        string Email,
        string Password) : IRequest<AuthResult>;
}
