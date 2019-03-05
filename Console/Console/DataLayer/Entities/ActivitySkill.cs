using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class ActivitySkill
    {
        public int ActivityID { get; set; }
        public int SkillID { get; set; }

        [ForeignKey("ActivityID")]
        [InverseProperty("ActivitySkill")]
        public virtual Activity Activity { get; set; }
        [ForeignKey("SkillID")]
        [InverseProperty("ActivitySkill")]
        public virtual Skill Skill { get; set; }
    }
}
