namespace Console.DataLayer
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Address" />
    /// </summary>
    [Table("Address")]
    public partial class Address
    {
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
        /// Gets or sets the Complement
        /// </summary>
        public string Complement { get; set; }

        /// <summary>
        /// Gets or sets the ZipCode
        /// </summary>
        public string ZipCode { get; set; }

        /// <summary>
        /// Gets or sets the CityID
        /// </summary>
        [Column("CityID")]
        public int? CityID { get; set; }

        /// <summary>
        /// Gets or sets the City
        /// </summary>
        [ForeignKey("CityId")]
        [InverseProperty("Addresses")]
        public virtual City City { get; set; }

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
    }
}
