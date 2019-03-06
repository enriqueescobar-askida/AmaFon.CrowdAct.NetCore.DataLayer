namespace Console.DataLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ParticipantStatus" />
    /// </summary>
    [Table("ParticipantStatus")]
    public partial class ParticipantStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ParticipantStatus"/> class.
        /// </summary>
        public ParticipantStatus()
        {
            ActivityParticipants = new HashSet<ActivityParticipant>();
        }

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// </summary>
        [Required]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the ActivityParticipants
        /// </summary>
        [InverseProperty("ParticipantStatus")]
        public virtual ICollection<ActivityParticipant> ActivityParticipants { get; set; }
    }
}
