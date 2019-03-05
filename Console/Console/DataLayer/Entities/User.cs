namespace Console.DataLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="User" />
    /// </summary>
    public partial class User
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")]
        // [Index(@"PK_User", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        [Column(@"FirstName", Order = 2, TypeName = "nvarchar(max)")]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        [Column(@"LastName", Order = 3, TypeName = "nvarchar(max)")]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Column(@"Email", Order = 4, TypeName = "nvarchar")]
        // [Index(@"AK_User_Email", 1, IsUnique = true, IsClustered = false)]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(450)]
        [StringLength(450)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        [Column(@"Password", Order = 5, TypeName = "nvarchar(max)")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Phone
        /// </summary>
        [Column(@"Phone", Order = 6, TypeName = "nvarchar(max)")]
        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the BirthDate
        /// </summary>
        [Column(@"BirthDate", Order = 7, TypeName = "datetime2")]
        [DataType(DataType.DateTime)]
        [Display(Name = "Birth date")]
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the Avatar
        /// </summary>
        [Column(@"Avatar", Order = 8, TypeName = "nvarchar(max)")]
        [Display(Name = "Avatar")]
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets the AddressID
        /// </summary>
        [Column(@"AddressID", Order = 9, TypeName = "int")]
        // [Index(@"IX_User_AddressID", 1, IsUnique = true, IsClustered = false)]
        [Display(Name = "Address ID")]
        public int? AddressID { get; set; }

        /// <summary>
        /// Gets or sets the AccountStatusID
        /// </summary>
        [Column(@"AccountStatusID", Order = 10, TypeName = "int")]
        // [Index(@"IX_User_AccountStatusID", 1, IsUnique = false, IsClustered = false)]
        [Display(Name = "Account status ID")]
        public int? AccountStatusID { get; set; }

        // Reverse navigation

        /// <summary>
        /// Gets or sets the ActivityParticipant
        /// Child ActivityParticipants where [ActivityParticipant].[ParticipantID] point to this entity (FK_ActivityParticipant_User_ParticipantID)
        /// </summary>
        [InverseProperty("Participant")]
        public virtual ICollection<ActivityParticipant> ActivityParticipants { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantCategories
        /// Child Categories (Many-to-Many) mapped by table [ParticipantCategory]
        /// </summary>
        [InverseProperty("Participant")]
        public virtual ICollection<ParticipantCategory> ParticipantCategories { get; set; }

        /// <summary>
        /// Gets or sets the Charity
        /// Child Charities where [Charity].[RepresentativeID] point to this entity (FK_Charity_User_RepresentativeID)
        /// </summary>
        [InverseProperty("Representative")]
        public virtual ICollection<Charity> Charities { get; set; }

        // Foreign keys

        /// <summary>
        /// Gets or sets the AccountStatus
        /// Parent AccountStatus pointed by [User].([AccountStatusId]) (FK_User_AccountStatus_AccountStatusID)
        /// </summary>
        [ForeignKey("AccountStatusID")]
        [InverseProperty("User")]
        public virtual AccountStatus AccountStatus { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// Parent Address pointed by [User].([AddressId]) (FK_User_Address_AddressID)
        /// </summary>
        [ForeignKey("AddressID")]
        [InverseProperty("User")]
        public virtual Address Address { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            this.ActivityParticipants = new HashSet<ActivityParticipant>();
            this.Charities = new HashSet<Charity>();
            this.ParticipantCategories = new HashSet<ParticipantCategory>();
        }
    }
}
