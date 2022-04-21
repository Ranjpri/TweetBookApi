using System;

namespace Tweetbook.Contract.V1.Request
{
    public class UpdatePost
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}