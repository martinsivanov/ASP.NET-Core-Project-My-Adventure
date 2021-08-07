namespace MyAdventure.Infrastructure
{
    using System.Security.Claims;

    using static MyAdventure.Areas.Admin.AdminConstants;

    public static class ClaimsPrincipalExtentions
    {
        public static string GetId(this ClaimsPrincipal user)
            => user.FindFirst(ClaimTypes.NameIdentifier).Value;

        public static bool IsAdmin(this ClaimsPrincipal user)
            => user.IsInRole(AdministratorRoleName);
    }
}
