namespace Console.DataLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Skill" />
    /// </summary>
    [Table("Skill")]
    public partial class Skill
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        public Skill()
        {
            ActivitySkills = new HashSet<ActivitySkill>();
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
        /// Gets or sets the ActivitySkills
        /// </summary>
        [InverseProperty("Skill")]
        public virtual ICollection<ActivitySkill> ActivitySkills { get; set; }
    }
}
