namespace Console.DataLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Country" />
    /// </summary>
    [Table("Country")]
    public partial class Country
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")] // [Column("ID")]
        // [Index(@"PK_Country", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// Label (length: 450)
        /// </summary>
        [Column(@"Label", Order = 2, TypeName = "nvarchar")]
        // [Index(@"AK_Country_Label", 1, IsUnique = true, IsClustered = false)]
        [Required(AllowEmptyStrings = true)] // [Required]
        [MaxLength(450)]
        [StringLength(450)]
        [Display(Name = "Label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Active
        /// </summary>
        [Column(@"Active", Order = 3, TypeName = "bit")]
        [Required]
        [Display(Name = "Active")]
        public bool Active { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether Disabled
        /// </summary>
        [Column(@"Disabled", Order = 4, TypeName = "bit")]
        [Required]
        [Display(Name = "Disabled")]
        public bool Disabled { get; set; }

        /// <summary>
        /// Gets or sets the Cities
        /// Child Cities where [City].[CountryID] point to this entity (FK_City_Country_CountryID)
        /// </summary>
        [InverseProperty("Country")]
        public virtual ICollection<City> Cities { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Country"/> class.
        /// </summary>
        public Country()
        {
            this.Cities = new HashSet<City>();
        }
    }
}
