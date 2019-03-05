using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class ActivityParticipant
    {
        public int ActivityID { get; set; }
        public int ParticipantID { get; set; }
        public int? ParticipantStatusID { get; set; }

        [ForeignKey("ActivityID")]
        [InverseProperty("ActivityParticipant")]
        public virtual Activity Activity { get; set; }
        [ForeignKey("ParticipantID")]
        [InverseProperty("ActivityParticipant")]
        public virtual User Participant { get; set; }
        [ForeignKey("ParticipantStatusID")]
        [InverseProperty("ActivityParticipant")]
        public virtual ParticipantStatus ParticipantStatus { get; set; }
    }
}
