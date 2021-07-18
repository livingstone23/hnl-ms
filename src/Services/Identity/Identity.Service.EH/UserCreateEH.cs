using Identity.Domain;
using Identity.Service.EH.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Threading;
using System.Threading.Tasks;

namespace Identity.Service.EH
{
    public class UserCreateEH : IRequestHandler<UserCreateCommand, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserCreateEH(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        /// <summary>
        /// Metodo que desencadena el registro de usuarios.
        /// </summary>
        /// <param name="notification"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public async Task<IdentityResult> Handle(UserCreateCommand notification, CancellationToken cancellationToken)
        {
            var entry = new ApplicationUser
            {
                FirstName = notification.FirstName,
                LastName = notification.LastName,
                Email = notification.Email,
                UserName = notification.Email
            };

            return await _userManager.CreateAsync(entry, notification.Password);
        }
    }
}
