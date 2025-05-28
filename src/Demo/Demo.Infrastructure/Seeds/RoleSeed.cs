using Demo.Infrastructure.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Seeds
{
    public static class RoleSeed
    {
        public static ApplicationRole[] GetRoles()
        {
            return [
                new ApplicationRole
                {
                    Id = new Guid("9019BA25-B384-49B4-B855-B88483B53A53"),
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = new DateTime(2025,5,26,1,2,3).ToString(),
                },
                 new ApplicationRole
                {
                    Id = new Guid("496D4FEF-42D6-48CA-B88C-922C34D653C5"),
                    Name = "HR",
                    NormalizedName = "HR",
                    ConcurrencyStamp = new DateTime(2025,5,26,1,2,4).ToString(),
                },
                  new ApplicationRole
                {
                    Id = new Guid("933C72C6-10E8-4D68-9E3C-7063BAC3B58C"),
                    Name = "Author",
                    NormalizedName = "AUTHOR",
                    ConcurrencyStamp = new DateTime(2025,5,26,1,2,5).ToString(),
                }
            ];
        }
    }
}
