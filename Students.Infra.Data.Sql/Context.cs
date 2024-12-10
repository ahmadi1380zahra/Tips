using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Students.Core.Domain;

namespace Students.Infra.Data.Sql
{
    public class ContextDesignTimeFactory : IDesignTimeDbContextFactory<Context>
    {
        public Context CreateDbContext(string[] args)
     => ContextFactory.GetSqlContext();
    }
    public class Context: DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Course> Courses { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Parent> Parents{ get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Course>().HasQueryFilter(c => c.IsDelete == false);
            base.OnModelCreating(modelBuilder);
        }
    }
}
