using System.Security.Cryptography;
using System.Text;

namespace Services.Core;

public class Encryption
{
  private const string CypherKey = "f0a3d91e7b82cde06f65b7e98a2d4c1f";

  public static string Encode(string text, string salt)
  {
    var saltBytes = Encoding.ASCII.GetBytes(salt);
    var textBytes = Encoding.UTF8.GetBytes(text);
    byte[] keyBytes;

    using (var pbkdf2 = new Rfc2898DeriveBytes(CypherKey, saltBytes, 10000))
    {
      keyBytes = pbkdf2.GetBytes(256 / 8);
    }

    using (var aesAlg = Aes.Create())
    {
      aesAlg.Key = keyBytes;
      aesAlg.IV = new byte[aesAlg.BlockSize / 8];

      var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
      byte[] encryptedBytes = null;

      using (var msEncrypt = new MemoryStream())
      {
        using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
          csEncrypt.Write(textBytes, 0, textBytes.Length);
        }

        encryptedBytes = msEncrypt.ToArray();
      }

      return Convert.ToBase64String(encryptedBytes);
    }
  }

  public static string Decode(string text, string salt)
  {
    var saltBytes = Encoding.ASCII.GetBytes(salt);
    var textBytes = Convert.FromBase64String(text);
    byte[] keyBytes;

    using (var pbkdf2 = new Rfc2898DeriveBytes(CypherKey, saltBytes, 10000))
    {
      keyBytes = pbkdf2.GetBytes(256 / 8);
    }

    using (var aesAlg = Aes.Create())
    {
      aesAlg.Key = keyBytes;
      aesAlg.IV = new byte[aesAlg.BlockSize / 8];

      var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
      byte[] decryptedBytes = null;

      using (var msDecrypt = new MemoryStream())
      {
        using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Write))
        {
          csDecrypt.Write(textBytes, 0, textBytes.Length);
        }

        decryptedBytes = msDecrypt.ToArray();
      }

      return Encoding.UTF8.GetString(decryptedBytes);
    }
  }

  public static string GenerateSalt()
  {
    var saltBytes = new byte[16];
    using (var rng = new RNGCryptoServiceProvider())
    {
      rng.GetBytes(saltBytes);
    }

    return Convert.ToBase64String(saltBytes);
  }

  public static string GeneratePassword(int passLength)
  {
    const string allowedChars =
      "abcdefghijkmnopqrstuvwxyzABCDEFGHJKLMNOPQRSTUVWXYZ0123456789!@#$%^&*()_-+={}[];:<>,.?/";

    var randomBytes = new byte[passLength];
    using (var rng = new RNGCryptoServiceProvider())
    {
      rng.GetBytes(randomBytes);
    }

    var result = new StringBuilder(passLength);

    for (var i = 0; i < passLength; i++) result.Append(allowedChars[randomBytes[i] % allowedChars.Length]);

    return result.ToString();
  }
}
