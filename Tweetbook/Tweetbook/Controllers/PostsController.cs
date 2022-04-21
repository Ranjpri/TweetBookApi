using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Tweetbook.Contract.V1;
using Tweetbook.Contract.V1.Request;
using Tweetbook.Contract.V1.Response;
using Tweetbook.Services;
using Posts = Tweetbook.Domain.Posts;

namespace Tweetbook.Controllers
{
    public class PostsController : Controller
    {
        private List<Posts> _posts;
        private readonly IPostService service;

        public PostsController(IPostService service)
        {
            this.service = service;
        }

        [HttpGet(ApiRoute.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(service.GetPosts());
        }

        [HttpGet(ApiRoute.Posts.GetById)]
        public IActionResult GetById([FromRoute] Guid postId)
        {
            return Ok(service.GetPostsById(postId));
        }

        [HttpPost(ApiRoute.Posts.Create)]
        public IActionResult Create(CreatePostRequest post)
        {
            if (post.Id == Guid.Empty)
                post.Id = Guid.NewGuid();

            _posts.Add(new Posts() { Id = post.Id });

            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";


            var locationUri = baseUri + $"/posts/{post.Id}";

            return Created(locationUri, new PostResponse() { Id = post.Id, Name = post.Name });
        }

        [HttpPut(ApiRoute.Posts.Update)]
        public IActionResult Update([FromRoute] Guid postId, [FromBody] UpdatePost post)
        {
            bool status = false;
            if (postId == post.Id)
            {
                status = service.UpdatePost(new Posts() { Id = post.Id, Name = post.Name });
            }

            if (status)
                return Ok();
            else
            {
                return NotFound();
            }
        }
    }
}