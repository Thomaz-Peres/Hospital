using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Doctors.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Doctors.Application.Commands.Login
{
    public class LoginCommand : IRequestHandler<LoginRequest, LoginResponse>
    {
        const string TOKEN_SECRET = "685gfg4fwewkuy4dwhuy684h9f41hj5gfd5h68w71ge0h6d44e6r10dh6hyhjh0dhh0d6w1f8up4d0s664etw887tr34nqcwxm90q9yf2346badmohf4qn99n4n4g6f6";
        private readonly UserManager<User> _userManager;
        private readonly IMediator _mediator;
        private readonly SignInManager<User> _signManager;

        public LoginCommand(IMediator mediator, UserManager<User> userManager, SignInManager<User> signManager)
        {
            _mediator = mediator;
            _userManager = userManager;
            _signManager = signManager;
        }

        public async Task<LoginResponse> Handle(LoginRequest request, CancellationToken cancellationToken)
        {
            var user = await _userManager.FindByNameAsync(request.Username);
            var role = await _userManager.GetRolesAsync(user);

            var result = await _signManager.PasswordSignInAsync(request.Username, request.Password, true, false);
            if (!result.Succeeded)
                return new LoginResponse() { Success = false, Message = "Invalid username or password" };

            if (user != null && user.Active)
            {
                if (await IsValidUserAsync(user, request.Password))
                {
                    var claims = new List<Claim>
                    {
                        new Claim("DoctorIdentifier", user.Id.ToString()),
                        new Claim(ClaimTypes.Role, role.FirstOrDefault()),
                        new Claim("Crm", user.UserName),
                    };

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(claims),
                        Issuer = Environment.GetEnvironmentVariable("Issuer"),
                        IssuedAt = DateTime.UtcNow,
                        Audience = Environment.GetEnvironmentVariable("Audience"),
                        Expires = DateTime.UtcNow.AddHours(200),
                        SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TOKEN_SECRET)), SecurityAlgorithms.HmacSha256Signature)
                    };
                    var tokenJwt = tokenHandler.CreateJwtSecurityToken(tokenDescriptor);
                    var token = tokenHandler.WriteToken(tokenJwt);

                    return new LoginResponse() { Success = true, Token = token, UserIdentifier = user.Id.ToString() };
                }
            }

            return new LoginResponse() { Success = false, Message = "User incorrect or non existent" };
        }

        private async Task<bool> IsValidUserAsync(User user, string password)
        {
            var isValidUser = await _userManager.CheckPasswordAsync(user, password);

            return isValidUser;
        }
    }
}