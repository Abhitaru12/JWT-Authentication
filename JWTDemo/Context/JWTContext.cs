using JWTDemo.Model;
using Microsoft.EntityFrameworkCore;

namespace JWTDemo.Context
{
    public class JWTContext : DbContext
    {
        public JWTContext(DbContextOptions<JWTContext> options) : base(options) 
        {
            
        }

        public DbSet<User> Users { get; set; }  

        public DbSet<Employee> Employees { get; set; }  
    }
}
