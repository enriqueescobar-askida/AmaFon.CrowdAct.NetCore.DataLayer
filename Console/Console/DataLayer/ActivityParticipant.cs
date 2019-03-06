namespace Console.DataLayer
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ActivityParticipant" />
    /// </summary>
    [Table("ActivityParticipant")]
    public partial class ActivityParticipant
    {
        /// <summary>
        /// Gets or sets the ActivityID
        /// </summary>
        [Column("ActivityID")]
        public int ActivityID { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantID
        /// </summary>
        [Column("ParticipantID")]
        public int ParticipantID { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantStatusID
        /// </summary>
        [Column("ParticipantStatusID")]
        public int? ParticipantStatusID { get; set; }

        /// <summary>
        /// Gets or sets the Activity
        /// </summary>
        [ForeignKey("ActivityId")]
        [InverseProperty("ActivityParticipants")]
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Gets or sets the Participant
        /// </summary>
        [ForeignKey("ParticipantId")]
        [InverseProperty("ActivityParticipants")]
        public virtual User Participant { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantStatus
        /// </summary>
        [ForeignKey("ParticipantStatusId")]
        [InverseProperty("ActivityParticipants")]
        public virtual ParticipantStatus ParticipantStatus { get; set; }
    }
}
