using System.Security.Cryptography;

namespace HashCreator
{
    public class Sha256HashCreator
    {
        public static byte[] Calculate(byte[] data)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                return sha256.ComputeHash(data);
            }
        }
    }
}
