namespace Console.DataLayer
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ParticipantCategory" />
    /// </summary>
    [Table("ParticipantCategory")]
    public partial class ParticipantCategory
    {
        /// <summary>
        /// Gets or sets the ParticipantID
        /// </summary>
        [Column("ParticipantID")]
        public int ParticipantID { get; set; }

        /// <summary>
        /// Gets or sets the CategoryID
        /// </summary>
        [Column("CategoryID")]
        public int CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the Category
        /// </summary>
        [ForeignKey("CategoryId")]
        [InverseProperty("ParticipantCategories")]
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets the Participant
        /// </summary>
        [ForeignKey("ParticipantId")]
        [InverseProperty("ParticipantCategories")]
        public virtual User Participant { get; set; }
    }
}
