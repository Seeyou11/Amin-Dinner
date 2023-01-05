using System;
using AminDinner.Application.Common.Interfaces.Services;

namespace AminDinner.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
