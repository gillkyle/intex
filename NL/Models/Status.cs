using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Status")]
    public class Status
    {
        [Key]
        public int StatusID { get; set; }
        public String StatusDescription { get; set; }
    }
}