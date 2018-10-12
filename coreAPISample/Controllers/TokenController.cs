using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using coreAPISample.Models;
using coreAPISample.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace coreAPISample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        IConfiguration _configuration;
        IloggingProvider logger;
        public TokenController( IConfiguration config,IloggingProvider logger)
        {
            this._configuration = config;
            this.logger = logger;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult<JwtSecurityToken> Get([FromBody]TokenRequest request)
        {
            
                // get audience details form database (name and password)
                // better soution is to send username. password and audience to DB then get status

                
                if (request.audience != "test")
                {
                    logger.Info("token request:" + request.ToString() + ":No valid audince found");
                    return BadRequest("No valid audince found");
                }

                //validate username password for audience
                if (request.client_id == "test" && request.client_secret == "test")
                {
                    //fill the claim array, that will avilable for audience
                    var claims = new[] { new Claim(ClaimTypes.Name, request.client_id) };

                    //use audience password (base64 encoded) , store it in DB, together with audience
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));


                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                        issuer: _configuration["issuer"], //toke issuer
                        audience: request.audience, 
                        claims: claims,
                        expires: DateTime.Now.AddMinutes(30), // better put this into audience table
                        signingCredentials: creds);
                    logger.Info("token request:" + request.ToString() + ":token granted");
                return Ok(new TokenResponse()
                {
                    access_token = new JwtSecurityTokenHandler().WriteToken(token),
                    expires_in = (token.ValidTo - token.ValidFrom).TotalSeconds.ToString(),
                    token_type="bearer"


                    });
                }
                logger.Info("token request:" + request.ToString() + ":incorrect username and password");
                return BadRequest("Could not verify username and password");
            
        }
    }
}