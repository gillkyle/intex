using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Discount")]
    public class Discount
    {
        [Key]
        public int DiscountID { get; set; }
        public String Desc { get; set; }
        public float PercentOff { get; set; }
    }
}