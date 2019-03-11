namespace Console.DataLayer.Interfaces
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    /*using System.CodeDom.Compiler;
    using System.Collections.Generic;*/
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Defines the <see cref="ICrowdActDbContext" />
    /// </summary>
    public interface ICrowdActDbContext : IDisposable
    {
        /// <summary>
        /// Gets or sets the AccountStatuses
        /// </summary>
        DbSet<AccountStatus> AccountStatuses { get; set; }

        /// <summary>
        /// Gets or sets the Activities
        /// </summary>
        DbSet<Activity> Activities { get; set; }

        /// <summary>
        /// Gets or sets the ActivityLanguages
        /// </summary>
        DbSet<ActivityLanguage> ActivityLanguages { get; set; }

        /// <summary>
        /// Gets or sets the ActivityParticipants
        /// </summary>
        DbSet<ActivityParticipant> ActivityParticipants { get; set; }

        /// <summary>
        /// Gets or sets the ActivitySkills
        /// </summary>
        DbSet<ActivitySkill> ActivitySkills { get; set; }

        /// <summary>
        /// Gets or sets the ActivityTypes
        /// </summary>
        DbSet<ActivityType> ActivityTypes { get; set; }

        /// <summary>
        /// Gets or sets the Addresses
        /// </summary>
        DbSet<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the Categories
        /// </summary>
        DbSet<Category> Categories { get; set; }

        /// <summary>
        /// Gets or sets the Charities
        /// </summary>
        DbSet<Charity> Charities { get; set; }

        /// <summary>
        /// Gets or sets the Cities
        /// </summary>
        DbSet<City> Cities { get; set; }

        /// <summary>
        /// Gets or sets the Countries
        /// </summary>
        DbSet<Country> Countries { get; set; }

        /// <summary>
        /// Gets or sets the Languages
        /// </summary>
        DbSet<Language> Languages { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantCategories
        /// </summary>
        DbSet<ParticipantCategory> ParticipantCategories { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantStatuses
        /// </summary>
        DbSet<ParticipantStatus> ParticipantStatuses { get; set; }

        /// <summary>
        /// Gets or sets the Requirements
        /// </summary>
        DbSet<Requirement> Requirements { get; set; }

        /// <summary>
        /// Gets or sets the RequirementStatuses
        /// </summary>
        DbSet<RequirementStatus> RequirementStatuses { get; set; }

        /// <summary>
        /// Gets or sets the ResourceTypes
        /// </summary>
        DbSet<ResourceType> ResourceTypes { get; set; }

        /// <summary>
        /// Gets or sets the Skills
        /// </summary>
        DbSet<Skill> Skills { get; set; }

        /// <summary>
        /// Gets or sets the Users
        /// </summary>
        DbSet<User> Users { get; set; }

        /// <summary>
        /// The SaveChanges
        /// </summary>
        /// <returns>The <see cref="int"/></returns>
        int SaveChanges();

        /// <summary>
        /// The SaveChangesAsync
        /// </summary>
        /// <returns>The <see cref="Task{int}"/></returns>
        Task<int> SaveChangesAsync();

        /// <summary>
        /// The SaveChangesAsync
        /// </summary>
        /// <param name="cancellationToken">The cancellationToken<see cref="CancellationToken"/></param>
        /// <returns>The <see cref="Task{int}"/></returns>
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

        /*System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get; }
        System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get; }
        System.Data.Entity.Database Database { get; }
        System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors();
        System.Data.Entity.DbSet Set(System.Type entityType);
        System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class;*/

        /// <summary>
        /// The ToString
        /// </summary>
        /// <returns>The <see cref="string"/></returns>
        string ToString();
    }
}
