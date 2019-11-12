using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Data.Models;
using WebAPI.Data.QueryClasses.Interfaces;
using WebAPI.Data.Settings;
using WebAPI.Services.Interfaces;

namespace WebAPI.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;

        private readonly IUserQueries _userQueries;
        public UserService(IOptions<AppSettings> appSettings, IUserQueries userQueries)
        {
            _appSettings = appSettings.Value;
            _userQueries = userQueries;
        }



        public async Task<User> Authenticate(AuthenticateModel model)
        {
            var user = _userQueries.GetUser(model.Username);

            if (user != null && user.Password == model.Password)
            {
                // authentication successful so generate jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_appSettings.Secret);

                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name,user.Username.ToString())
                    }),
                    Expires = DateTime.UtcNow.AddDays(7),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };

                var token = tokenHandler.CreateToken(tokenDescriptor);
                user.Token = tokenHandler.WriteToken(token);
                return user;
            }

            return null;

        }
    }
}
