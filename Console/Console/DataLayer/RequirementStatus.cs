namespace Console.DataLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="RequirementStatus" />
    /// </summary>
    [Table("RequirementStatus")]
    public partial class RequirementStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequirementStatus"/> class.
        /// </summary>
        public RequirementStatus()
        {
            this.Requirements = new HashSet<Requirement>();
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
        [InverseProperty("RequirementStatus")]
        public virtual ICollection<Requirement> Requirements { get; set; }
    }
}
