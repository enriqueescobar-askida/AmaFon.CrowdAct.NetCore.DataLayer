using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class ParticipantCategory
    {
        public int ParticipantID { get; set; }
        public int CategoryID { get; set; }

        [ForeignKey("CategoryID")]
        [InverseProperty("ParticipantCategory")]
        public virtual Category Category { get; set; }
        [ForeignKey("ParticipantID")]
        [InverseProperty("ParticipantCategory")]
        public virtual User Participant { get; set; }
    }
}
