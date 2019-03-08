namespace Console.DataLayer.Interfaces
{
    using Entities;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.CodeDom.Compiler;
    using System.Collections.Generic;

    public interface ICrowdActDbContext : System.IDisposable
    {
        DbSet<AccountStatus> AccountStatuses { get; set; } // AccountStatus
        DbSet<Activity> Activities { get; set; } // Activity
        DbSet<ActivityLanguage> ActivityLanguages { get; set; } // ActivityLanguage
        DbSet<ActivityParticipant> ActivityParticipants { get; set; } // ActivityParticipant
        DbSet<ActivitySkill> ActivitySkills { get; set; } // ActivitySkill
        DbSet<ActivityType> ActivityTypes { get; set; } // ActivityType
        DbSet<Address> Addresses { get; set; } // Address
        DbSet<Category> Categories { get; set; } // Category
        DbSet<Charity> Charities { get; set; } // Charity
        DbSet<City> Cities { get; set; } // City
        DbSet<Country> Countries { get; set; } // Country
        DbSet<Language> Languages { get; set; } // Language
        DbSet<ParticipantCategory> ParticipantCategories { get; set; } // ParticipantCategory
        DbSet<ParticipantStatus> ParticipantStatuses { get; set; } // ParticipantStatus
        DbSet<Requirement> Requirements { get; set; } // Requirement
        DbSet<RequirementStatus> RequirementStatuses { get; set; } // RequirementStatus
        DbSet<ResourceType> ResourceTypes { get; set; } // ResourceType
        DbSet<Skill> Skills { get; set; } // Skill
        DbSet<User> Users { get; set; } // User

        int SaveChanges();

        /*System.Threading.Tasks.Task<int> SaveChangesAsync();
        System.Threading.Tasks.Task<int> SaveChangesAsync(System.Threading.CancellationToken cancellationToken);
        System.Data.Entity.Infrastructure.DbChangeTracker ChangeTracker { get; }
        System.Data.Entity.Infrastructure.DbContextConfiguration Configuration { get; }
        System.Data.Entity.Database Database { get; }
        System.Data.Entity.Infrastructure.DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        System.Data.Entity.Infrastructure.DbEntityEntry Entry(object entity);
        IEnumerable<System.Data.Entity.Validation.DbEntityValidationResult> GetValidationErrors();
        System.Data.Entity.DbSet Set(System.Type entityType);
        System.Data.Entity.DbSet<TEntity> Set<TEntity>() where TEntity : class;*/

        string ToString();
    }
}
