using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.DAO;
using IAmThereApi.Models;

namespace IAmThereApi.Repository
{
    public interface IUserRepository : IRepository<User>
    {
        bool EmailAvailable(string email);
    }

    public class UserRepository : Repository<User> , IUserRepository
    {
        public UserRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public bool EmailAvailable(string email)
        {
            return !Context.Set<User>().Any(u => u.Email == email);
        }
    }
}
