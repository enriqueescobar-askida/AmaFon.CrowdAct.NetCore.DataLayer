using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class ActivityType
    {
        public ActivityType()
        {
            Activity = new HashSet<Activity>();
        }

        public int ID { get; set; }
        [Required]
        public string Label { get; set; }

        [InverseProperty("ActivityType")]
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
