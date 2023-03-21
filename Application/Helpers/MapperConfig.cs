using System.Reflection;

namespace Application.Helpers
{
    public static class MapperConfig
    {
        public static void AddMapperConfig(this IServiceCollection services, Assembly assemblyName)
        {

            var types = assemblyName.GetTypes();

            var derivedTypes = types.Where(t => t.IsSubclassOf(typeof(Profile)));

            foreach (var type in derivedTypes)
            {
                services.AddAutoMapper(type);
            }

        }
    }
}