using Core.Entities;
using Infrastructure.Migrations;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace Infrastructure
{

    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options)
        : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<admin>().Property(x => x.Id).HasDefaultValueSql("NEWID()");
            modelBuilder.Entity<research>().Property(x => x.Id).HasDefaultValueSql("NEWID()");


            modelBuilder.Entity<admin>().HasData(
                new admin()
                {
                    Id=Guid.NewGuid(),
                    FullName= "Dr.Huda Naji Nawaf Al-Mamory",
                    field = "Social Networks & recommender system",
                    Email = "huda.almamory@uobabylon.edu.iq",
                    Avatar = "huda4.jpg",
                    about = "Huda Naji graduated from Baghdad University with a BSc in statistical science.She qualified to undertake a Master's program in computer science and received a Master of Science in computer science from the Faculty of Science at Babylon University after successfully completing a three-month qualifying course in computer science.After completing a 6-month research program titled Computation model for social network at Liverpool John Moores University in the school of computing and mathematical sciences in 2012, she went on to receive her Ph. D. in Data mining of Social networks and the recommender systems from the Faculty of Science of Babylon University in 2014.She is currently a professor in the Babylon University Faculty of Information technology  information networks department.Her research interests include recommender systems and data mining in online social networks"

                }
                );

        }
        public DbSet<ApplicationUser> users { get; set; }

        public DbSet<admin> admins { get; set; }
        public DbSet<research> researches { get; set; }

        public DbSet<Core.Entities.Comments> comments { get; set; }

        public DbSet<VisitorCount>  visitorCounts { get; set; }




    }
}
