using BlogCore.Entities;

namespace BlogCore.Ports.Services
{
    public interface IAuthService
    {
        public User Login(User user);
        public void Register(User user);
    }
}
