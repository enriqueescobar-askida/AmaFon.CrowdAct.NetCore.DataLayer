namespace Console.DataLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="AccountStatus" />
    /// </summary>
    [Table("AccountStatus")]
    public partial class AccountStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AccountStatus"/> class.
        /// </summary>
        public AccountStatus()
        {
            Users = new HashSet<User>();
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
        /// Gets or sets the Users
        /// </summary>
        [InverseProperty("AccountStatus")]
        public virtual ICollection<User> Users { get; set; }
    }
}
