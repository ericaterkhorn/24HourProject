using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class CommentListItem
    {
        public int CommentID { get; set; }

        public Guid UserID { get; set; }

        public int PostID { get; set; }
     
        public string CommentText { get; set; }
    }
}
