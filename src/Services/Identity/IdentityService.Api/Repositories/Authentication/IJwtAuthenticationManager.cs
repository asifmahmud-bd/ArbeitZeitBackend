using System;
using IdentityService.Api.Entities;
using IdentityService.Application.Domain;

namespace IdentityService.Api.Repositories.Authentication
{
    public interface IJwtAuthenticationManager
    {
        string Authenticate(LoginCredential credential, User user);
    }
}
