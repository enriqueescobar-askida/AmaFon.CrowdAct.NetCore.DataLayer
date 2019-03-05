using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class Skill
    {
        public Skill()
        {
            ActivitySkill = new HashSet<ActivitySkill>();
        }

        public int ID { get; set; }
        [Required]
        public string Label { get; set; }

        [InverseProperty("Skill")]
        public virtual ICollection<ActivitySkill> ActivitySkill { get; set; }
    }
}
