
using AminDinner.Domain.Entities;

namespace AminDinner.Application.Common.Interfaces.Persistance;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void Add(User user);
}
