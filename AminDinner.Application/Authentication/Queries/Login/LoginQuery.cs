
using AminDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace AminDinner.Application.Authentication.Queries.Login;

public record LoginQuery
(
string Email,
string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
//the data that we need : this is what this command return
