namespace Console.DataLayer
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
        /// Initializes a new instance of the <see cref="City"/> class.
        /// </summary>
        public City()
        {
            Addresses = new HashSet<Address>();
        }

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        [Column("ID")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// </summary>
        [Required]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the CountryID
        /// </summary>
        [Column("CountryID")]
        public int CountryID { get; set; }

        /// <summary>
        /// Gets or sets the Country
        /// </summary>
        [ForeignKey("CountryId")]
        [InverseProperty("Cities")]
        public virtual Country Country { get; set; }

        /// <summary>
        /// Gets or sets the Addresses
        /// </summary>
        [InverseProperty("City")]
        public virtual ICollection<Address> Addresses { get; set; }
    }
}
