using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Comment
    {
        [Key]
        public int CommentID { get; set; }

        //[ForeignKey(nameof(User))]
        public Guid UserID { get; set; }

        [ForeignKey(nameof(Post))]
        public int PostID { get; set; }
        public virtual Post Post { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage = "You have exceeded the character limit")]
        public string CommentText { get; set; }
    }

    public class Reply : Comment
    {
        [Required]
        public int ReplyCommentID { get; set; }
    }
}
