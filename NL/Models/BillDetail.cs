using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("BillDetail")]
    public class BillDetail
    {
        [Key]
        public int BillID { get; set; }
        [ForeignKey("User")]
        public int UserID { get; set; }
        public virtual User User { get; set; }
        public String BillFirstName { get; set; }
        public String BillLastName { get; set; }
        public String BillAddress1 { get; set; }
        public String BillAddress2 { get; set; }
        public String BillEmail { get; set; }
        public String BillPhone { get; set; }
        [ForeignKey("ZIPCode")]
        public String BillZIP { get; set; }
        public virtual ZIPCode ZIPCode { get; set; }
        public String LastFourCred { get; set; }

    }
}