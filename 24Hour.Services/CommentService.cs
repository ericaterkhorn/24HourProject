using _24Hour.Data;
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
        //private readonly int _postID;

        public CommentService(Guid userID/*, int postID*/)
        {
            _userID = userID;
            //_postID = postID;
        }

        public bool CreateComment(CommentCreate model, int postID)
        {
            var entity =
                new Comment()
                {
                    UserID = _userID,
                    //PostID = _postID,
                    //PostID = postID,
                    CommentText = model.CommentText
                };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Comments.Add(entity);
                return ctx.SaveChanges() == 1;
            }

        }

        public IEnumerable<CommentListItem> GetComments(int postID)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Comments
                        //.Where(e => e.PostID == _postID)
                        .Where(e => e.PostID == postID)
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
