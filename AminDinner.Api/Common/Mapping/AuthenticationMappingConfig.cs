
using AminDinner.Application.Authentication.Commands.Register;
using AminDinner.Application.Authentication.Common;
using AminDinner.Application.Authentication.Queries.Login;
using AminDinner.Contracts.Authentication;
using Mapster;

namespace AminDinner.Api.Common.Mapping;

public class AuthenticationMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<RegisterRequest, RegisterCommand>();
        config.NewConfig<LoginRequest, LoginQuery>();
        config.NewConfig<AuthenticationResult, AuthenticationResponse>()
        .Map(dest => dest, src => src.User);
    }
}
