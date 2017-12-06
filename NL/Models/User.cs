using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int UserId { get; set; }
        [Required, DisplayName("First Name"), StringLength(50, MinimumLength = 2, ErrorMessage = "First name must be between 2 and 50 characters long."),
            RegularExpression(@"^[A-Z][a-zA-Z.\- ]*$", ErrorMessage = "Capitalize last name. -. symbols allowed only.")] //regular expression only allows character and - symbol in name
        public String UserFirstName { get; set; }
        [Required, DisplayName("Last Name"), StringLength(50, MinimumLength = 2, ErrorMessage = "Last name must be between 2 and 50 characters long."),
            RegularExpression(@"^[A-Z][a-zA-Z.\- ]*$", ErrorMessage = "Capitalize last name. -. symbols allowed only.")] //regular expression only allows character and - symbol in name
        public String UserLastName { get; set; }
        public String UserAddress1 { get; set; }
        public String UserAddress2 { get; set; }
        [Required, DisplayName("Email"), StringLength(50, MinimumLength = 3, ErrorMessage = "Email must be between 3 and 50 characters long."),
            EmailAddress(ErrorMessage = "Improper email format.")] //has a bunch of validation, ensures email format and reasonable email length
        public String UserEmail { get; set; }
        [Required, DisplayName("Password"), StringLength(50, MinimumLength = 3, ErrorMessage = "Password must be between 3 and 50 characters long.")] //more validation
        public String UserPassword { get; set; }
        public String UserPhone { get; set; }
        [ForeignKey("ZIPCode")]
        public String UserZIP { get; set; }
        public virtual ZIPCode ZIPCode { get; set; }
        public float Balance { get; set; }
        [ForeignKey("Role")]
        public int RoleID { get; set; }
        public virtual Role Role { get; set; }
    }