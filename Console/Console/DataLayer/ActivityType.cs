namespace Console.DataLayer
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    /// <summary>
    /// Defines the <see cref="ActivityType" />
    /// </summary>
    [Table("ActivityType")]
    public partial class ActivityType
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ActivityType"/> class.
        /// </summary>
        public ActivityType()
        {
            Activities = new HashSet<Activity>();
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
        /// Gets or sets the Activities
        /// </summary>
        [InverseProperty("ActivityType")]
        public virtual ICollection<Activity> Activities { get; set; }
    }
}
