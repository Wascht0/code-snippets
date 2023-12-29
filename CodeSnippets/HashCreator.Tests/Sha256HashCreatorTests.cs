using System.Security.Cryptography;

namespace HashCreator.Tests
{
    public class Sha256HashCreatorTests
    {
        public class HashCalculatorTests
        {
            [Fact]
            public void CalculateHash_ValidInput_ReturnsExpectedHash()
            {
                // Arrange
                byte[] testData = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
                byte[] expectedHash = CalculateExpectedHash(testData);

                // Act
                byte[] actualHash = Sha256HashCreator.Calculate(testData);

                // Assert
                Assert.Equal(expectedHash, actualHash);
            }

            [Fact]
            public void CalculateHash_EmptyInput_ReturnsEmptyHash()
            {
                // Arrange
                byte[] testData = Array.Empty<byte>();
                byte[] expectedHash = CalculateExpectedHash(testData);

                // Act
                byte[] actualHash = Sha256HashCreator.Calculate(testData);

                // Assert
                Assert.Equal(expectedHash, actualHash);
            }


            private byte[] CalculateExpectedHash(byte[] data)
            {
                using (SHA256 sha256 = SHA256.Create())
                {
                    return sha256.ComputeHash(data);
                }
            }
        }
    }
}