using Microsoft.EntityFrameworkCore;
using WebUITask.Models;
using WebUITask.Services.Abstracts;

namespace WebUITask.Services.Concrets
{
    public class UserRepository(DbContext context) : Repository<User>(context), IUserRepository
    {
    }
}
