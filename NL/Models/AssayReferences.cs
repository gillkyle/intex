using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("AssayReferences")]
    public class AssayReferences
    {
        [Key]
        public int RefID { get; set; }
        [ForeignKey("Assay")]
        public int AssayID { get; set; }
        public virtual Assay Assay { get; set; }
        public string RefName { get; set; }
        public string RefSource { get; set; }

    }
}