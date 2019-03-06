namespace Console.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Activity" />
    /// </summary>
    [Table("Activity")]
    public partial class Activity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Activity"/> class.
        /// </summary>
        public Activity()
        {
            ActivityLanguages = new HashSet<ActivityLanguage>();
            ActivityParticipants = new HashSet<ActivityParticipant>();
            ActivitySkills = new HashSet<ActivitySkill>();
            Requirements = new HashSet<Requirement>();
        }

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Picture
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets the MaxParticipantNb
        /// </summary>
        public int MaxParticipantNb { get; set; }

        /// <summary>
        /// Gets or sets the StartingDate
        /// </summary>
        public DateTime StartingDate { get; set; }

        /// <summary>
        /// Gets or sets the EndingDate
        /// </summary>
        public DateTime EndingDate { get; set; }

        /// <summary>
        /// Gets or sets the AddressID
        /// </summary>
        [Column("AddressID")]
        public int? AddressID { get; set; }

        /// <summary>
        /// Gets or sets the CharityID
        /// </summary>
        [Column("CharityID")]
        public int CharityID { get; set; }

        /// <summary>
        /// Gets or sets the FieldID
        /// </summary>
        [Column("FieldID")]
        public int? FieldID { get; set; }

        /// <summary>
        /// Gets or sets the TypeID
        /// </summary>
        [Column("TypeID")]
        public int? TypeID { get; set; }

        /// <summary>
        /// Gets or sets the ActivityTypeID
        /// </summary>
        [Column("ActivityTypeID")]
        public int? ActivityTypeID { get; set; }

        /// <summary>
        /// Gets or sets the ActivityType
        /// </summary>
        [ForeignKey("ActivityTypeId")]
        [InverseProperty("Activities")]
        public virtual ActivityType ActivityType { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        [ForeignKey("AddressId")]
        [InverseProperty("Activity")]
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the Charity
        /// </summary>
        [ForeignKey("CharityId")]
        [InverseProperty("Activities")]
        public virtual Charity Charity { get; set; }

        /// <summary>
        /// Gets or sets the Field
        /// </summary>
        [ForeignKey("FieldId")]
        [InverseProperty("Activities")]
        public virtual Category Field { get; set; }

        /// <summary>
        /// Gets or sets the ActivityLanguages
        /// </summary>
        [InverseProperty("Activity")]
        public virtual ICollection<ActivityLanguage> ActivityLanguages { get; set; }

        /// <summary>
        /// Gets or sets the ActivityParticipants
        /// </summary>
        [InverseProperty("Activity")]
        public virtual ICollection<ActivityParticipant> ActivityParticipants { get; set; }

        /// <summary>
        /// Gets or sets the ActivitySkills
        /// </summary>
        [InverseProperty("Activity")]
        public virtual ICollection<ActivitySkill> ActivitySkills { get; set; }

        /// <summary>
        /// Gets or sets the Requirements
        /// </summary>
        [InverseProperty("Activity")]
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
