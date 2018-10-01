using System.Collections.Generic;
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

             foreach (var user in users)
             {
                 byte[] paswordHash, passwordSalt;
                 
                 CreatePasswordHash("password", out passwordSalt, out paswordHash);

                 user.PasswordHash = paswordHash;
                 user.PasswordSalt = passwordSalt;
                 user.Username = user.Username.ToLower();
                 
                 _dbContext.Users.Add(user);
             }

             _dbContext.SaveChanges();
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {

            using (var hmac = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
            }

        }
    }
}