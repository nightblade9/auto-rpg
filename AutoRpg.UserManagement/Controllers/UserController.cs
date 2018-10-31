using AutoRpg.DatabaseMediator;
using AutoRpg.Cryptographer;
using Microsoft.AspNetCore.Mvc;

namespace AutoRpg.UserManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IDatabaseMediator databaseMediator;

        public UserController(IDatabaseMediator databaseMediator)
        {
            this.databaseMediator = databaseMediator;
        }

        /// <summary>
        /// Create a new user. Returns true if we created a new user.
        /// </summary>
        [HttpPost]
        public bool Post([FromBody]UserRegistrationDto request)
        {
            // TODO: validation. Email address has @ and ., password is 12+ characters, etc.
            var userName = request.EmailAddress.Substring(0, request.EmailAddress.IndexOf('@'));

            var userExists = databaseMediator.ExecuteScalar<int>("SELECT COUNT(*) FROM [Users] WHERE EmailAddress = @emailAddress", new { emailAddress = request.EmailAddress}) >= 1;

            if (userExists)
            {
                return false;
            }

            var hashedPassword = PasswordHasher.HashPassword(request.PlaintextPassword);

            databaseMediator.Execute("INSERT INTO [Users] (UserName, EmailAddress, HashedPassword) VALUES (@userName, @email, @password)", new { userName = userName, email = request.EmailAddress, password = hashedPassword });

            return true;
        }

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
            // TODO: update user name, password, etc.
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        public class UserRegistrationDto
        {
            public string EmailAddress{ get; set; }
            public string PlaintextPassword { get; set; }
        }
    }
}
