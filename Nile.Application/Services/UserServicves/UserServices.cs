using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Nile.Domain.EntityModel;
using Nile.Infrastructure.Context;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using static Nile.Domain.Enums.Enums;

namespace Nile.Application.UserServicves
{
    public class UserServices : IUserServices
    {
        private readonly IApplicationDbContext _context;
        private readonly IConfiguration _config;

        public UserServices(IApplicationDbContext context,
                            IConfiguration config)
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

        public async Task<object> GenerateToken(string email, string password)
        {
            try
            {
                if (email == null) { return "No User"; }
                User user = GetUserByEmail(email);
                var userRole = _context.UserRoles.Where(a => a.UserId == user.UserId)
                    .Include(b => b.Role).FirstOrDefault();
                string userRoleResult = "Customer";
                if(userRole != null)
                {
                    userRoleResult = userRole.Role.RoleName.ToString();
                }
                DateTime now = DateTime.UtcNow;

                var issuer = _config["Jwt:Issuer"];
                var audience = _config["Jwt:Audience"];
                var key = Encoding.ASCII.GetBytes
                (_config["Jwt:Key"]);
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                                new Claim("Id", Guid.NewGuid().ToString()),
                                new Claim("UserId", user.UserId.ToString()),
                                new Claim(ClaimTypes.NameIdentifier, user.UserName),
                                new Claim(ClaimTypes.Email, email),
                                new Claim(ClaimTypes.Role, userRoleResult)
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
                string stringToken = tokenHandler.WriteToken(token);

                object result = new
                {
                    userDetails = user,
                    token = stringToken,
                    expiration = token.ValidTo
                };
                return result;
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
                User? user = _context.Users.AsNoTracking().Where(x => x.Email == email)
                    .Include(x => x.UserRoles)
                    .Include(x => x.Orders)
                    .Include(x => x.CartOrders)
                    .Include(x => x.Payment)
                    .Include(x => x.PaymentDetails)
                    .Include(x => x.ShippingDetails)
                    .FirstOrDefault();
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
                User user = await _context.Users
                                .Where(u => u.UserId == id)
                                .FirstOrDefaultAsync();
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
                List<User> users = await _context.Users
                                    .Include(x => x.UserRoles)
                                    .Include(x => x.Orders)
                                    .Include(x => x.CartOrders)
                                    .ToListAsync();
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

        public async Task UpdateUser()
        {
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Role> CreateRole(Role role)
        {
            try
            {
                _context.Roles.Add(role);
                _context.SaveChanges();
                return role;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<UserRole> UpdateUser(UserRole newRole)
        {
            try
            {
                _context.UserRoles.Add(newRole);
                await _context.SaveChangesAsync();
                return newRole;
            }
            catch (Exception)
            {

                throw;
            }
        }

        public async Task<Role> GetRoleByRoleName(EnumRoles roleName)
        {
            try
            {
                Role result = _context.Roles.Where(x => x.RoleName == roleName)
                    .FirstOrDefault();
                return result;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
