namespace BlogCore.Ports.Repositories.UserRepositories
{
    public interface IUserRepository<T> : IRepository<T> where T : class
    {

        T GetByUsername(string username);
         
    }
}
