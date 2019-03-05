using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Console.DataLayer.Entities
{
    public partial class ActivityLanguage
    {
        public int ActivityID { get; set; }
        public int LanguageID { get; set; }
        public bool Main { get; set; }

        [ForeignKey("ActivityID")]
        [InverseProperty("ActivityLanguage")]
        public virtual Activity Activity { get; set; }
        [ForeignKey("LanguageID")]
        [InverseProperty("ActivityLanguage")]
        public virtual Language Language { get; set; }
    }
}
