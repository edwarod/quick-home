namespace QuickHome.Dto
{
    /// <summary>
    /// Provides assembly information for .NET application configuration.
    /// </summary>
    public class ApplicationInfo
    {
        /// <summary>
        /// Gets the application version.
        /// </summary>
        public string ApplicationVersion { get; set; }

        /// <summary>
        /// Gets the application name.
        /// </summary>
        public string ApplicationName { get; set; }

        /// <summary>
        /// Gets the .NET assembly name.
        /// </summary>
        public string AssemblyName { get; set; }
    }
}
