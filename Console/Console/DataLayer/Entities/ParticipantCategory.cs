namespace Console.DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ParticipantCategory" />
    /// </summary>
    public partial class ParticipantCategory
    {
        /// <summary>
        /// Gets or sets the ParticipantID
        /// </summary>
        public int ParticipantID { get; set; }

        /// <summary>
        /// Gets or sets the CategoryID
        /// </summary>
        public int CategoryID { get; set; }

        /// <summary>
        /// Gets or sets the Category
        /// </summary>
        [ForeignKey("CategoryID")]
        [InverseProperty("ParticipantCategory")]
        public virtual Category Category { get; set; }

        /// <summary>
        /// Gets or sets the Participant
        /// </summary>
        [ForeignKey("ParticipantID")]
        [InverseProperty("ParticipantCategory")]
        public virtual User Participant { get; set; }
    }
}
