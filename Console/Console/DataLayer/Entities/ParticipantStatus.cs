namespace Console.DataLayer.Entities
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
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")] // [Column("ID")]
        // [Index(@"PK_ParticipantStatus", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// .Label (length: 450)
        /// </summary>
        // [Column(@"Label", Order = 2, TypeName = "nvarchar")]
        // [Index(@"AK_ParticipantStatus_Label", 1, IsUnique = true, IsClustered = false)]
        [Required(AllowEmptyStrings = true)] // [Required]
        [MaxLength(450)]
        [StringLength(450)]
        [Display(Name = "Label")]
        public string Label { get; set; }

        // Reverse navigation

        /// <summary>
        /// Gets or sets the ActivityParticipants
        /// Child ActivityParticipants where [ActivityParticipant].[ParticipantStatusID] point to this entity (FK_ActivityParticipant_ParticipantStatus_ParticipantStatusID)
        /// </summary>
        [InverseProperty("ParticipantStatus")]
        public virtual ICollection<ActivityParticipant> ActivityParticipants { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ParticipantStatus"/> class.
        /// </summary>
        public ParticipantStatus()
        {
            this.ActivityParticipants = new HashSet<ActivityParticipant>();
        }
    }
}
