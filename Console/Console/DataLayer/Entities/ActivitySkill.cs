namespace Console.DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ActivitySkill" />
    /// </summary>
    public partial class ActivitySkill
    {
        /// <summary>
        /// Gets or sets the ActivityID
        /// </summary>
        public int ActivityID { get; set; }

        /// <summary>
        /// Gets or sets the SkillID
        /// </summary>
        public int SkillID { get; set; }

        /// <summary>
        /// Gets or sets the Activity
        /// </summary>
        [ForeignKey("ActivityID")]
        [InverseProperty("ActivitySkill")]
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Gets or sets the Skill
        /// </summary>
        [ForeignKey("SkillID")]
        [InverseProperty("ActivitySkill")]
        public virtual Skill Skill { get; set; }
    }
}
