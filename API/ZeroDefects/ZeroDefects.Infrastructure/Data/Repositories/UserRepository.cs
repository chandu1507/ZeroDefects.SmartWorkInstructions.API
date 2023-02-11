using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using ZeroDefects.Domain.Entities;
using ZeroDefects.Domain.Interfaces;

namespace ZeroDefects.Infrastructure.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private const string CollectionName = "Users";
        private readonly IMongoCollection<User> _dbCollection;
        private readonly FilterDefinitionBuilder<User> _filterBuilder = Builders<User>.Filter;
        private readonly string key;
        private readonly IConfiguration Configuration;
        public UserRepository(IMongoDatabase database,IConfiguration configuration)
        {
            _dbCollection = database.GetCollection<User>(CollectionName);
            Configuration = configuration;
            key = Configuration["JwtKey"].ToString();
        }
        public async Task AddUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await _dbCollection.InsertOneAsync(user);
        }

        public async Task<string> Authenticate(string username, string password)
        {

            var user = await _dbCollection.Find(u => u.UserName == username && u.Password == password).FirstOrDefaultAsync();

            if (user==null)
            {
                return null;
            }
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username),
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<string?> DeleteUserAsync(string id)
        {
            var filter = _filterBuilder.Eq(item => item.Id, id);
            var result = await _dbCollection.DeleteOneAsync(filter);

            if (result.DeletedCount != 0)
            {
                return id;
            }

            return null;
        }

        public async Task<IEnumerable<User>> GetAllUsersAsync()
        {
            return await _dbCollection.Find(c => true).ToListAsync();
        }

        public async Task<User> GetUsernAsync(string id)
        {
            var filter = _filterBuilder.Eq(item => item.Id, id);
            return await _dbCollection.Find(filter).FirstOrDefaultAsync();
        }

        public async Task<User?> UpdateUserAsync(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            var filter = _filterBuilder.Eq(item => item.Id, user.Id);
            var result = await _dbCollection.ReplaceOneAsync(filter, user);

            if (result.ModifiedCount != 0)
            {                
                return await _dbCollection.Find(filter).FirstOrDefaultAsync();
            }

            return null;
        }
    }
}
