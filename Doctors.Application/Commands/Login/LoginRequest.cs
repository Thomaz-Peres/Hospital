using MediatR;

namespace Doctors.Application.Commands.Login
{
    public class LoginRequest : IRequest<LoginResponse>
    {
        public required string Username { get; set; }
        public required string Password { get; set; }
    }
}