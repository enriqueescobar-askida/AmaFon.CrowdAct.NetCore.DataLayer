namespace Console.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="AccountStatus" />
    /// </summary>
    public partial class AccountStatus
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")]
        // [Index(@"PK_AccountStatus", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// Label (length: 450)
        /// </summary>
        [Column(@"Label", Order = 2, TypeName = "nvarchar")]
        // [Index(@"AK_AccountStatus_Label", 1, IsUnique = true, IsClustered = false)]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(450)]
        [StringLength(450)]
        [Display(Name = "Label")]
        public string Label { get; set; }

        // Reverse navigation

        /// <summary>
        /// Gets or sets the User
        /// </summary>
        [InverseProperty("AccountStatus")]
        public virtual ICollection<User> Users { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="AccountStatus"/> class.
        /// </summary>
        public AccountStatus()
        {
            this.Users = new HashSet<User>();
        }
    }
}
