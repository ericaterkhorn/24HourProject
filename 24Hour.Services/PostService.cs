using _24Hour.Data;
using _24Hour.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace _24Hour.Services
{
    public class PostService
    {
        private readonly Guid _userID;

        public PostService(Guid userID)
        {
            _userID = userID;
        }

        public bool CreatePost(PostCreate model)
        {
            var entity =
                new Post()
                {
                    UserID = _userID,
                    Title = model.Title,
                    Text = model.Text,
                };
                using (var ctx = new ApplicationDbContext())
                {
                ctx.Posts.Add(entity);
                return ctx.SaveChanges() == 1;
                }
        }

        public IEnumerable<PostListItem> GetPosts()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var query =
                    ctx
                        .Posts
                        .Where(e => e.UserID == _userID)
                        .Select(
                            e =>
                            new PostListItem
                            {
                                PostID = e.PostID,
                                Title = e.Title,
                                Text = e.Text
                            }
                            );
                return query.ToArray();
            }
        }
    }
}
