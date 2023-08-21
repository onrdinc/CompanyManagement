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

            services.AddScoped<ICompanyBs, CompanyBs>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();

            services.AddScoped<IUserBs, UserBs>();
            services.AddScoped<IUserRepository, UserRepository>();

            services.AddScoped<IProjectBs, ProjectBs>();
            services.AddScoped<IProjectRepository, ProjectRepository>();

            services.AddScoped<IDepartmentBs, DepartmentBs>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();

            services.AddScoped<ILabelBs, LabelBs>();
            services.AddScoped<ILabelRepository, LabelRepository>();

            services.AddScoped<IJobBs, JobBs>();
            services.AddScoped<IJobRepository, JobRepository>();

            services.AddScoped<IJobParticipantBs, JobParticipantBs>();
            services.AddScoped<IJobParticipantRepository, JobParticipantRepository>();

            services.AddScoped<IMilestoneBs, MilestoneBs>();
            services.AddScoped<IMilestoneRepository, MilestoneRepository>();

            services.AddScoped<IMilestoneJobBs, MilestoneJobBs>();
            services.AddScoped<IMilestoneJobRepository, MilestoneJobRepository>();

            services.AddScoped<IDepartmentBs, DepartmentBs>();
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();


            services.AddScoped<ICompanyTeamBs, CompanyTeamBs>();
            services.AddScoped<ICompanyTeamRepository, CompanyTeamRepository>();

            services.AddScoped<IAdminUserBs, AdminUserBs>();
            services.AddScoped<IAdminUserRepository, AdminUserRepository>();

            services.AddScoped<IServiceBs, ServiceBs>();
            services.AddScoped<IServiceRepository, ServiceRepository>();
        }
    }
}
