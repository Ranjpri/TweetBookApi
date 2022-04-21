using System;
using System.Collections.Generic;
using Tweetbook.Domain;

namespace Tweetbook.Services
{
    public interface IPostService
    {
            IEnumerable<Posts> GetPosts();
            Posts GetPostsById(Guid Id);

            bool UpdatePost(Posts post);

    }
}