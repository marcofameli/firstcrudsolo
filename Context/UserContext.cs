using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUD.Entities;
using Microsoft.EntityFrameworkCore;

namespace CRUD.Context
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {}

        public DbSet <User> Users { get; set; }        
        
    }
}