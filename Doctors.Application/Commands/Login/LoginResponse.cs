namespace Doctors.Application.Commands.Login
{
    public class LoginResponse : CommandResponse
    {
        public string Token { get; set; }
        public string UserIdentifier { get; set; }
    }
}