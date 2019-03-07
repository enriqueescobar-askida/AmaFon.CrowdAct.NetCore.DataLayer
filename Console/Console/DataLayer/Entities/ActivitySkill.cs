namespace Console.DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ActivitySkill" />
    /// </summary>
    [Table("ActivitySkill")]
    public partial class ActivitySkill
    {
        /// <summary>
        /// Gets or sets the ActivityID
        /// </summary>
        [Column("ActivityID")]
        public int ActivityID { get; set; }

        /// <summary>
        /// Gets or sets the SkillID
        /// </summary>
        [Column("SkillID")]
        public int SkillID { get; set; }

        /// <summary>
        /// Gets or sets the Activity
        /// </summary>
        [ForeignKey("ActivityId")]
        [InverseProperty("ActivitySkills")]
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Gets or sets the Skill
        /// </summary>
        [ForeignKey("SkillId")]
        [InverseProperty("ActivitySkills")]
        public virtual Skill Skill { get; set; }
    }
}
