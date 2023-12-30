namespace Strategy.Tests
{
    public class ShopTests
    {
        [Fact]
        public void PayWithGoogle_ReturnsExpectedResult()
        {
            // Arrange
            var shop = new Shop(new CheckOutWithGoogle());

            // Act
            var result = shop.Pay(100.0);

            // Assert
            Assert.Equal("pay with goole ok", result);
        }

        [Fact]
        public void PayWithApple_ReturnsExpectedResult()
        {
            // Arrange
            var shop = new Shop(new CheckOutWithApple());

            // Act
            var result = shop.Pay(150.0);

            // Assert
            Assert.Equal("pay with apple ok", result);
        }

        [Fact]
        public void ChangeCheckOut_PayWithNewStrategy_ReturnsExpectedResult()
        {
            // Arrange
            var shop = new Shop(new CheckOutWithGoogle());

            // Act
            shop.ChangeCheckOut(new CheckOutWithApple());
            var result = shop.Pay(200.0);

            // Assert
            Assert.Equal("pay with apple ok", result);
        }
    }
}