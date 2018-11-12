using System;
using System.Reflection;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc;

namespace Tunder.API.Tests.TestHelpers
{
    public static class Extension
    {
        public static void SetUserClaimId(this ControllerBase controller, Guid guid)
        {
            PropertyInfo prop = controller.GetType().GetProperty("User",
                BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);

            Claim[] claims =
            {
                new Claim(ClaimTypes.NameIdentifier, guid.ToString())
            };

            var claimsIdentity = new ClaimsIdentity(claims);

            var principal = new ClaimsPrincipal(claimsIdentity);

            prop.SetValue(principal, "value", null);
        }
    }
}