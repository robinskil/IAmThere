using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IAmThereApi.DAO;
using IAmThereApi.Helpers;
using IAmThereApi.Models;
using IAmThereApi.Repository;
using IAmThereApi.RequestModels;

namespace IAmThereApi.Services
{
    public interface IUserService
    {
        bool AddUser(UserRegisterModel userRegisterModel);
        bool RemoveUser(string email , string password);
        bool UserEmailAvailable(string email);
    }

    public class UserService : IUserService
    {
        private IUserRepository UserRepository { get; }
        public UserService(DataContext dataContext)
        {
            UserRepository = new UserRepository(dataContext);
        }
        public bool AddUser(UserRegisterModel userRegisterModel)
        {
            if (userRegisterModel != null)
            {
                User user = RegisterModelToUser(userRegisterModel);
                if (user != null && UserEmailAvailable(user.Email))
                {
                    user.Password = Hasher.GetHashedString(user.Password);
                    UserRepository.AddEntity(user);
                    UserRepository.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public bool RemoveUser(string email, string password)
        {
            User user = UserRepository.GetEntity(u => u.Email == email);
            if (user != null && Hasher.VerifyHash(password, user.Password))
            {
                UserRepository.Delete(user);
                UserRepository.SaveChanges();
                return true;
            }
            return false;
        }

        public bool UserEmailAvailable(string email)
        {
            return UserRepository.EmailAvailable(email);
        }

        private static User RegisterModelToUser(UserRegisterModel userRegisterModel)
        {
            return new User
            {
                Email = userRegisterModel.Email,
                Password = Hasher.GetHashedString(userRegisterModel.Password),
                Firstname = userRegisterModel.Firstname,
                Lastname = userRegisterModel.Lastname
            };
        }
    }
}
