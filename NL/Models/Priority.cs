using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Priority")]
    public class Priority
    {
        [Key]
        public int PriorityID { get; set; }
        public String Description { get; set; }
    }
}