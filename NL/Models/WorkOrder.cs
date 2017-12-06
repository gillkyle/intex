using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace NL.Models
{
    [Table("WorkOrder")]
    public class WorkOrder
    {
        [Key]
        public int WorkOrderID { get; set; }
        [ForeignKey("BillDetail")]
        public int BillID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        [ForeignKey("Status")]
        public int StatusID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime EarlyDate { get; set; }
        public DateTime DueDate { get; set; }
        public String Description { get; set; }
        [ForeignKey("Priority")]
        public int PriorityID { get; set; }
        public virtual Priority Priority { get; set; }
        public float TotalQuote { get; set; }
        public float ActualPrice { get; set; }
        public float AdvanceAmtPaid { get; set; }
        public DateTime ConfirmationDate { get; set; }

    }
}