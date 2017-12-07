using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("TestMaterial")]
    public class TestMaterial
    {
        [Key, ForeignKey("Material")]
        public int MaterialID { get; set; }
        public virtual Material Material { get; set; }
        [Key, ForeignKey("Test")]
        public int TestID { get; set; }
        public virtual Test Test { get; set; }
        public float Quantity_g { get; set; }

    }
}