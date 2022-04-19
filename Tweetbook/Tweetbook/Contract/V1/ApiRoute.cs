namespace Tweetbook.Contract.V1
{
    public static class ApiRoute
    {
        public const string Root = "api";
        public const string Version = "v1";
        public const string Base =Root+"/"+Version;

        public static class Posts
        {
            public const string GetAll = Base+"/posts";
            public const string Create = Base+"/posts";
            public const string GetById = Base+"/posts/{postId}";
        }
    }
}