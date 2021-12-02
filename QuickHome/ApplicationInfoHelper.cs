using QuickHome.Dto;
using System.Reflection;

namespace QuickHome
{
    /// <summary>
    /// Application and assembly information helper for ASP .NET Core application configuration.
    /// </summary>
    public static class ApplicationInfoHelper
    {
        /// <summary>
        /// Gets the application and assembly information.
        /// </summary>
        /// <typeparam name="T">The type (typically the Startup class) to get the information from.</typeparam>
        /// <returns>The application and assembly information.</returns>
        public static ApplicationInfo GetInfo<T>()
        {
            var applicationAssembly = typeof(T).Assembly;
            var assemblyName = applicationAssembly.GetName();

            return new ApplicationInfo
            {
                AssemblyName = assemblyName.Name,
                ApplicationVersion = assemblyName.Version?.ToString(),
                ApplicationName = applicationAssembly.GetCustomAttribute<AssemblyProductAttribute>()?.Product ?? assemblyName.Name
            };
        }
    }
}
