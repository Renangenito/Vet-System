using Microsoft.AspNetCore.Authentication.Cookies;

namespace VetSystem.Extensoes
{
    public static class ServicoExtensoes
    {
        public static void ConfigurarCookiePolicy(this IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
        }
        public static void ConfigurarAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.LoginPath = new PathString("/Login/Index");
                });
        }
    }
}
