using Bug_Ticketing.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Ticketing.DAL.Context
{
    public class BugTicketingDBContext: IdentityDbContext<User>
    {
        public DbSet<Project> Projects => Set<Project>();
        public DbSet<Bug> Bugs => Set<Bug>();
        public DbSet<User> Users => Set<User>();
        public DbSet<Attachment> Attachments => Set<Attachment>();


        public BugTicketingDBContext(DbContextOptions<BugTicketingDBContext> options)
            :base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bug>()
           .HasMany(b => b.Users)
            .WithMany(u => u.Bugs);

            modelBuilder.Entity<Bug>()
          .HasMany(b => b.Attachments)
          .WithOne(a => a.Bug)  
          .HasForeignKey(a => a.BugId);

        }


    }
    
}
