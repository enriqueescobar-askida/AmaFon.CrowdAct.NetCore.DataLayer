namespace Console.DataLayer
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ActivityLanguage" />
    /// </summary>
    [Table("ActivityLanguage")]
    public partial class ActivityLanguage
    {
        /// <summary>
        /// Gets or sets the ActivityID
        /// ActivityID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(@"ActivityID", Order = 1, TypeName = "int")] // [Column("ActivityID")]
        // [Index(@"PK_ActivityLanguage", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Activity ID")]
        public int ActivityID { get; set; }

        /// <summary>
        /// Gets or sets the LanguageID
        /// LanguageID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(@"LanguageID", Order = 2, TypeName = "int")] // [Column("LanguageID")]
        // [Index(@"IX_ActivityLanguage_LanguageID", 1, IsUnique = false, IsClustered = false)]
        // [Index(@"PK_ActivityLanguage", 2, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Language ID")]
        public int LanguageID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Main
        /// </summary>
        // [Column(@"Main", Order = 3, TypeName = "bit")]
        [Required]
        [Display(Name = "Main")]
        public bool Main { get; set; }

        // Foreign keys

        /// <summary>
        /// Gets or sets the Activity
        /// </summary>
        [ForeignKey("ActivityId")]
        [InverseProperty("ActivityLanguages")]
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Gets or sets the Language
        /// </summary>
        [ForeignKey("LanguageId")]
        [InverseProperty("ActivityLanguages")]
        public virtual Language Language { get; set; }
    }
}
