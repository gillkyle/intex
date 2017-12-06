using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace NL.Models
{
    [Table("Question")]
    public class Question
    {
        [Key]
        public int QuestionId { get; set; } //unique identifier of QuestionID

        [ForeignKey("User")] //connects to user table via virtual table and userId foreign key
        public int UserId { get; set; }
        public virtual User User { get; set; }

        [Required, DisplayName("Question Description"), StringLength(500, MinimumLength = 3, ErrorMessage = "Question must be between 3 and 500 characters long."),
            RegularExpression(@"^[A-Z].*$", ErrorMessage = "Capitalize question.")] //adds data validation to make sure question begins capitalized. Minimum length of 3 characters, max of 500
        public String QuestionDesc { get; set; }
    }
}