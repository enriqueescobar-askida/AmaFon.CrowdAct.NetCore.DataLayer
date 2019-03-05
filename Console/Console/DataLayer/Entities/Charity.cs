using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class Charity
    {
        public Charity()
        {
            Activity = new HashSet<Activity>();
        }

        public int ID { get; set; }
        public string OrgName { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }
        public string Certificate { get; set; }
        public DateTime RegisteredDate { get; set; }
        [Required]
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public string SIREN { get; set; }
        public string Logo { get; set; }
        public int RepresentativeID { get; set; }
        public int? AddressID { get; set; }
        public int? FieldID { get; set; }

        [ForeignKey("AddressID")]
        [InverseProperty("Charity")]
        public virtual Address Address { get; set; }
        [ForeignKey("FieldID")]
        [InverseProperty("Charity")]
        public virtual Category Field { get; set; }
        [ForeignKey("RepresentativeID")]
        [InverseProperty("Charity")]
        public virtual User Representative { get; set; }
        [InverseProperty("Charity")]
        public virtual ICollection<Activity> Activity { get; set; }
    }
}
