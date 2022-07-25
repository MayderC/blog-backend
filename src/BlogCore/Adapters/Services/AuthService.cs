using BlogCore.Entities;
using BlogCore.Ports.Repositories;
using BlogCore.Ports.Services;
using System;
using BlogCore.Ports.Repositories.UserRepositories;


namespace BlogCore.Adapters.Services
{
    public class AuthService : IAuthService
    {

        private readonly IUserRepository<User> _useRepository;
        public AuthService(IUserRepository<User> userRepository)
        {
            _useRepository = userRepository;
        }

        public User Login(User user)
        {
            var userById = _useRepository.GetByUsername(user.Username);
            if (userById == null || BCrypt.Net.BCrypt.Verify(user.Password, userById.Password) == false)
                throw new Exception("Invalid credentials");

            return userById;
        }

        public void Register(User user)
        {
            user.Id = Guid.NewGuid();
            user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var date = DateTime.Now;
            user.CreateDateTime = date;
            user.LastModifiedDateTime = date;

            _useRepository.Save(user);
        }
    }
}
