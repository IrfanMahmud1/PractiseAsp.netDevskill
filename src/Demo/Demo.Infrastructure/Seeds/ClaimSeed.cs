using Demo.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Seeds
{
    public static class ClaimSeed
    {
        public static ApplicationUserClaim[] GetClaims()
        {
            return [
                new ApplicationUserClaim
                {
                    Id = -1,
                    UserId = new Guid("70F6FA87-0582-41C4-21D2-08DDB20932B7"),
                    ClaimType = "create_user",
                    ClaimValue = "allowed"
                }
            ];
        }
    }
}
