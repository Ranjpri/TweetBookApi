﻿using System;

namespace Tweetbook.Contract.V1.Request
{
    public class CreatePostRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}