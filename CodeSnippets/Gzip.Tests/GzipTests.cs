namespace Gzip.Tests
{
    public class GzipTests
    {
        [Fact]
        public void Compress_ValidData_ReturnsCompressedData()
        {
            // Arrange
            byte[] originalData = "ABCDEF"u8.ToArray();

            // Act
            byte[] compressedData = Gzip.Compress(originalData);

            // Assert
            Assert.NotNull(compressedData);
            Assert.NotEmpty(compressedData);
            Assert.NotEqual(originalData, compressedData);
        }

        [Fact]
        public void Decompress_ValidCompressedData_ReturnsOriginalData()
        {
            // Arrange
            byte[] originalData = "ABCDEF"u8.ToArray();
            byte[] compressedData = Gzip.Compress(originalData);

            // Act
            byte[] decompressedData = Gzip.Decompress(compressedData);

            // Assert
            Assert.Equal(originalData, decompressedData);
        }
    }
}