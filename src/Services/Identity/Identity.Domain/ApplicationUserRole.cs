using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain
{
    //Estructura intermediraria entre usuarios y roles.
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public ApplicationRole Role { get; set; }
        public ApplicationUser User { get; set; }
    }
}
