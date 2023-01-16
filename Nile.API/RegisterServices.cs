/*using System.Reflection;

namespace Nile.API
{
    public static class RegisterServices
    {
        public static void AddStandAloneServices(this IServiceCollection @this)
        {
            Type iAttributetype = typeof(IServiceProvider);
            Assembly iAssembly = iAttributetype.Assembly;
            Type[] iDefinedTypes = iAssembly.GetExportedTypes();
            var iServices = iDefinedTypes
                .Where(type => type.GetTypeInfo()
                .GetCustomAttribute<IService>() != null);

            foreach (Type iService in iServices)
            {
                var service = AppDomain.CurrentDomain.GetAssemblies()
                    .SelectMany(type => type.GetTypes())
                    .Where(s => iService.IsAssignableFrom(s) && s.IsClass).FirstOrDefault();
                if (service != null)
                {
                    @this.AddScoped(iService, service);
                }
            }
        }
    }
}*/