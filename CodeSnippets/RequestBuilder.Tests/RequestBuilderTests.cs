namespace RequestBuilder.Tests
{
    public class RequestBuilderTests
    {
        [Fact]
        public void Build_ReturnsValidRequest()
        {
            // Arrange
            var builder = new RequestBuilder();

            // Act
            var request = builder.Build();

            // Assert
            Assert.NotNull(request);
            Assert.IsType<Request>(request);
        }

        [Fact]
        public void WithUrl_SetsUrlInRequest()
        {
            // Arrange
            var builder = new RequestBuilder();
            var expectedUrl = "https://example.com";

            // Act
            var request = builder.WithUrl(expectedUrl).Build();

            // Assert
            Assert.Equal(expectedUrl, request.Url);
        }

        [Fact]
        public void WithBody_SetsBodyInRequest()
        {
            // Arrange
            var builder = new RequestBuilder();
            var expectedBody = "Request body goes here.";

            // Act
            var request = builder.WithBody(expectedBody).Build();

            // Assert
            Assert.Equal(expectedBody, request.Body);
        }

        [Fact]
        public void WithHeader_SetsHeaderInRequest()
        {
            // Arrange
            var builder = new RequestBuilder();
            var expectedHeader = "Content-Type: application/json";

            // Act
            var request = builder.WithHeader(expectedHeader).Build();

            // Assert
            Assert.Equal(expectedHeader, request.Header);
        }

        [Fact]
        public void Print_ReturnsFormattedString()
        {
            // Arrange
            var request = new Request
            {
                Url = "https://example.com",
                Body = "Request body goes here.",
                Header = "Content-Type: application/json"
            };

            // Act
            var result = request.Print();

            // Assert
            Assert.Equal("Url: https://example.com, Body: Request body goes here., Header: Content-Type: application/json", result);
        }
    }
}