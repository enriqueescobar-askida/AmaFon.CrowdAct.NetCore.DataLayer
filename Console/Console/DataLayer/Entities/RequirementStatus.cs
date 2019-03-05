using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class RequirementStatus
    {
        public RequirementStatus()
        {
            Requirement = new HashSet<Requirement>();
        }

        public int ID { get; set; }
        [Required]
        public string Label { get; set; }

        [InverseProperty("RequirementStatus")]
        public virtual ICollection<Requirement> Requirement { get; set; }
    }
}
