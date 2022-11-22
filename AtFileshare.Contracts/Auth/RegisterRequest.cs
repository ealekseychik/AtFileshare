﻿namespace AtFileshare.Contracts.Auth
{
    public record RegisterRequest(
        string UserName,
        string Email,
        string Password,
        string InviteCode);
}
