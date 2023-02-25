using KhadimiEssa.Data.TableDb;
using KhadimiEssa.Data.TableDb.IntroductorySite;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace KhadimiEssa.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationDbUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<LogExption> LogExption { get; set; }
        public DbSet<RateDelget> RateDelget { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<DeviceId> DeviceIds { get; set; }
        public DbSet<NotifyClient> NotifyClients { get; set; }
        public DbSet<NotifyDelegt> NotifyDelegts { get; set; }
        public DbSet<Setting> Settings { get; set; }
        public DbSet<Copon> Copon { get; set; }
        public DbSet<CoponUsed> CoponUsed { get; set; }
        public DbSet<Advertisment> Advertisments { get; set; }
        public DbSet<SocialMedia> SocialMedias { get; set; }
        public DbSet<Questions> Questions { get; set; }
        public DbSet<SmsMessage> SmsMessages { get; set; }

        public DbSet<ConnectUser> ConnectUser { get; set; }
        public DbSet<Payment> Payments { get; set; }

        public DbSet<Messages> Messages { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<HistoryNotify> HistoryNotify { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<UserInvitation> UserInvitations { get; set; }
        public DbSet<OilStation> OilStations { get; set; }


        /// <summary>
        /// Section IntroductorySite
        /// </summary>
        public DbSet<IntroSetting> IntroSettings { get; set; }
        public DbSet<IntroContactUs> IntroContactUs { get; set; }
        public DbSet<CustomerOpinion> CustomerOpinions { get; set; }
        public DbSet<AppImg> AppImgs { get; set; }
        public DbSet<Advantage> Advantages { get; set; }
        public DbSet<AvailableTime> AvailableTimes { get; set; }
        public DbSet<Package> Packages { get; set; }
        public DbSet<PaymentMethod> paymentMethods { get; set; }
        public DbSet<Note> Notes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Package>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Note>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<Copon>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<CarBrand>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<OilStation>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<PaymentMethod>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<ContactUs>().HasQueryFilter(c => !c.IsDeleted);
            modelBuilder.Entity<ApplicationDbUser>().HasQueryFilter(c => !c.IsDeleted);
        }


    }
}
