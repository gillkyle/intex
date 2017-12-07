using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("AssayTest")]
    public class AssayTest
    {
        [Key, ForeignKey("Assay")]
        [Column(Order = 0)]
        public int AssayID { get; set; }
        public virtual Assay Assay { get; set; }
        [Key, ForeignKey("Test")]
        [Column(Order = 1)]
        public int TestID { get; set; }
        public virtual Test Test { get; set; }
        public bool Active { get; set; }
        public bool Complete { get; set; }
        public String Comment { get; set; }
        public DateTime Scheduled { get; set; }
        public bool Required { get; set; }
        public bool Approval { get; set; }
        public String QuantResults { get; set; }
        public String QualResults { get; set; }

    }
}