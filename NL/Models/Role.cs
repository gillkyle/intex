using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Role")]
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public String RoleDesc { get; set; }
    }
}