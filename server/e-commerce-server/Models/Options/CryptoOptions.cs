using System.Security.Cryptography;

public class CryptoOptions
{
    private int byteCount = 32;
    private int iterationCount = 10000;

    public byte[] GenerateSalt()
    {
        byte[] salt = new byte[byteCount];
        using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(salt);
        }
        return salt;
    }
    public byte[] GenerateHashPassword(string password, byte[] salt)
    {
        using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterationCount, HashAlgorithmName.SHA256))
        {
            return pbkdf2.GetBytes(byteCount);
        }
    }
}