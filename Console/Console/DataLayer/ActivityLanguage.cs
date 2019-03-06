namespace Console.DataLayer
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ActivityLanguage" />
    /// </summary>
    [Table("ActivityLanguage")]
    public partial class ActivityLanguage
    {
        /// <summary>
        /// Gets or sets the ActivityID
        /// </summary>
        [Column("ActivityID")]
        public int ActivityID { get; set; }

        /// <summary>
        /// Gets or sets the LanguageID
        /// </summary>
        [Column("LanguageID")]
        public int LanguageID { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Main
        /// </summary>
        public bool Main { get; set; }

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
