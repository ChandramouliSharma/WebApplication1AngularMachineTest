using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1AngularMachineTest.Models;
using WebApplication1AngularMachineTest.Repository;

namespace WebApplication1AngularMachineTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        ILoginRepository loginRepository;
        public LoginController(IConfiguration config, ILoginRepository _l)
        {
            _config = config;
            loginRepository = _l;
        }


        #region getUserbyPassword

        [AllowAnonymous]
        [HttpGet("{UserName}/{UserPassword}")]
        //loginmethod--IActionResult
        public IActionResult Login(string UserName, string UserPassword)
        {
            IActionResult response = Unauthorized();

            //Login dbUser;  
            Login dbUser = null;
            //Authenticate the user by passing username and password
            dbUser = AuthenticateUser(UserName, UserPassword);

            if (dbUser != null)
            {
                var tokenString = GenerateJSONWebToken(dbUser);
                response = Ok(new
                {
                    token = tokenString,
                   
                    Name = dbUser.Username,
                    Password = dbUser.Password,
                    Role = dbUser.UserType
                });
            }
            return response;
        }

        //GenerateJsonWebToken()
        private string GenerateJSONWebToken(Login user)
        {
            //security key
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));



            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);



            //generate token
            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
            _config["Jwt:Issuer"], null, expires: DateTime.Now.AddMinutes(20), signingCredentials: credentials);



            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        //AuthenticateUser()
        private Login AuthenticateUser(string Username, string Password)
        {

            //validate the user credentials
            //Retrieve data from the database


            Login dbuser = loginRepository.validateUser(Username, Password);//checking validity of user by username and password

            if (dbuser != null)
            {
                return dbuser;
            }
            return null;
        }

        // get user details with username and password
        #region userdetails details 
        [Authorize(AuthenticationSchemes = "Bearer")]
        [HttpGet]
        [Route("getuser/{UserName}/{UserPassword}")]
        public async Task<IActionResult> getUser(string UserName, string UserPassword)
        {
            try
            {
                var dbuser = loginRepository.validateUser(UserName, UserPassword);
                if (dbuser == null)
                {
                    return NotFound();
                }
                return Ok(dbuser);
            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
        #endregion
    }

    #endregion


}
