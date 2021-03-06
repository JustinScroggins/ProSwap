﻿using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using ProSwap.Data.OfferTypes;

namespace ProSwap.Data
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<Game> Games { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<AccountOffer> AccountOffers { get; set; }
        public DbSet<CurrencyOffer> CurrencyOffers { get; set; }
        public DbSet<ServiceOffer> ServiceOffers { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Conventions
                .Remove<PluralizingTableNameConvention>();

            modelBuilder
                .Configurations
                .Add(new IdentityUserloginConfiguration())
                .Add(new IdentityUserRoleConfiguration());

            modelBuilder.Entity<Game>()
                .HasMany(j => j.Offers)
                .WithRequired(e => e.Game)
                .HasForeignKey(i => i.GameID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Offer>().ToTable("Offer")
                .HasRequired(e => e.Game);

            modelBuilder.Entity<AccountOffer>()
                .HasRequired(e => e.Game);


            modelBuilder.Entity<CurrencyOffer>()
                .HasRequired(e => e.Game);


            modelBuilder.Entity<ServiceOffer>()
                .HasRequired(e => e.Game);
        }
    }

    public class IdentityUserloginConfiguration : EntityTypeConfiguration<IdentityUserLogin>
    {
        public IdentityUserloginConfiguration()
        {
            HasKey(iul => iul.UserId);
        }
    }

    public class IdentityUserRoleConfiguration : EntityTypeConfiguration<IdentityUserRole>
    {
        public IdentityUserRoleConfiguration()
        {
            HasKey(iur => iur.UserId);
        }
    }
}