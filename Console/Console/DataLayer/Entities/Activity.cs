namespace Console.DataLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Activity" />
    /// </summary>
    public partial class Activity
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")]
        // [Index(@"PK_Activity", 1, IsUnique = true, IsClustered = true)]
        // [Required]
        // [Key]
        // [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        [Column(@"Name", Order = 2, TypeName = "nvarchar(max)")]
        // [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        [Column(@"Description", Order = 3, TypeName = "nvarchar(max)")]
        // [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Picture
        /// </summary>
        [Column(@"Picture", Order = 4, TypeName = "nvarchar(max)")]
        // [Display(Name = "Picture")]
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets the MaxParticipantNb
        /// </summary>
        [Column(@"MaxParticipantNb", Order = 5, TypeName = "int")]
        // [Required]
        // [Display(Name = "Max participant nb")]
        public int MaxParticipantNb { get; set; }

        /// <summary>
        /// Gets or sets the StartingDate
        /// </summary>
        [Column(@"StartingDate", Order = 6, TypeName = "datetime2")]
        // [Required]
        // [DataType(DataType.DateTime)]
        // [Display(Name = "Starting date")]
        public DateTime StartingDate { get; set; }

        /// <summary>
        /// Gets or sets the EndingDate
        /// </summary>
        [Column(@"EndingDate", Order = 7, TypeName = "datetime2")]
        // [Required]
        // [DataType(DataType.DateTime)]
        // [Display(Name = "Ending date")]
        public DateTime EndingDate { get; set; }

        /// <summary>
        /// Gets or sets the AddressID
        /// </summary>
        [Column(@"AddressID", Order = 8, TypeName = "int")]
        // [Index(@"IX_Activity_AddressID", 1, IsUnique = true, IsClustered = false)]
        // [Display(Name = "Address ID")]
        public int? AddressID { get; set; }

        /// <summary>
        /// Gets or sets the CharityID
        /// </summary>
        [Column(@"CharityID", Order = 9, TypeName = "int")]
        // [Index(@"IX_Activity_CharityID", 1, IsUnique = false, IsClustered = false)]
        // [Required]
        // [Display(Name = "Charity ID")]
        public int CharityID { get; set; }

        /// <summary>
        /// Gets or sets the FieldID
        /// </summary>
        [Column(@"FieldID", Order = 10, TypeName = "int")]
        // [Index(@"IX_Activity_FieldID", 1, IsUnique = false, IsClustered = false)]
        // [Display(Name = "Field ID")]
        public int? FieldID { get; set; }

        /// <summary>
        /// Gets or sets the TypeID
        /// </summary>
        [Column(@"TypeID", Order = 11, TypeName = "int")]
        // [Display(Name = "Type ID")]
        public int? TypeID { get; set; }

        /// <summary>
        /// Gets or sets the ActivityTypeID
        /// </summary>
        [Column(@"ActivityTypeID", Order = 12, TypeName = "int")]
        // [Index(@"IX_Activity_ActivityTypeID", 1, IsUnique = false, IsClustered = false)]
        // [Display(Name = "Activity type ID")]
        public int? ActivityTypeID { get; set; }

        // Foreign keys

        /// <summary>
        /// Gets or sets the ActivityType
        /// Parent ActivityType pointed by [Activity].([ActivityTypeId]) (FK_Activity_ActivityType_ActivityTypeID)
        /// </summary>
        [ForeignKey("ActivityTypeID")]
        [InverseProperty("Activity")]
        public virtual ActivityType ActivityType { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// Parent Address pointed by [Activity].([AddressId]) (FK_Activity_Address_AddressID)
        /// </summary>
        [ForeignKey("AddressID")]
        [InverseProperty("Activity")]
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the Charity
        /// Parent Charity pointed by [Activity].([CharityId]) (FK_Activity_Charity_CharityID)
        /// </summary>
        [ForeignKey("CharityID")]
        [InverseProperty("Activity")]
        public virtual Charity Charity { get; set; }

        /// <summary>
        /// Gets or sets the Field
        /// Parent Category pointed by [Activity].([FieldId]) (FK_Activity_Category_FieldID)
        /// </summary>
        [ForeignKey("FieldID")]
        [InverseProperty("Activity")]
        public virtual Category Field { get; set; }

        // Reverse navigation

        /// <summary>
        /// Gets or sets the ActivityLanguage
        /// Child ActivityLanguages where [ActivityLanguage].[ActivityID] point to this entity (FK_ActivityLanguage_Activity_ActivityID)
        /// </summary>
        [InverseProperty("Activity")]
        public virtual ICollection<ActivityLanguage> ActivityLanguages { get; set; }

        /// <summary>
        /// Gets or sets the ActivityParticipant
        /// Child ActivityParticipants where [ActivityParticipant].[ActivityID] point to this entity (FK_ActivityParticipant_Activity_ActivityID)
        /// </summary>
        [InverseProperty("Activity")]
        public virtual ICollection<ActivityParticipant> ActivityParticipants { get; set; }

        /// <summary>
        /// Gets or sets the ActivitySkill
        /// Child Skills (Many-to-Many) mapped by table [ActivitySkill]
        /// </summary>
        [InverseProperty("Activity")]
        public virtual ICollection<ActivitySkill> ActivitySkills { get; set; }

        /// <summary>
        /// Gets or sets the Requirement
        /// Child Requirements where [Requirement].[ActivityID] point to this entity (FK_Requirement_Activity_ActivityID)
        /// </summary>
        [InverseProperty("Activity")]
        public virtual ICollection<Requirement> Requirements { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Activity"/> class.
        /// </summary>
        public Activity()
        {
            this.ActivityLanguages = new HashSet<ActivityLanguage>();
            this.ActivityParticipants = new HashSet<ActivityParticipant>();
            this.ActivitySkills = new HashSet<ActivitySkill>();
            this.Requirements = new HashSet<Requirement>();
        }
    }
}
