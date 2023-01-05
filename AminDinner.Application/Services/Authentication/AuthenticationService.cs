
using System;
using AminDinner.Application.Common.Interfaces.Authentication;
using AminDinner.Application.Common.Interfaces.Persistance;
using AminDinner.Domain.Entities;

namespace AminDinner.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;

    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Register(string firstName, string lastName, string email, string password)
    {
        // 1. Validate the user doesn't exists

        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists.");
        }

        // 2. Create user(generate unique ID) and Persist (save) to DB

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.Add(user);

        // 3. Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
           user,
           token
       );
    }

    public AuthenticationResult Login(string email, string password)
    {
        // 1. Validate the user exists

        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email doesn't exists.");
        }

        // 2. Validate the password is correct

        if (user.Password != password)
        {
            throw new Exception("Invalid password");
        }

        // 3. Create JWT token

        var token = _jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token
        );
    }
}
