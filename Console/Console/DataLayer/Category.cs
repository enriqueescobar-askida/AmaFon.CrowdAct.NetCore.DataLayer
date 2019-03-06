namespace Console.DataLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Category" />
    /// </summary>
    [Table("Category")]
    public partial class Category
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")] // [Column("ID")]
        // [Index(@"PK_Category", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// Label (length: 450)
        /// </summary>
        // [Column(@"Label", Order = 2, TypeName = "nvarchar")]
        // [Index(@"AK_Category_Label", 1, IsUnique = true, IsClustered = false)]
        [Required(AllowEmptyStrings = true)] // [Required]
        [MaxLength(450)]
        [StringLength(450)]
        [Display(Name = "Label")]
        public string Label { get; set; }

        // Reverse navigation

        /// <summary>
        /// Gets or sets the Activities
        /// Child Activities where [Activity].[FieldID] point to this entity (FK_Activity_Category_FieldID)
        /// </summary>
        [InverseProperty("Field")]
        public virtual ICollection<Activity> Activities { get; set; }

        /// <summary>
        /// Gets or sets the Charities
        /// Child Charities where [Charity].[FieldID] point to this entity (FK_Charity_Category_FieldID)
        /// </summary>
        [InverseProperty("Field")]
        public virtual ICollection<Charity> Charities { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantCategories
        /// Child Users (Many-to-Many) mapped by table [ParticipantCategory]
        /// </summary>
        [InverseProperty("Category")]
        public virtual ICollection<ParticipantCategory> ParticipantCategories { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Category"/> class.
        /// </summary>
        public Category()
        {
            this.Activities = new HashSet<Activity>();
            this.Charities = new HashSet<Charity>();
            this.ParticipantCategories = new HashSet<ParticipantCategory>();
        }
    }
}
