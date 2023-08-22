using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Business.Implementations;
using ToDo.Business.Interfaces;
using ToDo.Business.Profiles;
using ToDo.DataAccess.EF.Repositories;
using ToDo.DataAccess.Interfaces;
using ToDo.Model.Entities;

namespace ToDo.Business
{
    public static class ServiceCollectionExtensions
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(UserProfile));



            services.AddScoped<IUserBs, UserBs>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IProjectBs, ProjectBs>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IProjectParticipantBs, ProjectParticipantBs>();
            services.AddScoped<IProjectParticipantRepository, ProjectParticipantRepository>();

            services.AddScoped<IDepartmentBs, DepartmentBs>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped<ILabelBs, LabelBs>();
            services.AddScoped<ILabelRepository, LabelRepository>();

            services.AddScoped<IJobBs, JobBs>();
            services.AddScoped<IJobRepository, JobRepository>();


            services.AddScoped<IStatuBs, StatuBs>();
            services.AddScoped<IStatuRepository, StatuRepository>();


            services.AddScoped<IDepartmentBs, DepartmentBs>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();



            services.AddScoped<IAdminUserBs, AdminUserBs>();
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();

            services.AddScoped<IServiceBs, ServiceBs>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }
    }
}
