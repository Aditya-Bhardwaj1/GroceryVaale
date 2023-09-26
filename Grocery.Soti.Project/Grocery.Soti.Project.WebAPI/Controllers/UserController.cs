using Grocery.Soti.Project.DAL.Interfaces;
using Grocery.Soti.Project.DAL.Models;
using System.Net;
using System.Threading.Tasks;
using System.Web.Helpers;
using System.Web.Http;

namespace Grocery.Soti.Project.WebAPI.Controllers
{
    [RoutePrefix("api/soti/user")]
    public class UserController : ApiController
    {
        private readonly IUser _user = null;
        public UserController(IUser user)
        {
            _user = user;
        }

        //[HttpPost]
        //[Route("Register")]
        //public IHttpActionResult RegisterUser([FromBody] User user)
        //{
        //    var dt = _user.RegisterUser(user.FirstName, user.LastName,user.Gender,user.DateOfBirth,user.MobileNumber,user.EmailId);
        //    if (dt == false)
        //    {
        //        return BadRequest();
        //    }
        //    //return Ok(dt);
        //    return StatusCode(HttpStatusCode.Created);
        //}

        [HttpPost]
        [Route("Register")]
        [AllowAnonymous]
        public async Task<IHttpActionResult> RegisterUser([FromBody] User user)
        {
            string password = user.Password + "2CxVKFLCejA3B4LJu7ocpg==";
            string hashedPassword = Crypto.HashPassword(password);
            user.Password = hashedPassword;
            var registerResponse = await _user.RegisterUser(user);
            if (registerResponse == false)
            {
                return BadRequest();
            }
            //return Ok(dt);
            return StatusCode(HttpStatusCode.Created);
        }

        //[HttpPost]
        //[Route("Login")]

        //public async Task<IHttpActionResult> LoginUser([FromBody] User user)
        //{
        //    var hashedPassword = await _user.LoginUser(user);
        //    var passwordToCheck = user.Password + "2CxVKFLCejA3B4LJu7ocpg==";
        //    var isVerified = Crypto.VerifyHashedPassword(hashedPassword, passwordToCheck);
        //    if (isVerified)
        //    {
        //        var data = new { message = "Login Successful" };
        //        return Ok(data); // Send a 200 OK response with data

        //    }
        //    return Unauthorized();
        //}


    }
}