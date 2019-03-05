using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class Language
    {
        public Language()
        {
            ActivityLanguage = new HashSet<ActivityLanguage>();
        }

        public int ID { get; set; }
        [Required]
        public string Label { get; set; }
        public bool Active { get; set; }
        public bool Disabled { get; set; }

        [InverseProperty("Language")]
        public virtual ICollection<ActivityLanguage> ActivityLanguage { get; set; }
    }
}
