
using AminDinner.Domain.Entities;

namespace AminDinner.Application.Authentication.Common;

public record AuthenticationResult
(
    User User,
    string Token
);
