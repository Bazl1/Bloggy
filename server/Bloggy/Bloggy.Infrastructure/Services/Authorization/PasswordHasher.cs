using System.Security.Cryptography;
using System.Text;
using Bloggy.Application.Services.Authorization;

namespace Bloggy.Infrastructure.Services.Authorization;

public class PasswordHasher : IPasswordHasher
{
    private const int SaltSize = 128 / 8;
    private const int KeySize = 256 / 8;
    private const int IterationCount = 100000;
    private const char Delimiter = '.';
    private HashAlgorithmName _hashAlgorithm = HashAlgorithmName.SHA512;

    public string Hash(string password)
    {
        byte[] salt = RandomNumberGenerator.GetBytes(SaltSize);
        
        byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
            password: Encoding.UTF8.GetBytes(password),
            salt: salt,
            iterations: IterationCount,
            hashAlgorithm: _hashAlgorithm,
            outputLength: KeySize
        );

        return string.Join(
            Delimiter,
            Convert.ToBase64String(salt),
            Convert.ToBase64String(hash)
        );
    }

    public bool Verify(string password, string paswordHash)
    {
        var elements = paswordHash.Split(Delimiter);
        byte[] salt = Convert.FromBase64String(elements[0]);
        byte[] hash = Convert.FromBase64String(elements[1]);
        
        byte[] inputPasswordHash = Rfc2898DeriveBytes.Pbkdf2(
            password: Encoding.UTF8.GetBytes(password),
            salt: salt,
            iterations: IterationCount,
            hashAlgorithm: _hashAlgorithm,
            outputLength: KeySize
        );

        return CryptographicOperations.FixedTimeEquals(
            hash,
            inputPasswordHash
        );
    }
}
