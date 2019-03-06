namespace Console.DataLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ResourceType" />
    /// </summary>
    [Table("ResourceType")]
    public partial class ResourceType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceType"/> class.
        /// </summary>
        public ResourceType()
        {
            Requirements = new HashSet<Requirement>();
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
        /// Gets or sets the Requirements
        /// </summary>
        [InverseProperty("ResourceType")]
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
