﻿using BlogCore.Entities;
using Microsoft.EntityFrameworkCore;


namespace BlogCore.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options) { }

        public DbSet<User> User { get; set; }

    }
}
