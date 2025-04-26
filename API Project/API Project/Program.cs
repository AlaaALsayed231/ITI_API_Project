
using Bug_Ticketing.BL;
using Bug_Ticketing.DAL;
using Bug_Ticketing.DAL.Context;
using Bug_Ticketing.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace API_Project
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();


            //Service:
            //builder.Services.AddDataAccesServices(builder.Configuration);
            //builder.Services.AddScoped<IProjectRepo, ProjectRepo>();


            builder.Services.AddBusinessServices();

            builder.Services.AddDataAccesServices(builder.Configuration);
            builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<BugTicketingDBContext>()
    .AddDefaultTokenProviders();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
