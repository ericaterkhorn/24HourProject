using _24Hour.Models;
using _24Hour.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace _24Hour.WebAPI.Controllers
{
    [Authorize]
    public class CommentController : ApiController
    {
        private CommentService CreateCommentService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var commentService = new CommentService(userID);
            return commentService;
        }

        [Route("{postID}")]
        public IHttpActionResult Get([FromUri] int postID)
        {
            CommentService commentService = CreateCommentService();
            var comments = commentService.GetComments(postID);
            return Ok(comments);
        }
        public IHttpActionResult Post(CommentCreate comment, [FromUri] int postID)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            CommentService commentService = CreateCommentService();

            if (!commentService.CreateComment(comment, postID))
                return InternalServerError();

            return Ok();
        }

    }
}
