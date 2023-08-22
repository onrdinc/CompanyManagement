using Microsoft.EntityFrameworkCore;
using ToDo.Model.Entities;

namespace ToDo.DataAccess.EF.Contexts
{
    public class ToDoContext : DbContext
    {
        //private readonly IConfiguration _configuration;

        //public ToDoContext(IConfiguration configuration)
        //{
        //    _configuration = configuration;
        //}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //_configuration.GetConnectionString("ToDoConnStr");
            //optionsBuilder.UseSqlServer();
            optionsBuilder.UseSqlServer("server=.\\SQLEXPRESS;database=ToDo;trusted_connection=true;");
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobParticipant> JobParticipants { get; set; }
        public DbSet<Label> Labels { get; set; }
        public DbSet<Statu> Status { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<ProjectParticipant> ProjectParticipants { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
