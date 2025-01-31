using GameStore.BL;
namespace GameStore
{
    public static class DependencyInjection
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.RegisterDataLayer();
            services.RegisterBusinessLayer();
        }
    }
}
