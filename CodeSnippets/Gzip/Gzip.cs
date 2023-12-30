using System.IO.Compression;

namespace Gzip
{
    public static class Gzip
    {
        public static byte[] Compress(byte[] data)
        {
            using (MemoryStream memoryStream = new())
            {
                using (GZipStream gzipStream = new(memoryStream, CompressionMode.Compress))
                {
                    gzipStream.Write(data, 0, data.Length);
                }
                return memoryStream.ToArray();
            }
        }

        public static byte[] Decompress(byte[] compressedData)
        {
            using (MemoryStream memoryStream = new(compressedData))
            using (GZipStream gzipStream = new(memoryStream, CompressionMode.Decompress))
            using (MemoryStream decompressedStream = new())
            {
                gzipStream.CopyTo(decompressedStream);
                return decompressedStream.ToArray();
            }
        }
    }
}
