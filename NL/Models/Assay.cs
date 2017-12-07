using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Assay")]
    public class Assay
    {
        [Key]
        public int AssayID { get; set; }
        public string Desc { get; set; }
        public string Summary { get; set; }
        public int DaysToComplete { get; set; }
        public Decimal MTD_mg { get; set; }
    }
}