using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using api.Models;

namespace api.Services
{
    public class UserService
    {
        private readonly AppDbContext _context;
        public UserService(AppDbContext context)
        {
            _context = context;
        }

        public void Register(string username, string password)
        {
            if (_context.Users.Any(u => u.Username == username))
            {
                throw new Exception("Username already exists.");
            }

            byte[] salt = GenerateSalt();
            byte[] passwordHash = HashPassword(password, salt);

            var newUser = new User
            {
                Username = username,
                Salt = salt,
                PasswordHash = passwordHash
            };

            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public bool Login(string username, string password)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == username);
            if (user == null)
            {
                return false;
            }
            // Calcula o hash da senha dada pelo usuário usando o mesmo salt
            byte[] passwordHash = HashPassword(password, user.Salt);
            // Comparar os hashes para verificar se a senha é a mesma.
            return passwordHash.SequenceEqual(user.PasswordHash);
        }

        private byte[] GenerateSalt()
        {
            using (var rng = new RNGCryptoServiceProvider())
            {
                var salt = new byte[16];
                rng.GetBytes(salt);
                return salt;
            }
        }

        private byte[] HashPassword(string password, byte[] salt)
        {
            using (var hmac = new HMACSHA256(salt))
            {
                return hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }
        }
    }
}