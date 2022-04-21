using System;
using System.Collections.Generic;
using System.Linq;
using Tweetbook.Contract.V1.Request;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public class PostsService : IPostService
    {
        private List<Posts> _posts;

        public PostsService()
        {
            _posts = new List<Posts>();
            for (var i = 0; i < 5; i++)
            {
                _posts.Add(new Posts(){Id = Guid.NewGuid(), Name=$"Post {i}"});
            }

        }

        public IEnumerable<Posts> GetPosts()
        {
            return _posts;
        }
        
        public Posts GetPostsById(Guid Id)
        {
            return _posts.SingleOrDefault(c=>c.Id == Id);
        }

        public bool UpdatePost(Posts post)
        {
            var p = GetPostsById(post.Id);
            if (post != null)
            {
                var index = _posts.FindIndex(c => c.Id == post.Id);
                _posts[index] = post;
                return true;
            }

            return false;
        }
    }
}