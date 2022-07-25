using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BlogCore.Entities;

namespace BlogCore.Ports.Repositories
{
    internal interface IUnitOfWork
    {
        IRepository<User> Users { get;}


        void Commit();

    }
}
