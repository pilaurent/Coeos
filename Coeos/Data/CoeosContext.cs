using Coeos.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Coeos.Data
{
    public class CoeosContext : IdentityDbContext
    {
        public CoeosContext(DbContextOptions<CoeosContext> options)
            : base(options)
        {
        }

        public DbSet<Intervention> Intervention { get; set; }
        public DbSet<Agent> Agent { get; set; }

        public DbSet<Lieu> Lieu { get; set; }
        public DbSet<Photo> Photo { get; set; }
        public DbSet<Societe> Societe { get; set; }
        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<AgentIntervention> AgentInterventions { get; set; }

        public DbSet<ApplicationUser> ApplicationUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<AgentIntervention>()
                .HasKey(c => new { c.AgentID, c.InterventionID });

           // modelBuilder.Entity<Categorie>()
                //.HasMany(c => c.Interventions)
             //   .WithOne(e => e.Categorie)
         //       .IsRequired();
        }


    }
}
