using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;

namespace EffectLibrary
{
    /// <summary>
    /// A helper class for creating "pack://" URIs without hardwiring in a module name.
    /// </summary>
    internal static class Global
    {
        /// <summary>
        /// Cached short name of the current assembly.
        /// </summary>
        private static string assemblyShortName;

        /// <summary>
        /// Gets the AssemblyShortName field.
        /// </summary>
        private static string AssemblyShortName
        {
            get
            {
                if (assemblyShortName == null)
                {
                    Assembly a = typeof(Global).Assembly;

                    // Pull out the short name.
                    assemblyShortName = a.ToString().Split(',')[0];
                }

                return assemblyShortName;
            }
        }

        /// <summary>
        /// Helper method for generating a "pack://" URI for a given relative file based on the
        /// assembly that this class is in.
        /// </summary>
        /// <param name="relativeFile">The relative path to the component.</param>
        /// <returns>A URI to the specified component.</returns>
        public static Uri MakePackUri(string relativeFile)
        {
            string uriString = "pack://application:,,,/" + AssemblyShortName + ";component/" + relativeFile;
            return new Uri(uriString);
        }
    }
}
