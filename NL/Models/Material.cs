using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Material")]
    public class Material
    {
        [Key]
        public int MaterialID { get; set; }
        public String Name { get; set; }
        public float Cost_per_g { get; set; }
        public float Available_g { get; set; }
        public float ReorderPoint_g { get; set; }
    }
}