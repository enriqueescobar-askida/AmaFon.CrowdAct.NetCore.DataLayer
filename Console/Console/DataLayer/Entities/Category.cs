using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class Category
    {
        public Category()
        {
            Activity = new HashSet<Activity>();
            Charity = new HashSet<Charity>();
            ParticipantCategory = new HashSet<ParticipantCategory>();
        }

        public int ID { get; set; }
        [Required]
        public string Label { get; set; }

        [InverseProperty("Field")]
        public virtual ICollection<Activity> Activity { get; set; }
        [InverseProperty("Field")]
        public virtual ICollection<Charity> Charity { get; set; }
        [InverseProperty("Category")]
        public virtual ICollection<ParticipantCategory> ParticipantCategory { get; set; }
    }
}
