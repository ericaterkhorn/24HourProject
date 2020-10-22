using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class CommentCreate
    {
        [Required]
        public int PostID { get; set; }

        [Required]
        [MaxLength(130)]
        public string CommentText { get; set; }
    }
}
