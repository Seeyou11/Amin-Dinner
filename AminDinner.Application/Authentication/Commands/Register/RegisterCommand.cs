
using AminDinner.Application.Authentication.Common;
using ErrorOr;
using MediatR;

namespace AminDinner.Application.Authentication.Commands.Register;

public record RegisterCommand
(
string FirstName,
string LastName,
string Email,
string Password
) : IRequest<ErrorOr<AuthenticationResult>>;
//the data that we need : this is what this command return