namespace Console.DataLayer.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ResourceType" />
    /// </summary>
    public partial class ResourceType
    {
        /// <summary>
        /// Gets or sets the ID
        /// ID (Primary key)
        /// </summary>
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"ID", Order = 1, TypeName = "int")]
        // [Index(@"PK_ResourceType", 1, IsUnique = true, IsClustered = true)]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public int ID { get; set; }

        /// <summary>
        /// Gets or sets the Label
        /// Label (length: 450)
        /// </summary>
        [Column(@"Label", Order = 2, TypeName = "nvarchar")]
        // [Index(@"AK_ResourceType_Label", 1, IsUnique = true, IsClustered = false)]
        [Required(AllowEmptyStrings = true)]
        [MaxLength(450)]
        [StringLength(450)]
        [Display(Name = "Label")]
        public string Label { get; set; }

        // Reverse navigation

        /// <summary>
        /// Gets or sets the Requirements
        /// Child Requirements where [Requirement].[ResourceTypeID] point to this entity (FK_Requirement_ResourceType_ResourceTypeID)
        /// </summary>
        [InverseProperty("ResourceType")]
        public virtual ICollection<Requirement> Requirements { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="ResourceType"/> class.
        /// </summary>
        public ResourceType()
        {
            this.Requirements = new HashSet<Requirement>();
        }
    }
}
