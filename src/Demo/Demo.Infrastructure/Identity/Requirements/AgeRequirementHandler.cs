using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Infrastructure.Identity.Requirements
{
    public class AgeRequirementHandler : AuthorizationHandler<AgeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, AgeRequirement requirement)
        {
            if (context.User.HasClaim(c => c.Type == "age" &&
                 int.Parse(c.Value) > 20 && int.Parse(c.Value) < 40))
            {
                context.Succeed(requirement);
            }
            return Task.CompletedTask;
        }
    }
}
