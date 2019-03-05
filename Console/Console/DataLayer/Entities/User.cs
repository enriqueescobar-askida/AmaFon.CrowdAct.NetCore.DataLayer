using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class User
    {
        public User()
        {
            ActivityParticipant = new HashSet<ActivityParticipant>();
            Charity = new HashSet<Charity>();
            ParticipantCategory = new HashSet<ParticipantCategory>();
        }

        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
        public DateTime? BirthDate { get; set; }
        public string Avatar { get; set; }
        public int? AddressID { get; set; }
        public int? AccountStatusID { get; set; }

        [ForeignKey("AccountStatusID")]
        [InverseProperty("User")]
        public virtual AccountStatus AccountStatus { get; set; }
        [ForeignKey("AddressID")]
        [InverseProperty("User")]
        public virtual Address Address { get; set; }
        [InverseProperty("Participant")]
        public virtual ICollection<ActivityParticipant> ActivityParticipant { get; set; }
        [InverseProperty("Representative")]
        public virtual ICollection<Charity> Charity { get; set; }
        [InverseProperty("Participant")]
        public virtual ICollection<ParticipantCategory> ParticipantCategory { get; set; }
    }
}
