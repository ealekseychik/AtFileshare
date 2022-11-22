namespace AtFileshare.Application.Auth.Commands.Register
{
    using AtFileshare.Application.Auth.Common;
    using MediatR;

    public record RegisterCommand(
        string UserName,
        string Email,
        string Password,
        string InviteCode) : IRequest<AuthResult>;
}
