﻿using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class CommentService
    {
        private readonly Guid _userID;
        private readonly int postID;

        public CommentService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreateComment(CommentCreate model)
        {
            var entity =
                new Comment()
                {
                    UserID = _userID,
                    PostID = postID,
                    CommentText = model.CommentText
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<CommentListItem> GetComments()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                                new CommentListItem
                                {
                                    CommentID = e.CommentID,
                                    PostID = e.PostID,
                                    CommentText = e.CommentText
                                }
                        );
                return query.ToArray();
            }
        }
    }
}
