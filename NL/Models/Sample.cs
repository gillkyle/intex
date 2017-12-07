using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Sample")]
    public class Sample
    {
        [Key]
        public int SampleID { get; set; }
        [ForeignKey("Compound")]
        public int LTNum { get; set; }
        public virtual Compound Compound { get; set; }
        public int SequenceCode { get; set; }
        public Decimal Concentration { get; set; }
        public Decimal Weight_mg { get; set; }

    }
}