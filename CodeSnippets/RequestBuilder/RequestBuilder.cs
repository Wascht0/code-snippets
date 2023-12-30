namespace RequestBuilder
{
    public class RequestBuilder
    {
        private Request _reqeust { get; set; }

        public RequestBuilder()
        {
            _reqeust = new Request();
        }

        public Request Build()
        {
            return _reqeust;
        }

        public RequestBuilder WithUrl(string url)
        {
            _reqeust.Url = url;

            return this;
        }

        public RequestBuilder WithBody(string body)
        {
            _reqeust.Body = body;

            return this;
        }

        public RequestBuilder WithHeader(string header)
        {
            _reqeust.Header = header;

            return this;
        }
    }
}
