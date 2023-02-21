namespace DateApp.Extensions
{
    public static class ClaimPrincipleExtension
    {

        public static string GetUsername(this ClaimsPrincipal user)
        {

            return user.FindFirst(ClaimTypes.Name).Value;
        }

        public static string GetUserId(this ClaimsPrincipal user)
        {
            return user.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}