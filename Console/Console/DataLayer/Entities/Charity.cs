namespace Console.DataLayer.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Charity" />
    /// </summary>
    public partial class Charity
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")]
        // [Index(@"PK_Charity", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the OrgName
        /// </summary>
        [Column(@"OrgName", Order = 2, TypeName = "nvarchar(max)")]
        [Display(Name = "Org name")]
        public string OrgName { get; set; }

        /// <summary>
        /// Gets or sets the Description
        /// </summary>
        [Column(@"Description", Order = 3, TypeName = "nvarchar(max)")]
        [Display(Name = "Description")]
        public string Description { get; set; }

        /// <summary>
        /// Gets or sets the Picture
        /// </summary>
        [Column(@"Picture", Order = 4, TypeName = "nvarchar(max)")]
        [Display(Name = "Picture")]
        public string Picture { get; set; }

        /// <summary>
        /// Gets or sets the Certificate
        /// </summary>
        [Column(@"Certificate", Order = 5, TypeName = "nvarchar(max)")]
        [Display(Name = "Certificate")]
        public string Certificate { get; set; }

        /// <summary>
        /// Gets or sets the RegisteredDate
        /// </summary>
        [Column(@"RegisteredDate", Order = 6, TypeName = "datetime2")]
        [Required]
        [DataType(DataType.DateTime)]
        [Display(Name = "Registered date")]
        public DateTime RegisteredDate { get; set; }

        /// <summary>
        /// Gets or sets the Email
        /// Email (length: 450)
        /// </summary>
        [Column(@"Email", Order = 7, TypeName = "nvarchar")]
        // [Index(@"AK_Charity_Email", 1, IsUnique = true, IsClustered = false)]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(450)]
        [StringLength(450)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        /// <summary>
        /// Gets or sets the Phone
        /// </summary>
        [Column(@"Phone", Order = 8, TypeName = "nvarchar(max)")]
        [Phone]
        [Display(Name = "Phone")]
        public string Phone { get; set; }

        /// <summary>
        /// Gets or sets the Website
        /// </summary>
        [Column(@"Website", Order = 9, TypeName = "nvarchar(max)")]
        [Display(Name = "Website")]
        public string Website { get; set; }

        /// <summary>
        /// Gets or sets the SIREN
        /// </summary>
        [Column(@"SIREN", Order = 10, TypeName = "nvarchar(max)")]
        [Display(Name = "Siren")]
        public string SIREN { get; set; }

        /// <summary>
        /// Gets or sets the Logo
        /// </summary>
        [Column(@"Logo", Order = 11, TypeName = "nvarchar(max)")]
        [Display(Name = "Logo")]
        public string Logo { get; set; }

        /// <summary>
        /// Gets or sets the RepresentativeID
        /// </summary>
        [Column(@"RepresentativeID", Order = 12, TypeName = "int")]
        // [Index(@"IX_Charity_RepresentativeID", 1, IsUnique = false, IsClustered = false)]
        [Required]
        [Display(Name = "Representative ID")]
        public int RepresentativeID { get; set; }

        /// <summary>
        /// Gets or sets the AddressID
        /// </summary>
        [Column(@"AddressID", Order = 13, TypeName = "int")]
        // [Index(@"IX_Charity_AddressID", 1, IsUnique = true, IsClustered = false)]
        [Display(Name = "Address ID")]
        public int? AddressID { get; set; }

        /// <summary>
        /// Gets or sets the FieldID
        /// </summary>
        [Column(@"FieldID", Order = 14, TypeName = "int")]
        // [Index(@"IX_Charity_FieldID", 1, IsUnique = false, IsClustered = false)]
        [Display(Name = "Field ID")]
        public int? FieldID { get; set; }

        // Reverse navigation

        /// <summary>
        /// Gets or sets the Activities
        /// Child Activities where [Activity].[CharityID] point to this entity (FK_Activity_Charity_CharityID)
        /// </summary>
        [InverseProperty("Charity")]
        public virtual ICollection<Activity> Activities { get; set; }

        // Foreign keys

        /// <summary>
        /// Gets or sets the Address
        /// Parent Address pointed by [Charity].([AddressId]) (FK_Charity_Address_AddressID)
        /// </summary>
        [ForeignKey("AddressID")]
        [InverseProperty("Charity")]
        public virtual Address Address { get; set; }

        /// <summary>
        /// Gets or sets the Field
        /// Parent Category pointed by [Charity].([FieldId]) (FK_Charity_Category_FieldID)
        /// </summary>
        [ForeignKey("FieldID")]
        [InverseProperty("Charity")]
        public virtual Category Field { get; set; }

        /// <summary>
        /// Gets or sets the Representative
        /// Parent User pointed by [Charity].([RepresentativeId]) (FK_Charity_User_RepresentativeID)
        /// </summary>
        [ForeignKey("RepresentativeId"), Required]
        [InverseProperty("Charity")]
        public virtual User Representative { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Charity"/> class.
        /// </summary>
        public Charity()
        {
            this.Activities = new HashSet<Activity>();
        }
    }
}
