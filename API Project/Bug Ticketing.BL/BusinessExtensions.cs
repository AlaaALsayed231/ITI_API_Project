using Bug_Ticketing.BL.Managers.Attachments;
using Bug_Ticketing.BL.Managers.Projects;
using Bug_Ticketing.BL.Managers.Users;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.BL
{
    public static class BusinessExtensions
    {
        public static void AddBusinessServices(
       this IServiceCollection services)
        {
            services.AddScoped<IProjectManager, ProjectManager>();
            services.AddScoped<IBugManger, BugManger>();
            services.AddScoped<IUserManger, UserManger>();
            services.AddScoped<IAttachmentManager, AttachmentManager>();
        }
    }
}
