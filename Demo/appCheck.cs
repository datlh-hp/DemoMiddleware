using Microsoft.AspNetCore.Builder;

namespace MIS
{
    public static class appCheck
    {
        public static IApplicationBuilder Check(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<checkurl>();
        }
    }
}
