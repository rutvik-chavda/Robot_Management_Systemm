using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using RobotManagementSystem.IdentityAuth;
using RobotManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RobotManagementSystem.Dbcontext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
     public DbSet<Robot> Robots { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Robot>().HasData(
                new Robot() { Id = 1, robotName = "GlimmerGear", ownerName = "sahil", firmwareVersion = 1.1f, location = "Ahmedabad" },
                new Robot() { Id = 2, robotName = "SprinkleBolt", ownerName = "Sahil", firmwareVersion = 2.3f, location = "Pune" },
                new Robot() { Id = 3, robotName = "FluffyByte", ownerName = "Sahil", firmwareVersion = 1.0f, location = "Indore" },
                new Robot() { Id = 4, robotName = "PeppyPivot", ownerName = "Ayush", firmwareVersion = 2.1f, location = "Ahmedabad" },
                new Robot() { Id = 5, robotName = "BeepBoo", ownerName = "Ayush", firmwareVersion = 2.4f, location = "Pune" },
                new Robot() { Id = 6, robotName = "SpannerSpender", ownerName = "Ayush", firmwareVersion = 1.1f, location = "Indore" },
                new Robot() { Id = 7, robotName = "ByteMite", ownerName = "viral", firmwareVersion = 2.1f, location = "Ahmedabad" },
                new Robot() { Id = 8, robotName = "GigaGiggles", ownerName = "viral", firmwareVersion = 2.4f, location = "Pune" },
                new Robot() { Id = 9, robotName = "RompBot", ownerName = "viral", firmwareVersion = 3.4f, location = "Indore" },
                new Robot() { Id = 10, robotName = "GearLoose", ownerName = "rohan", firmwareVersion = 2.5f, location = "Ahmedabad" });

        }
    }
}
