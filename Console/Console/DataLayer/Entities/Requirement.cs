using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class Requirement
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public long TargetedQuantity { get; set; }
        public long CollectedQuantity { get; set; }
        public int ActivityID { get; set; }
        public int? ResourceTypeID { get; set; }
        public int? RequirementStatusID { get; set; }

        [ForeignKey("ActivityID")]
        [InverseProperty("Requirement")]
        public virtual Activity Activity { get; set; }
        [ForeignKey("RequirementStatusID")]
        [InverseProperty("Requirement")]
        public virtual RequirementStatus RequirementStatus { get; set; }
        [ForeignKey("ResourceTypeID")]
        [InverseProperty("Requirement")]
        public virtual ResourceType ResourceType { get; set; }
    }
}
