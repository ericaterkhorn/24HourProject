using _24Hour.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Models
{
    public class PostDetail
    {        
        public int PostID { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public List<CommentListItem> Comments { get; set; } = new List<CommentListItem>();
        //public List<Guid> UserLikes { get; set; } = new List<Guid>();
    }
}
