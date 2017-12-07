using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("WorkOrderDiscount")]
    public class WorkOrderDiscount
    {
        [Key, ForeignKey("WorkOrder")]
        public int WorkOrderID { get; set; }
        public virtual WorkOrder WorkOrder { get; set; }
        [Key, ForeignKey("Discount")]
        public int DiscountID { get; set; }
        public virtual Discount Discount { get; set; }
    }
}