using AminDinner.Api.Common.Errors;
using AminDinner.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AminDinner.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, AminDinnerProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}
