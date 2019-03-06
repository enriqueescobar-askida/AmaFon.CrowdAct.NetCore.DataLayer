namespace Console.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="User" />
    /// </summary>
    [Table("User")]
    public partial class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class.
        /// </summary>
        public User()
        {
            ActivityParticipants = new HashSet<ActivityParticipant>();
            Charities = new HashSet<Charity>();
            ParticipantCategories = new HashSet<ParticipantCategory>();
        }

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the FirstName
        /// </summary>
        public string FirstName { get; set; }

        /// <summary>
        /// Gets or sets the LastName
        /// </summary>
        public string LastName { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Password
        /// </summary>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets the Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the BirthDate
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// Gets or sets the Avatar
        /// </summary>
        public string Avatar { get; set; }

        /// <summary>
        /// Gets or sets the AddressID
        /// </summary>
        [Column("AddressID")]
        public int? AddressID { get; set; }

        /// <summary>
        /// Gets or sets the AccountStatusID
        /// </summary>
        [Column("AccountStatusID")]
        public int? AccountStatusID { get; set; }

        /// <summary>
        /// Gets or sets the AccountStatus
        /// </summary>
        [ForeignKey("AccountStatusId")]
        [InverseProperty("Users")]
        public virtual AccountStatus AccountStatus { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        [ForeignKey("AddressId")]
        [InverseProperty("User")]
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the ActivityParticipants
        /// </summary>
        [InverseProperty("Participant")]
        public virtual ICollection<ActivityParticipant> ActivityParticipants { get; set; }

        /// <summary>
        /// Gets or sets the Charities
        /// </summary>
        [InverseProperty("Representative")]
        public virtual ICollection<Charity> Charities { get; set; }

        /// <summary>
        /// Gets or sets the ParticipantCategories
        /// </summary>
        [InverseProperty("Participant")]
        public virtual ICollection<ParticipantCategory> ParticipantCategories { get; set; }
    }
}
