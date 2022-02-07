namespace Mongo.Web
{
    public static class StaticDictionary
    {
        public static string ProductApiBase { get; set; }
        public enum ApiType
        {
            GET,
            POST,
            PUT,
            DELETE

        }

    }
}
