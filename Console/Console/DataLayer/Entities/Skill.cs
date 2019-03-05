namespace Console.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Skill" />
    /// </summary>
    public partial class Skill
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")]
        // [Index(@"PK_Skill", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// Label (length: 450)
        /// </summary>
        [Column(@"Label", Order = 2, TypeName = "nvarchar")]
        // [Index(@"AK_Skill_Label", 1, IsUnique = true, IsClustered = false)]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(450)]
        [StringLength(450)]
        [Display(Name = "Label")]
        public string Label { get; set; }

        /// <summary>
        /// Gets or sets the ActivitySkill
        /// Child Activities (Many-to-Many) mapped by table [ActivitySkill]
        /// </summary>
        [InverseProperty("Skill")]
        public virtual ICollection<ActivitySkill> ActivitySkills { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="Skill"/> class.
        /// </summary>
        public Skill()
        {
            this.ActivitySkills = new HashSet<ActivitySkill>();
        }
    }
}
