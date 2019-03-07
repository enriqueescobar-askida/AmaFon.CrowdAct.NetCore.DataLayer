namespace Console.DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Address" />
    /// </summary>
    [Table("Address")]
    public partial class Address
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")] // [Column("ID")]
        // [Index(@"PK_Address", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        // [Column(@"Name", Order = 2, TypeName = "nvarchar(max)")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the Complement
        /// </summary>
        // [Column(@"Complement", Order = 3, TypeName = "nvarchar(max)")]
        [Display(Name = "Complement")]
        public string Complement { get; set; }

        /// <summary>
        /// Gets or sets the ZipCode
        /// </summary>
        // [Column(@"ZipCode", Order = 4, TypeName = "nvarchar(max)")]
        [DataType(DataType.PostalCode)]
        [Display(Name = "Zip code")]
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the CityID
        /// </summary>
        [Column(@"CityID", Order = 5, TypeName = "int")] // [Column("CityID")]
        // [Index(@"IX_Address_CityID", 1, IsUnique = false, IsClustered = false)]
        [Display(Name = "City ID")]
        public int? CityID { get; set; }

        /// <summary>
        /// Gets or sets the Activity
        /// </summary>
        [InverseProperty("Address")]
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Gets or sets the Charity
        /// </summary>
        [InverseProperty("Address")]
        public virtual Charity Charity { get; set; }

        /// <summary>
        /// Gets or sets the User
        /// </summary>
        [InverseProperty("Address")]
        public virtual User User { get; set; }

        // Foreign keys

        /// <summary>
        /// Gets or sets the City
        /// Parent City pointed by [Address].([CityId]) (FK_Address_City_CityID)
        /// </summary>
        [ForeignKey("CityId")]
        [InverseProperty("Addresses")]
        public virtual City City { get; set; }
    }
}
