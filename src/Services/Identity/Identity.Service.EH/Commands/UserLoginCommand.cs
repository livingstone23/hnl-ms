using MediatR;
using System.ComponentModel.DataAnnotations;
using Identity.Service.EH.Responses;

namespace Identity.Service.EH.Commands
{
    public class UserLoginCommand : IRequest<IdentityAccess>
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
