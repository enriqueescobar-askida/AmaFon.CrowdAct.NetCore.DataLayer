using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class Country
    {
        public Country()
        {
            City = new HashSet<City>();
        }

        public int ID { get; set; }
        [Required]
        public string Label { get; set; }
        public bool Active { get; set; }
        public bool Disabled { get; set; }

        [InverseProperty("Country")]
        public virtual ICollection<City> City { get; set; }
    }
}
