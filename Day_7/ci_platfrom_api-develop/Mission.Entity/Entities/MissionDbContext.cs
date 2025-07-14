using Microsoft.EntityFrameworkCore;
using System;

namespace Mission.Entity.Entities
{
    public class MissionDbContext(DbContextOptions<MissionDbContext> options) : DbContext(options)
    {
        public DbSet<User> User { get; set; }
        public DbSet<UserDetail> UserDetail { get; set; }
        public DbSet<ForgotPassword> ForgotPassword { get; set; }
        public DbSet<CMS> CMS { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Missions> Missions { get; set; }
        public DbSet<Story> Story { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<VolunteeringHours> VolunteeringHours { get; set; }
        public DbSet<VolunteeringGoals> VolunteeringGoals { get; set; }
        public DbSet<MissionApplication> MissionApplication { get; set; }
        public DbSet<UserSkills> UserSkills { get; set; }
        public DbSet<MissionTheme> MissionTheme { get; set; }
        public DbSet<MissionSkill> MissionSkill { get; set; }
        public DbSet<MissionComment> MissionComment { get; set; }
        public DbSet<MissionFavourites> MissionFavourites { get; set; }
        public DbSet<MissionRating> MissionRating { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            builder.Entity<User>().HasData(new User()
            {
                Id = 1,
                FirstName = "Tatva",
                LastName = "Admin",
                EmailAddress = "admin@tatvasoft.com",
                UserType = "admin",
                Password = "Tatva@123",
                PhoneNumber = "9876543210",
                CreatedDate = new DateTime(2019, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            });

            base.OnModelCreating(builder);
        }
    }
}
