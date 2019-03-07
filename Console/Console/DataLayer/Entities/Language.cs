namespace Console.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Language" />
    /// </summary>
    [Table("Language")]
    public partial class Language
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")] // [Column("ID")]
        // [Index(@"PK_Language", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// Label (length: 450)
        /// </summary>
        // [Column(@"Label", Order = 2, TypeName = "nvarchar")]
        // [Index(@"AK_Language_Label", 1, IsUnique = true, IsClustered = false)]
        [Required(AllowEmptyStrings = true)] // [Required]
        [MaxLength(450)]
        [StringLength(450)]
        [Display(Name = "Label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Active
        /// </summary>
        [Column(@"Active", Order = 3, TypeName = "bit")]
        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Disabled
        /// </summary>
        [Column(@"Disabled", Order = 4, TypeName = "bit")]
        [Required]
        [Display(Name = "Disabled")]
        public bool Disabled { get; set; }

        // Reverse navigation

        /// <summary>
        /// Gets or sets the ActivityLanguages
        /// Child ActivityLanguages where [ActivityLanguage].[LanguageID] point to this entity (FK_ActivityLanguage_Language_LanguageID)
        /// </summary>
        [InverseProperty("Language")]
        public virtual ICollection<ActivityLanguage> ActivityLanguages { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Language"/> class.
        /// </summary>
        public Language()
        {
            this.ActivityLanguages = new HashSet<ActivityLanguage>();
        }
    }
}
