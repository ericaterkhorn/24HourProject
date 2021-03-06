﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Data
{
    public class Post
    {
        [Key]
        public int PostID { get; set; }

        //[ForeignKey(nameof(User))]
        public Guid UserID { get; set; }

        [Display(Name = "Your Post")]
        public string Title { get; set; }

        [MaxLength(130, ErrorMessage = "You have exceeded the character limit")]
        public string Text { get; set; }

        public List<Comment> Comments { get; set; }
    }
}
