namespace Console.DataLayer
{
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Requirement" />
    /// </summary>
    [Table("Requirement")]
    public partial class Requirement
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
        /// Gets or sets the TargetedQuantity
        /// </summary>
        public long TargetedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the CollectedQuantity
        /// </summary>
        public long CollectedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the ActivityID
        /// </summary>
        [Column("ActivityID")]
        public int ActivityID { get; set; }

        /// <summary>
        /// Gets or sets the ResourceTypeID
        /// </summary>
        [Column("ResourceTypeID")]
        public int? ResourceTypeID { get; set; }

        /// <summary>
        /// Gets or sets the RequirementStatusID
        /// </summary>
        [Column("RequirementStatusID")]
        public int? RequirementStatusID { get; set; }

        /// <summary>
        /// Gets or sets the Activity
        /// </summary>
        [ForeignKey("ActivityId")]
        [InverseProperty("Requirements")]
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Gets or sets the RequirementStatus
        /// </summary>
        [ForeignKey("RequirementStatusId")]
        [InverseProperty("Requirements")]
        public virtual RequirementStatus RequirementStatus { get; set; }

        /// <summary>
        /// Gets or sets the ResourceType
        /// </summary>
        [ForeignKey("ResourceTypeId")]
        [InverseProperty("Requirements")]
        public virtual ResourceType ResourceType { get; set; }
    }
}
