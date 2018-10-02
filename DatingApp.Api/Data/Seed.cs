using System.Collections.Generic;
using System.Threading.Tasks;
using DatingApp.Api.Models;
using Newtonsoft.Json;

namespace DatingApp.Api.Data
{
    public class Seed
    {
        private readonly DataContext _dbContext;

        public Seed(DataContext dbContext)
        {
           
            this._dbContext = dbContext;
        }

        public void SeedUsers()
        {
            var userData = System.IO.File.ReadAllText("Data/userSeedData.json");

            var users = JsonConvert.DeserializeObject<List<User>>(userData);
            
            IAuthRepository repo = new AuthRepository(_dbContext);

            foreach (var user in users)
            {
                var createdUser = repo.RegisterSync(user, "password");
            }
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes("password"));
            }

        }
    }
}