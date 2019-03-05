namespace Console.DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ActivityParticipant" />
    /// </summary>
    public partial class ActivityParticipant
    {
        /// <summary>
        /// Gets or sets the ActivityID
        /// ActivityID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(@"ActivityID", Order = 1, TypeName = "int")]
        // [Index(@"PK_ActivityParticipant", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Activity ID")]
        public int ActivityID { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantID
        /// ParticipantID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Column(@"ParticipantID", Order = 2, TypeName = "int")]
        // [Index(@"IX_ActivityParticipant_ParticipantID", 1, IsUnique = false, IsClustered = false)]
        // [Index(@"PK_ActivityParticipant", 2, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Participant ID")]
        public int ParticipantID { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantStatusID
        /// </summary>
        [Column(@"ParticipantStatusID", Order = 3, TypeName = "int")]
        // [Index(@"IX_ActivityParticipant_ParticipantStatusID", 1, IsUnique = false, IsClustered = false)]
        [Display(Name = "Participant status ID")]
        public int? ParticipantStatusID { get; set; }

        // Foreign keys

        /// <summary>
        /// Gets or sets the Activity
        /// Parent Activity pointed by [ActivityParticipant].([ActivityId]) (FK_ActivityParticipant_Activity_ActivityID)
        /// </summary>
        [ForeignKey("ActivityID")]
        [InverseProperty("ActivityParticipant")]
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Gets or sets the Participant
        /// Parent User pointed by [ActivityParticipant].([ParticipantId]) (FK_ActivityParticipant_User_ParticipantID)
        /// </summary>
        [ForeignKey("ParticipantID")]
        [InverseProperty("ActivityParticipant")]
        public virtual User Participant { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantStatus
        /// Parent ParticipantStatus pointed by [ActivityParticipant].([ParticipantStatusId]) (FK_ActivityParticipant_ParticipantStatus_ParticipantStatusID)
        /// </summary>
        [ForeignKey("ParticipantStatusID")]
        [InverseProperty("ActivityParticipant")]
        public virtual ParticipantStatus ParticipantStatus { get; set; }
    }
}
