using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class Address
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Complement { get; set; }
        public string ZipCode { get; set; }
        public int? CityID { get; set; }

        [ForeignKey("CityID")]
        [InverseProperty("Address")]
        public virtual City City { get; set; }
        [InverseProperty("Address")]
        public virtual Activity Activity { get; set; }
        [InverseProperty("Address")]
        public virtual Charity Charity { get; set; }
        [InverseProperty("Address")]
        public virtual User User { get; set; }
    }
}
