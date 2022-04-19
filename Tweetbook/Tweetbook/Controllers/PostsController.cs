using System;
using System.Collections.Generic;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Tweetbook.Contract.V1;
using Tweetbook.Contract.V1.Request;
using Tweetbook.Contract.V1.Response;
using Posts = Tweetbook.Domain.Posts;

namespace Tweetbook.Controllers
{
    public class PostsController:Controller
    {
        private List<Posts> _posts;
        public PostsController()
        {
            _posts = new List<Posts>();
            for (var i = 0; i < 5; i++)
            {
                _posts.Add(new Posts(){Id = Guid.NewGuid().ToString()});
            }
        }
        [HttpGet(ApiRoute.Posts.GetAll)]
        public IActionResult GetAll()
        {
            return Ok(_posts);
        }

        [HttpPost(ApiRoute.Posts.Create)]
        public IActionResult Create(CreatePostRequest post)
        {
            if (string.IsNullOrWhiteSpace(post.Id))
                post.Id = Guid.NewGuid().ToString();
            
            _posts.Add(new Posts(){Id = post.Id});

            var baseUri = $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host.ToUriComponent()}";


            var locationUri = baseUri + $"/posts/{post.Id}";

            return Created(locationUri, new PostResponse(){Id= post.Id});
        }
    }
}