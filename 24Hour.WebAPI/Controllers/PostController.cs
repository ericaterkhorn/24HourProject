﻿using _24Hour.Models;
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
    public class PostController : ApiController
    {
        private PostService CreatePostService()
        {
            var userID = Guid.Parse(User.Identity.GetUserId());
            var postService = new PostService(userID);
            return postService;
        }

        // Get All
        public IHttpActionResult Get()
        {
            PostService postService = CreatePostService();
            var posts = postService.GetPosts();
            return Ok(posts);
        }

        // Get Specific Post
        public IHttpActionResult Get(int id)
        {
            PostService postService = CreatePostService();
            var post = postService.GetPostByID(id);
            return Ok(post);
        }

        // Create Post 
        public IHttpActionResult Post(PostCreate post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PostService postService = CreatePostService();

            if (!postService.CreatePost(post))
                return InternalServerError();

            return Ok();
        }

        // Update Post
        public IHttpActionResult Put(PostEdit post)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            PostService postService = CreatePostService();

            if (!postService.UpdatePost(post))
                return InternalServerError();

            return Ok();
        }
    }
}
