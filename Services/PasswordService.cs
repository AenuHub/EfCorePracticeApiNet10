using Microsoft.AspNetCore.Identity;

namespace EfCorePracticeApiNet10.Services
{
    public class PasswordService
    {
        private readonly PasswordHasher<string> _hasher = new PasswordHasher<string>();

        public string HashPassword(string password)
        {
            return _hasher.HashPassword("", password);
        }

        public bool Verify(string hashedPassword, string password)
        {
            var result = _hasher.VerifyHashedPassword("", hashedPassword, password);
            return result == PasswordVerificationResult.Success;
        }
    }
}
