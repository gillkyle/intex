using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace NL.Models
{
    [Table("SampleAssay")]
    public class SampleAssay
    {
        [Key, ForeignKey("Sample")]
        [Column(Order = 0)]
        public int SampleID { get; set; }
        public virtual Sample Sample { get; set; }
        [Key, ForeignKey("Assay")]
        [Column(Order = 1)]
        public int AssayID { get; set; }
        public virtual Assay Assay { get; set; }
        public String Comment { get; set; }

    }
}