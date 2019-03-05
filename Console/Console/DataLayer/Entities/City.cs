using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class City
    {
        public City()
        {
            Address = new HashSet<Address>();
        }

        public int ID { get; set; }
        [Required]
        public string Label { get; set; }
        public int CountryID { get; set; }

        [ForeignKey("CountryID")]
        [InverseProperty("City")]
        public virtual Country Country { get; set; }
        [InverseProperty("City")]
        public virtual ICollection<Address> Address { get; set; }
    }
}
