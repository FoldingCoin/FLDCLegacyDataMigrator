namespace FLDCLegacyDataMigrator.Extensions
{
    using System;
    using System.IO;
    using System.Reflection;

    public static class AssemblyExtensions
    {
        public static string GetCodebaseDirectory(this Assembly assembly)
        {
            string path = GetCodebaseFilename(assembly);
            return Path.GetDirectoryName(path);
        }

        public static string GetCodebaseFilename(this Assembly assembly)
        {
            string codeBase = assembly.CodeBase;
            var uri = new UriBuilder(codeBase);
            return Uri.UnescapeDataString(uri.Path);
        }
    }
}