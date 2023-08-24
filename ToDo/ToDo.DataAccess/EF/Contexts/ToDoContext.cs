using Microsoft.EntityFrameworkCore;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.EF.Contexts
{
    public class ToDoContext : DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=ToDo;trusted_connection=true;");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Statu> Status { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ProjectParticipant> ProjectParticipants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
        public DbSet<Wage> Wages { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}
