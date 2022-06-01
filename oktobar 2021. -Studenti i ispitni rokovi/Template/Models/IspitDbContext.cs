using Microsoft.EntityFrameworkCore;
using Template.Models;

namespace Template.Models
{
    public class IspitDbContext : DbContext
    {
        public DbSet<Predmet> Predmet{get;set;}
        public DbSet<Student> Student{get;set;}
        public DbSet<StudentPredmet> StudentPredmet {get;set;}
        public DbSet<IspitniRok> IspitniRok {get;set;}
// DbSet...

        public IspitDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
