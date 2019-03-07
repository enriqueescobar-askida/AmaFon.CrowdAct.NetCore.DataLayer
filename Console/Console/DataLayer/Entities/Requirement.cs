namespace Console.DataLayer.Entities
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="Requirement" />
    /// </summary>
    [Table("Requirement")]
    public partial class Requirement
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")] // [Column("ID")]
        // [Index(@"PK_Requirement", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Name
        /// </summary>
        // [Column(@"Name", Order = 2, TypeName = "nvarchar(max)")]
        [Display(Name = "Name")]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the TargetedQuantity
        /// </summary>
        // [Column(@"TargetedQuantity", Order = 3, TypeName = "bigint")]
        [Required]
        [Display(Name = "Targeted quantity")]
        public long TargetedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the CollectedQuantity
        /// </summary>
        // [Column(@"CollectedQuantity", Order = 4, TypeName = "bigint")]
        [Required]
        [Display(Name = "Collected quantity")]
        public long CollectedQuantity { get; set; }

        /// <summary>
        /// Gets or sets the ActivityID
        /// </summary>
        [Column(@"ActivityID", Order = 5, TypeName = "int")] // [Column("ActivityID")]
        // [Index(@"IX_Requirement_ActivityID", 1, IsUnique = false, IsClustered = false)]
        [Required]
        [Display(Name = "Activity ID")]
        public int ActivityID { get; set; }

        /// <summary>
        /// Gets or sets the ResourceTypeID
        /// </summary>
        [Column(@"ResourceTypeID", Order = 6, TypeName = "int")] // [Column("ResourceTypeID")]
        // [Index(@"IX_Requirement_ResourceTypeID", 1, IsUnique = false, IsClustered = false)]
        [Display(Name = "Resource type ID")]
        public int? ResourceTypeID { get; set; }

        /// <summary>
        /// Gets or sets the RequirementStatusID
        /// </summary>
        [Column(@"RequirementStatusID", Order = 7, TypeName = "int")] // [Column("RequirementStatusID")]
        // [Index(@"IX_Requirement_RequirementStatusID", 1, IsUnique = false, IsClustered = false)]
        [Display(Name = "Requirement status ID")]
        public int? RequirementStatusID { get; set; }

        // Foreign keys

        /// <summary>
        /// Gets or sets the Activity
        /// Parent Activity pointed by [Requirement].([ActivityId]) (FK_Requirement_Activity_ActivityID)
        /// </summary>
        [ForeignKey("ActivityId"), Required] // [ForeignKey("ActivityId")]
        [InverseProperty("Requirements")] // [InverseProperty("Requirement")]
        public virtual Activity Activity { get; set; }

        /// <summary>
        /// Gets or sets the RequirementStatus
        /// Parent RequirementStatus pointed by [Requirement].([RequirementStatusId]) (FK_Requirement_RequirementStatus_RequirementStatusID)
        /// </summary>
        [ForeignKey("RequirementStatusId")]
        [InverseProperty("Requirements")] // [InverseProperty("Requirement")]
        public virtual RequirementStatus RequirementStatus { get; set; }

        /// <summary>
        /// Gets or sets the ResourceType
        /// Parent ResourceType pointed by [Requirement].([ResourceTypeId]) (FK_Requirement_ResourceType_ResourceTypeID)
        /// </summary>
        [ForeignKey("ResourceTypeId")]
        [InverseProperty("Requirements")]
        public virtual ResourceType ResourceType { get; set; }
    }
}
