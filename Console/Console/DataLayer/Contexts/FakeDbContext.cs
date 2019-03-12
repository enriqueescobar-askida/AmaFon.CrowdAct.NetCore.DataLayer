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
        #region PrivateAttributes
        /// Flag for disposed resources
        private bool _IsDisposed = false;
        #endregion

        #region PublicAttributes
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
        #endregion

        /// <summary>
        /// Defines the _changeTracker
        /// </summary>
        private ChangeTracker _changeTracker;

        /// <summary>
        /// Gets the ChangeTracker
        /// </summary>
        public ChangeTracker ChangeTracker => ChangeTracker;

        /// <summary>
        /// Gets the SaveChangesCount
        /// </summary>
        public int SaveChangesCount { get; private set; }

        #region Constructor
        /// <summary>
        /// Initializes a new instance of the <see cref="FakeDbContext"/> class.
        /// </summary>
        public FakeDbContext()
        {
            this._changeTracker = null;
            //this._database = null;

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
        #endregion

        #region Destructor
        /// Releases unmanaged resources and performs other cleanup operations before the
        /// is reclaimed by garbage collection.
        /// This destructor will run only if the Dispose method does not get called.
        /// It gives your base class the opportunity to finalize.
        /// Do not provide destructor in types derived from this class.
        ~FakeDbContext()
        {
            // Do not re-create Dispose clean-up code here.
            // Calling Dispose(false) is optimal in terms of readability and maintainability.
            this.Dispose(false);
        }
        #endregion

        #region Disposable
        /// <summary>
        /// Releases unmanaged and - optionally - managed resources.
        /// </summary>
        /// <param name="isDisposing"><c>true</c> to release both managed and unmanaged resources; <c>false</c> to release only unmanaged resources.</param>
        protected virtual void Dispose(bool isDisposing)
        {
            //Check if Dispose has been called
            if (!this._IsDisposed)
            {//dispose managed and unmanaged resources
                if (isDisposing)
                {//managed resources clean
                    this._changeTracker = null;
                    this.AccountStatuses = null;
                    this.Activities = null;
                    this.ActivityLanguages = null;
                    this.ActivityParticipants = null;
                    this.ActivitySkills = null;
                    this.ActivityTypes = null;
                    this.Addresses = null;
                    this.Categories = null;
                    this.Charities = null;
                    this.Cities = null;
                    this.Countries = null;
                    this.Languages = null;
                    this.ParticipantCategories = null;
                    this.ParticipantStatuses = null;
                    this.Requirements = null;
                    this.RequirementStatuses = null;
                    this.ResourceTypes = null;
                    this.Skills = null;
                    this.Users = null;
                }
                //unmanaged resources clean

                //confirm cleaning
                this._IsDisposed = true;
            }
        }

        /// <summary>
        /// The Dispose.- Releases unmanaged and - optionally - managed resources.
        /// </summary>
        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

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
        public Task<int> SaveChangesAsync(CancellationToken cancellationToken)
        {
            ++SaveChangesCount;

            return Task<int>.Factory.StartNew(() => 1, cancellationToken);
        }

        /// <summary>
        /// The Entry
        /// </summary>
        /// <typeparam name="TEntity"></typeparam>
        /// <param name="entity">The entity<see cref="TEntity"/></param>
        /// <returns>The <see cref="System.Data.Entity.Infrastructure.DbEntityEntry{TEntity}"/></returns>
        public EntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class
        {
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
        public override string ToString() => base.ToString();
    }
}
