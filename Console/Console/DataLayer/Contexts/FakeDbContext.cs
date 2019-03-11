namespace Console.DataLayer.Contexts
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Entities;
    using Interfaces;

    /// <summary>
    /// Defines the <see cref="FakeDbContext" />
    /// </summary>
    public class FakeDbContext : ICrowdActDbContext
    {
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

        public void Dispose()
        {
            throw new System.NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        private ChangeTracker _changeTracker;

        public ChangeTracker ChangeTracker => this.ChangeTracker;

        private SqlServerDatabaseFacadeExtensions _database;

        public FakeDbContext()
        {
            this._changeTracker = null;
            this._database = null;

            this.AccountStatuses = new FakeDbSet<AccountStatus>("Id");
            this.Activities = new FakeDbSet<Activity>("Id");
            this.ActivityLanguages = new FakeDbSet<ActivityLanguage>("ActivityId", "LanguageId");
            this.ActivityParticipants = new FakeDbSet<ActivityParticipant>("ActivityId", "ParticipantId");
            this.ActivitySkills = new FakeDbSet<ActivitySkill>("Id");
            this.ActivityTypes = new FakeDbSet<ActivityType>("Id");
            this.Addresses = new FakeDbSet<Address>("Id");
            this.Categories = new FakeDbSet<Category>("Id");
            this.Charities = new FakeDbSet<Charity>("Id");
            this.Cities = new FakeDbSet<City>("Id");
            this.Countries = new FakeDbSet<Country>("Id");
            this.Languages = new FakeDbSet<Language>("Id");
            this.ParticipantCategories = new FakeDbSet<ParticipantCategory>("Id");
            this.ParticipantStatuses = new FakeDbSet<ParticipantStatus>("Id");
            this.Requirements = new FakeDbSet<Requirement>("Id");
            this.RequirementStatuses = new FakeDbSet<RequirementStatus>("Id");
            this.ResourceTypes = new FakeDbSet<ResourceType>("Id");
            this.Skills = new FakeDbSet<Skill>("Id");
            this.Users = new FakeDbSet<User>("Id");
        }

        /// <summary>
        /// Gets the SaveChangesCount
        /// </summary>
        public int SaveChangesCount { get; private set; }

        /// <summary>
        /// The SaveChanges
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }

        /// <summary>
        /// The SaveChangesAsync
        /// </summary>
        /// <returns>The <see cref="System.Threading.Tasks.Task{int}"/></returns>
        public Task<int> SaveChangesAsync()
        {
            ++SaveChangesCount;
            return Task<int>.Factory.StartNew(() => 1);
        }

        /// <summary>
        /// The SaveChangesAsync
        /// </summary>
        /// <param name="cancellationToken">The cancellationToken<see cref="System.Threading.CancellationToken"/></param>
        /// <returns>The <see cref="System.Threading.Tasks.Task{int}"/></returns>
        public Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken)
        {
            ++SaveChangesCount;
            return Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        /// <param name="disposing">The disposing<see cref="bool"/></param>
        protected virtual void Dispose(bool disposing)
        {
        }

        /// <summary>
        /// The Dispose
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
        }

        public SqlServerDatabaseFacadeExtensions Database => this._database;

        /// <summary>
        /// The Entry
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        /// <returns>The <see cref="System.Data.Entity.Infrastructure.DbEntityEntry{TEntity}"/></returns>
        public Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The Entry
        /// </summary>
        /// <param name="entity">The entity<see cref="object"/></param>
        /// <returns>The <see cref="System.Data.Entity.Infrastructure.DbEntityEntry"/></returns>
        public System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The GetValidationErrors
        /// </summary>
        /// <returns>The <see cref="System.Collections.Generic.IEnumerable{System.Data.Entity.Validation.DbEntityValidationResult}"/></returns>
        public IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors() => throw new System.NotImplementedException();

        /// <summary>
        /// The Set
        /// </summary>
        /// <param name="entityType">The entityType<see cref="System.Type"/></param>
        /// <returns>The <see cref="System.Data.Entity.DbSet"/></returns>
        public System.Data.Entity.DbSet Set(System.Type entityType)
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The Set
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>The <see cref="System.Data.Entity.DbSet{TEntity}"/></returns>
        public System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new System.NotImplementedException();
        }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            throw new System.NotImplementedException();
        }
    }
}
