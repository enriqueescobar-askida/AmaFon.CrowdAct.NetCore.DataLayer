namespace Console.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="City" />
    /// </summary>
    [Table("City")]
    public partial class City
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")] // [Column("ID")]
        // [Index(@"PK_City", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// Label (length: 450)
        /// </summary>
        [Column(@"Label", Order = 2, TypeName = "nvarchar")]
        // [Index(@"AK_City_Label", 1, IsUnique = true, IsClustered = false)]
        [Required(AllowEmptyStrings = true)] // [Required]
        [MaxLength(450)]
        [StringLength(450)]
        [Display(Name = "Label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the CountryID
        /// </summary>
        [Column(@"CountryID", Order = 3, TypeName = "int")] // [Column("CountryID")]
        // [Index(@"IX_City_CountryID", 1, IsUnique = false, IsClustered = false)]
        [Required]
        [Display(Name = "Country ID")]
        public int CountryID { get; set; }

        // Reverse navigation

        /// <summary>
        /// Gets or sets the Addresses
        /// Child Addresses where [Address].[CityID] point to this entity (FK_Address_City_CityID)
        /// </summary>
        [ForeignKey("CountryId"), Required]
        [InverseProperty("City")]
        public virtual ICollection<Address> Addresses { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// Parent Country pointed by [City].([CountryId]) (FK_City_Country_CountryID)
        /// </summary>
        [ForeignKey("CountryId"), Required] // [ForeignKey("CountryId")]
        [InverseProperty("Cities")]
        public virtual Country Country { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="City"/> class.
        /// </summary>
        public City()
        {
            this.Addresses = new HashSet<Address>();
        }
    }
}
