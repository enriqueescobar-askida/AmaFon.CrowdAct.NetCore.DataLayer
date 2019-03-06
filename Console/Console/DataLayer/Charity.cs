namespace Console.DataLayer
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Charity" />
    /// </summary>
    [Table("Charity")]
    public partial class Charity
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Charity"/> class.
        /// </summary>
        public Charity()
        {
            Activities = new HashSet<Activity>();
        }

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the OrgName
        /// </summary>
        public string OrgName { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Picture
        /// </summary>
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets the Certificate
        /// </summary>
        public string Certificate { get; set; }

        /// <summary>
        /// Gets or sets the RegisteredDate
        /// </summary>
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// </summary>
        [Required]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Phone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the Website
        /// </summary>
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the Siren
        /// </summary>
        [Column("SIREN")]
        public string Siren { get; set; }

        /// <summary>
        /// Gets or sets the Logo
        /// </summary>
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets the RepresentativeID
        /// </summary>
        [Column("RepresentativeID")]
        public int RepresentativeID { get; set; }

        /// <summary>
        /// Gets or sets the AddressID
        /// </summary>
        [Column("AddressID")]
        public int? AddressID { get; set; }

        /// <summary>
        /// Gets or sets the FieldID
        /// </summary>
        [Column("FieldID")]
        public int? FieldID { get; set; }

        /// <summary>
        /// Gets or sets the Address
        /// </summary>
        [ForeignKey("AddressId")]
        [InverseProperty("Charity")]
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the Field
        /// </summary>
        [ForeignKey("FieldId")]
        [InverseProperty("Charities")]
        public virtual Category Field { get; set; }

        /// <summary>
        /// Gets or sets the Representative
        /// </summary>
        [ForeignKey("RepresentativeId")]
        [InverseProperty("Charities")]
        public virtual User Representative { get; set; }

        /// <summary>
        /// Gets or sets the Activities
        /// </summary>
        [InverseProperty("Charity")]
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
