namespace Console.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="RequirementStatus" />
    /// </summary>
    public partial class RequirementStatus
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RequirementStatus"/> class.
        /// </summary>
        public RequirementStatus()
        {
            Requirement = new HashSet<Requirement>();
        }

        /// <summary>
        /// Gets or sets the ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// </summary>
        [Required]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the Requirement
        /// </summary>
        [InverseProperty("RequirementStatus")]
        public virtual ICollection<Requirement> Requirement { get; set; }
    }
}
