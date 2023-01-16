using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nile.Domain.EntityModel;
using Nile.Infrastructure.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Runtime.CompilerServices;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace Nile.Application.UserServicves
{
    public class UserServices : IUserServices
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _config;

        public UserServices(ApplicationDbContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        public bool Authenticate(User user)
        {
            try
            {
                User? result = _context.Users.Where(u => u.Email == user.Email).FirstOrDefault();
                if (result != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool CheckPasswordMatch(string password, string confirmPassword)
        {
            try
            {
                if(password == confirmPassword)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public async Task<int> DeleteUser(User user)
        {
            try
            {
                _context.Users.Remove(user);
                int result = await _context.SaveChangesAsync();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<string> GenerateToken(string email, string password)
        {
            try
            {
                /*User myUser = await _context.Users.Where(u => u.Email == email).FirstOrDefaultAsync();*/
                if (email == null) { return "No User"; }
                /*if (email == myUser.Email && password == myUser.PasswordHash)
                {
                    
                }
                else
                {
                    return "";
                }*/
                var issuer = _config["Jwt:Issuer"];
                    var audience = _config["Jwt:Audience"];
                    var key = Encoding.ASCII.GetBytes
                    (_config["Jwt:Key"]);
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new[]
                        {
                                new Claim("Id", Guid.NewGuid().ToString()),
                                new Claim(JwtRegisteredClaimNames.Sub, email),
                                new Claim(JwtRegisteredClaimNames.Email, email),
                                new Claim(JwtRegisteredClaimNames.Jti,
                                Guid.NewGuid().ToString())
                            }),
                        Expires = DateTime.UtcNow.AddMinutes(5),
                        Issuer = issuer,
                        Audience = audience,
                        SigningCredentials = new SigningCredentials
                        (new SymmetricSecurityKey(key),
                        SecurityAlgorithms.HmacSha512Signature)
                    };
                    JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                    SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                    string jwtToken = tokenHandler.WriteToken(token);
                    string stringToken = tokenHandler.WriteToken(token);

                    return stringToken;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public User GetUserByEmail(string email)
        {
            try
            {
                User? user = _context.Users.AsNoTracking().Where(x => x.Email == email).FirstOrDefault();
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> GetUserById(int id)
        {
            try
            {
                User user = await _context.Users.Where(u => u.UserId == id).FirstOrDefaultAsync();
                if(user == null)
                {
                    return null;
                }
                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<List<User>> GetUsers()
        {
            try
            {
                List<User> users = await _context.Users.ToListAsync();
                return users;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public string Base64Encode(string plainText)
        {
            try
            {
                var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
                return System.Convert.ToBase64String(plainTextBytes);
            }
            catch (Exception)
            {

                throw;
            } 
        }

        public byte[] ConvertPasswordToBytes(string password, int len)
        {
            try
            {
                byte[] fileBytes = new byte[len];
                string CleanImage = Base64Encode(password);
                fileBytes = Convert.FromBase64String(CleanImage);

                return fileBytes;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string PassowrdHash(string password)
        {
            try
            {
                // Generate a 128 - bit salt using a sequence of
                // cryptographically strong random bytes.
                // divide by 8 to convert bits to bytes  
                /*byte[] salt = RandomNumberGenerator.GetBytes(128 / 8);
                KeyDerivation.Pbkdf2(
                    password: password!,
                    salt: salt,
                    prf: KeyDerivationPrf.HMACSHA256,
                    iterationCount: 100000,
                    numBytesRequested: 256 / 8)*/
                // derive a 256-bit subkey (use HMACSHA256 with 100,000 iterations)
                string hashed = Convert.ToBase64String(ConvertPasswordToBytes(password, password.Length));

                return hashed;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<User> RegisterUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();

                return user;
            }
            catch (Exception)
            {

                throw;
            }
        }

    }
}
