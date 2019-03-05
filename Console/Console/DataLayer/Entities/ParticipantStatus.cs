using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class ParticipantStatus
    {
        public ParticipantStatus()
        {
            ActivityParticipant = new HashSet<ActivityParticipant>();
        }

        public int ID { get; set; }
        [Required]
        public string Label { get; set; }

        [InverseProperty("ParticipantStatus")]
        public virtual ICollection<ActivityParticipant> ActivityParticipant { get; set; }
    }
}
