using BlogCore.Data;
using BlogCore.Entities;
using BlogCore.Ports.Repositories;
using BlogCore.Ports.Repositories.UserRepositories;
using System;
using System.Collections.Generic;
using System.Linq;



namespace BlogCore.Adapters.Repositories
{
    public class UserRepository : IUserRepository<User>
    {
        
        private readonly DataContext _context;

        public UserRepository(DataContext context)
        {
            _context = context;
            _context.Set<User>();
        }

        public User GetByUsername(string username)
        {
            return _context.User.FirstOrDefault(user => user.Username == username);
        }

        void IRepository<User>.DeleteById(User entity)
        {
            _context.User.Remove(entity);
            _context.SaveChanges();
        }

        IEnumerable<User> IRepository<User>.GetAll()
        {
            return _context.User.ToList();
        }

        User IRepository<User>.GetById(Guid id)
        {
            return _context.User.Find(id);
        }

        void IRepository<User>.Save(User user)
        {
            _context.User.Add(user);
            _context.SaveChanges();
        }

        void IRepository<User>.UpdateById(User entity)
        {
            _context.User.Update(entity);
            _context.SaveChanges(true);
        }
    }
}
