
using AminDinner.Application.Authentication.Common;
using AminDinner.Application.Common.Interfaces.Authentication;
using AminDinner.Application.Common.Interfaces.Persistance;
using AminDinner.Domain.Entities;
using ErrorOr;
using MediatR;

namespace AminDinner.Application.Authentication.Commands.Register;

//----------------------------------------------------<recieve the command that handle, the response that will returning>
public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }


    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        await Task.CompletedTask;
        // 1. Validate the user doesn't exists

        if (_userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Domain.Common.Errors.Errors.User.DuplicateEmail;
        }

        // 2. Create user(generate unique ID) and Persist (save) to DB

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            Password = command.Password
        };

        _userRepository.Add(user);

        // 3. Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
           user,
           token
       );
    }
}
