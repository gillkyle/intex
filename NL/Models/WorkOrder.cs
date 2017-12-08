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
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int WorkOrderID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        [ForeignKey("BillDetail")]
        public int BillID { get; set; }
        public virtual BillDetail BillDetail { get; set; }
        [ForeignKey("Status")]
        public int StatusID { get; set; }
        public virtual Status Status { get; set; }
        [Required, DataType(DataType.Date)]
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public DateTime EarlyDate { get; set; }
        public DateTime DueDate { get; set; }
        [Required, StringLength(4000, MinimumLength = 10, ErrorMessage = "String should include compound name, required assays, etc")]
        public String Description { get; set; }
        [ForeignKey("Priority")]
        public int PriorityID { get; set; }
        public virtual Priority Priority { get; set; }
        public Decimal TotalQuote { get; set; }
        public Decimal ActualPrice { get; set; }
        public Decimal AdvanceAmtPaid { get; set; }
        public DateTime ConfirmationDate { get; set; }

    }
}