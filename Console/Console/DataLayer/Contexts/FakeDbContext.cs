namespace Console.DataLayer.Contexts
{
    using Entities;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Threading;
    using System.Threading.Tasks;

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

        /// <summary>
        /// The Dispose
        /// </summary>
        public void Dispose()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The SaveChanges
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Defines the _changeTracker
        /// </summary>
        private ChangeTracker _changeTracker;

        /// <summary>
        /// Gets the ChangeTracker
        /// </summary>
        public ChangeTracker ChangeTracker => ChangeTracker;
        /*
        /// <summary>
        /// Defines the _database
        /// </summary>
        private SqlServerDatabaseFacadeExtensions _database;
        */
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDbContext"/> class.
        /// </summary>
        public FakeDbContext()
        {
            _changeTracker = null;
            //_database = null;

            AccountStatuses = new FakeDbSet<AccountStatus>("Id");
            Activities = new FakeDbSet<Activity>("Id");
            ActivityLanguages = new FakeDbSet<ActivityLanguage>("ActivityId", "LanguageId");
            ActivityParticipants = new FakeDbSet<ActivityParticipant>("ActivityId", "ParticipantId");
            ActivitySkills = new FakeDbSet<ActivitySkill>("Id");
            ActivityTypes = new FakeDbSet<ActivityType>("Id");
            Addresses = new FakeDbSet<Address>("Id");
            Categories = new FakeDbSet<Category>("Id");
            Charities = new FakeDbSet<Charity>("Id");
            Cities = new FakeDbSet<City>("Id");
            Countries = new FakeDbSet<Country>("Id");
            Languages = new FakeDbSet<Language>("Id");
            ParticipantCategories = new FakeDbSet<ParticipantCategory>("Id");
            ParticipantStatuses = new FakeDbSet<ParticipantStatus>("Id");
            Requirements = new FakeDbSet<Requirement>("Id");
            RequirementStatuses = new FakeDbSet<RequirementStatus>("Id");
            ResourceTypes = new FakeDbSet<ResourceType>("Id");
            Skills = new FakeDbSet<Skill>("Id");
            Users = new FakeDbSet<User>("Id");
        }

        /// <summary>
        /// Gets the SaveChangesCount
        /// </summary>
        public int SaveChangesCount { get; private set; }
        /*
        /// <summary>
        /// The SaveChanges
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        public int SaveChanges()
        {
            ++SaveChangesCount;
            return 1;
        }*/

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
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
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
        /*
        /// <summary>
        /// The Dispose
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
        }*/
        /*
        /// <summary>
        /// Gets the Database
        /// </summary>
        public SqlServerDatabaseFacadeExtensions Database => _database;
        */
        /// <summary>
        /// The Entry
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        /// <returns>The <see cref="System.Data.Entity.Infrastructure.DbEntityEntry{TEntity}"/></returns>
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
            // Microsoft.EntityFrameworkCore.ChangeTracking.EntityEntry<TEntity> entityEntry<TEntity>
            throw new NotImplementedException();
        }

        /// <summary>
        /// The Entry
        /// </summary>
        /// <param name="entity">The entity<see cref="object"/></param>
        /// <returns>The <see cref="System.Data.Entity.Infrastructure.DbEntityEntry"/></returns>
        public EntityEntry Entry(object entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The GetValidationErrors
        /// </summary>
        /// <returns>The <see cref="System.Collections.Generic.IEnumerable{System.Data.Entity.Validation.DbEntityValidationResult}"/></returns>
        public IEnumerable<ValidationException> GetValidationErrors()
        {
            throw new NotImplementedException();
        }
        /*
        /// <summary>
        /// The Set
        /// </summary>
        /// <param name="entityType">The entityType<see cref="System.Type"/></param>
        /// <returns>The <see cref="System.Data.Entity.DbSet"/></returns>
        public System.Data.Entity.DbSet Set(Type entityType)
        {
            throw new NotImplementedException();
        }*/

        /// <summary>
        /// The Set
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <returns>The <see cref="System.Data.Entity.DbSet{TEntity}"/></returns>
        public DbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        public override string ToString()
        {
            throw new NotImplementedException();
        }
    }
}
