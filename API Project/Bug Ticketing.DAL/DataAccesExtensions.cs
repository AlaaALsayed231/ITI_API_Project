using Bug_Ticketing.DAL.Context;
using Bug_Ticketing.DAL.Models;
using Bug_Ticketing.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Bug_Ticketing.DAL
{
    public static class DataAccesExtensions
    {
        public static void AddDataAccesServices(this IServiceCollection services, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("Conn");
            services.AddDbContext<BugTicketingDBContext>(options => options


            .UseSqlServer(connection));

            services.AddScoped<IProjectRepo, ProjectRepo>();
            services.AddScoped<IBugRepo, BugRepo>();
            services.AddScoped<IUserRepo, UserRepo>();
            services.AddScoped<IAttachmentRepo, AttachmentRepo>();
            services.AddScoped<IUnitOfWork,UnitOfWork>();

        }
    }
}
