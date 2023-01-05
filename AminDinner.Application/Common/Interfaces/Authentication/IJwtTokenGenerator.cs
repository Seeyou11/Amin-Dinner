
using System;
using AminDinner.Domain.Entities;

namespace AminDinner.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
