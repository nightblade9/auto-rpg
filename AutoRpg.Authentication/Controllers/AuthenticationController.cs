using AutoRpg.Cryptographer;
using AutoRpg.DatabaseMediator;
using Microsoft.AspNetCore.Mvc;

namespace AutoRpg.Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IDatabaseMediator databaseMediator;

        public AuthenticationController(IDatabaseMediator databaseMediator)
        {
            this.databaseMediator = databaseMediator;
        }

        // For debugging
        //[HttpGet]
        //public string[] Get()
        //{
        //    var s1 = this.databaseMediator.ExecuteScalar<string>("SELECT 'one'");
        //    var s2 = this.databaseMediator.ExecuteScalar<string>("SELECT 'two'");
        //    return new string[] { s1, s2 };
        //}

        /// <summary>
        /// Authenticates a user, given the username and a plaintext password.
        /// Returns true if the user is authenticated; else, false.
        /// </summary>
        [HttpPost]
        public ActionResult<bool> Post(CredentialsDto credentials)
        {
            var emailAddress = credentials.EmailAddress;
            var plaintextPassword = credentials.PlaintextPassword;

            var userExists = databaseMediator.ExecuteScalar<int>("SELECT COUNT(*) FROM [Users] WHERE EmailAddress = @emailAddress", new { emailAddress = emailAddress }) >= 1;

            if (!userExists)
            {
                return false;
            }

            var expectedPasswordHash = databaseMediator.ExecuteScalar<string>("SELECT HashedPassword FROM [Users] WHERE EmailAddress = @emailAddress", new { emailAddress = emailAddress });
            var passwordsMatch = PasswordHasher.ValidatePassword(plaintextPassword, expectedPasswordHash);

            return passwordsMatch;
        }

        //// POST api/values
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        //// PUT api/values/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/values/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}

        public class CredentialsDto
        {
            public string EmailAddress { get; set; }
            public string PlaintextPassword { get; set;  }

            public CredentialsDto(string email, string password)
            {
                this.EmailAddress = email;
                this.PlaintextPassword = password;
            }
        }
    }
}
