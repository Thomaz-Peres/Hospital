
namespace Doctors.Application
{
    public abstract class CommandResponse
    {
        public string? Message { get; set; }
        public required bool Success { get; set; }
    }
}
