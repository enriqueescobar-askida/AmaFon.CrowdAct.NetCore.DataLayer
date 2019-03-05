namespace Console.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ActivityType" />
    /// </summary>
    public partial class ActivityType
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")]
        // [Index(@"PK_ActivityType", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// </summary>
        [Column(@"Label", Order = 2, TypeName = "nvarchar(max)")]
        [Required(AllowEmptyStrings = true)]
        [Display(Name = "Label")]
        public string Label { get; set; }

        // Reverse navigation

        /// <summary>
        /// Gets or sets the Activity
        /// Child Activities where [Activity].[ActivityTypeID] point to this entity (FK_Activity_ActivityType_ActivityTypeID)
        /// </summary>
        [InverseProperty("ActivityType")]
        public virtual ICollection<Activity> Activities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityType"/> class.
        /// </summary>
        public ActivityType()
        {
            this.Activities = new HashSet<Activity>();
        }
    }
}
