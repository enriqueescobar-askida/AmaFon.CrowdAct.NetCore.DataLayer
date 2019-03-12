namespace Console.DataLayer.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Entities;
    using Interfaces;
    using System;

    /// <summary>
    /// Defines the <see cref="CrowdActDbContext" />
    /// </summary>
    public partial class CrowdActDbContext : DbContext//, ICrowdActDbContext
    {
        #region OnConfiguring
        /// <summary>
        /// The OnConfiguring
        /// </summary>
        /// <param name="optionsBuilder">The optionsBuilder<see cref="DbContextOptionsBuilder"/></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=CrowdActContext-4e575f9f-8ccb-4bc7-8da6-c6328166cc54;Integrated Security=True");
            }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="CrowdActDbContext"/> class.
        /// </summary>
        public CrowdActDbContext()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CrowdActDbContext"/> class.
        /// </summary>
        /// <param name="options">The options<see cref="DbContextOptions{CrowdActDbContext}"/></param>
        public CrowdActDbContext(DbContextOptions<CrowdActDbContext> options)
            : base(options)
        {
        }
        #endregion

        /// <summary>
        /// Gets or sets the AccountStatuses
        /// </summary>
        public virtual DbSet<AccountStatus> AccountStatuses { get; set; }

        /// <summary>
        /// Gets or sets the Activities
        /// </summary>
        public virtual DbSet<Activity> Activities { get; set; }

        /// <summary>
        /// Gets or sets the ActivityLanguages
        /// </summary>
        public virtual DbSet<ActivityLanguage> ActivityLanguages { get; set; }

        /// <summary>
        /// Gets or sets the ActivityParticipants
        /// </summary>
        public virtual DbSet<ActivityParticipant> ActivityParticipants { get; set; }

        /// <summary>
        /// Gets or sets the ActivitySkills
        /// </summary>
        public virtual DbSet<ActivitySkill> ActivitySkills { get; set; }

        /// <summary>
        /// Gets or sets the ActivityTypes
        /// </summary>
        public virtual DbSet<ActivityType> ActivityTypes { get; set; }

        /// <summary>
        /// Gets or sets the Addresses
        /// </summary>
        public virtual DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the Categories
        /// </summary>
        public virtual DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the Charities
        /// </summary>
        public virtual DbSet<Charity> Charities { get; set; }

        /// <summary>
        /// Gets or sets the Cities
        /// </summary>
        public virtual DbSet<City> Cities { get; set; }

        /// <summary>
        /// Gets or sets the Countries
        /// </summary>
        public virtual DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Gets or sets the Languages
        /// </summary>
        public virtual DbSet<Language> Languages { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantCategories
        /// </summary>
        public virtual DbSet<ParticipantCategory> ParticipantCategories { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantStatuses
        /// </summary>
        public virtual DbSet<ParticipantStatus> ParticipantStatuses { get; set; }

        /// <summary>
        /// Gets or sets the Requirements
        /// </summary>
        public virtual DbSet<Requirement> Requirements { get; set; }

        /// <summary>
        /// Gets or sets the RequirementStatuses
        /// </summary>
        public virtual DbSet<RequirementStatus> RequirementStatuses { get; set; }

        /// <summary>
        /// Gets or sets the ResourceTypes
        /// </summary>
        public virtual DbSet<ResourceType> ResourceTypes { get; set; }

        /// <summary>
        /// Gets or sets the Skills
        /// </summary>
        public virtual DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// Gets or sets the Users
        /// </summary>
        public virtual DbSet<User> Users { get; set; }

        #region Override
        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
        public void Dispose(bool disposing) => this.Dispose(disposing);

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="System.String"/> that represents this instance.</returns>
        public override string ToString()
        {
            string s = "CrowdActDbContext\n";
            s += this.AccountStatuses.Local.Count + "\n";
            s += this.Activities.Local.Count + "\n";
            s += this.ActivityLanguages.Local.Count + "\n";
            s += this.ActivityParticipants.Local.Count + "\n";
            s += this.ActivitySkills.Local.Count + "\n";
            s += this.ActivityTypes.Local.Count + "\n";
            s += this.Addresses.Local.Count + "\n";
            s += this.Categories.Local.Count + "\n";
            s += this.Charities.Local.Count + "\n";
            s += this.Cities.Local.Count + "\n";
            s += this.Countries.Local.Count + "\n";
            s += this.Languages.Local.Count + "\n";
            s += this.ParticipantCategories.Local.Count + "\n";
            s += this.ParticipantStatuses.Local.Count + "\n";
            s += this.ResourceTypes.Local.Count + "\n";
            s += this.Skills.ToString() + "\n";
            s += this.Users.Local.Count + "\n";

            return s;
        }
        #endregion

        #region OnModel
        /// <summary>
        /// The OnModelCreating
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.0-rtm-35687");

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
                    .WithMany(p => p.Requirements)
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

            this.OnModelCreatingPartial(modelBuilder);
        }

        /// <summary>
        /// The OnModelCreatingPartial
        /// </summary>
        /// <param name="modelBuilder">The modelBuilder<see cref="ModelBuilder"/></param>
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
        #endregion
    }
}
