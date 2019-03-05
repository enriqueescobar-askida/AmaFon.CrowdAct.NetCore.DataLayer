using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class ResourceType
    {
        public ResourceType()
        {
            Requirement = new HashSet<Requirement>();
        }

        public int ID { get; set; }
        [Required]
        public string Label { get; set; }

        [InverseProperty("ResourceType")]
        public virtual ICollection<Requirement> Requirement { get; set; }
    }
}
