using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Console.DataLayer.Entities
{
    public partial class CrowdActDbContext : DbContext
    {
        public CrowdActDbContext()
        {
        }

        public CrowdActDbContext(DbContextOptions<CrowdActDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccountStatus> AccountStatus { get; set; }
        public virtual DbSet<Activity> Activity { get; set; }
        public virtual DbSet<ActivityLanguage> ActivityLanguage { get; set; }
        public virtual DbSet<ActivityParticipant> ActivityParticipant { get; set; }
        public virtual DbSet<ActivitySkill> ActivitySkill { get; set; }
        public virtual DbSet<ActivityType> ActivityType { get; set; }
        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<Charity> Charity { get; set; }
        public virtual DbSet<City> City { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<Language> Language { get; set; }
        public virtual DbSet<ParticipantCategory> ParticipantCategory { get; set; }
        public virtual DbSet<ParticipantStatus> ParticipantStatus { get; set; }
        public virtual DbSet<Requirement> Requirement { get; set; }
        public virtual DbSet<RequirementStatus> RequirementStatus { get; set; }
        public virtual DbSet<ResourceType> ResourceType { get; set; }
        public virtual DbSet<Skill> Skill { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;database=CrowdActContext-4e575f9f-8ccb-4bc7-8da6-c6328166cc54;Trusted_Connection=True;MultipleActiveResultSets=true;Application Name=CrowdActApp");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.2-servicing-10034");

            modelBuilder.Entity<AccountStatus>(entity =>
            {
                entity.HasIndex(e => e.Label)
                    .HasName("AK_AccountStatus_Label")
                    .IsUnique();
            });

            modelBuilder.Entity<Activity>(entity =>
            {
                entity.HasIndex(e => e.ActivityTypeID);

                entity.HasIndex(e => e.AddressID)
                    .IsUnique()
                    .HasFilter("([AddressID] IS NOT NULL)");

                entity.HasIndex(e => e.CharityID);

                entity.HasIndex(e => e.FieldID);

                entity.HasOne(d => d.Charity)
                    .WithMany(p => p.Activities)
                    .HasForeignKey(d => d.CharityID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<ActivityLanguage>(entity =>
            {
                entity.HasKey(e => new { e.ActivityID, e.LanguageID });

                entity.HasIndex(e => e.LanguageID);
            });

            modelBuilder.Entity<ActivityParticipant>(entity =>
            {
                entity.HasKey(e => new { e.ActivityID, e.ParticipantID });

                entity.HasIndex(e => e.ParticipantID);

                entity.HasIndex(e => e.ParticipantStatusID);

                entity.HasOne(d => d.ParticipantStatus)
                    .WithMany(p => p.ActivityParticipants)
                    .HasForeignKey(d => d.ParticipantStatusID)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<ActivitySkill>(entity =>
            {
                entity.HasKey(e => new { e.ActivityID, e.SkillID });

                entity.HasIndex(e => e.SkillID);
            });

            modelBuilder.Entity<Address>(entity =>
            {
                entity.HasIndex(e => e.CityID);
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasIndex(e => e.Label)
                    .HasName("AK_Category_Label")
                    .IsUnique();
            });

            modelBuilder.Entity<Charity>(entity =>
            {
                entity.HasIndex(e => e.AddressID)
                    .IsUnique()
                    .HasFilter("([AddressID] IS NOT NULL)");

                entity.HasIndex(e => e.Email)
                    .HasName("AK_Charity_Email")
                    .IsUnique();

                entity.HasIndex(e => e.FieldID);

                entity.HasIndex(e => e.RepresentativeID);

                entity.HasOne(d => d.Field)
                    .WithMany(p => p.Charities)
                    .HasForeignKey(d => d.FieldID)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.Representative)
                    .WithMany(p => p.Charities)
                    .HasForeignKey(d => d.RepresentativeID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<City>(entity =>
            {
                entity.HasIndex(e => e.CountryID);

                entity.HasIndex(e => e.Label)
                    .HasName("AK_City_Label")
                    .IsUnique();

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.CountryID)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.HasIndex(e => e.Label)
                    .HasName("AK_Country_Label")
                    .IsUnique();
            });

            modelBuilder.Entity<Language>(entity =>
            {
                entity.HasIndex(e => e.Label)
                    .HasName("AK_Language_Label")
                    .IsUnique();
            });

            modelBuilder.Entity<ParticipantCategory>(entity =>
            {
                entity.HasKey(e => new { e.ParticipantID, e.CategoryID });

                entity.HasIndex(e => e.CategoryID);
            });

            modelBuilder.Entity<ParticipantStatus>(entity =>
            {
                entity.HasIndex(e => e.Label)
                    .HasName("AK_ParticipantStatus_Label")
                    .IsUnique();
            });

            modelBuilder.Entity<Requirement>(entity =>
            {
                entity.HasIndex(e => e.ActivityID);

                entity.HasIndex(e => e.RequirementStatusID);

                entity.HasIndex(e => e.ResourceTypeID);

                entity.HasOne(d => d.RequirementStatus)
                    .WithMany(p => p.Requirement)
                    .HasForeignKey(d => d.RequirementStatusID)
                    .OnDelete(DeleteBehavior.SetNull);

                entity.HasOne(d => d.ResourceType)
                    .WithMany(p => p.Requirements)
                    .HasForeignKey(d => d.ResourceTypeID)
                    .OnDelete(DeleteBehavior.SetNull);
            });

            modelBuilder.Entity<RequirementStatus>(entity =>
            {
                entity.HasIndex(e => e.Label)
                    .HasName("AK_RequirementStatus_Label")
                    .IsUnique();
            });

            modelBuilder.Entity<ResourceType>(entity =>
            {
                entity.HasIndex(e => e.Label)
                    .HasName("AK_ResourceType_Label")
                    .IsUnique();
            });

            modelBuilder.Entity<Skill>(entity =>
            {
                entity.HasIndex(e => e.Label)
                    .HasName("AK_Skill_Label")
                    .IsUnique();
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => e.AccountStatusID);

                entity.HasIndex(e => e.AddressID)
                    .IsUnique()
                    .HasFilter("([AddressID] IS NOT NULL)");

                entity.HasIndex(e => e.Email)
                    .HasName("AK_User_Email")
                    .IsUnique();

                entity.HasOne(d => d.AccountStatus)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.AccountStatusID)
                    .OnDelete(DeleteBehavior.SetNull);
            });
        }
    }
}
