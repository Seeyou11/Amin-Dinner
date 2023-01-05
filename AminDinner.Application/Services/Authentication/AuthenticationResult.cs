
using System;
using AminDinner.Domain.Entities;

namespace AminDinner.Application.Services.Authentication;

public record AuthenticationResult
(
    User user,
    string Token
);
