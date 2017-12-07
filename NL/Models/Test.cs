using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Test")]
    public class Test
    {
        [Key]
        public int TestID { get; set; }
        [ForeignKey("TestType")]
        public int TestTypeID { get; set; }
        public virtual TestType TestType { get; set; }
        public String Desc { get; set; }
        public int SetupTimeMins { get; set; }
        public bool Required { get; set; }
        public Decimal Cost { get; set; }
        public Decimal Quote { get; set; }
    }
}