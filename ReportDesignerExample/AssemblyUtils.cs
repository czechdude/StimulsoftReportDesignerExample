using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace ReportDesignerExample
{
    public class AssemblyUtils
    {

        public static string GetAssemblyDirectory()
        {
            return GetAssemblyDirectory(Assembly.GetExecutingAssembly());
        }

        /// <summary>
        /// Gets the directory where given assembly is really located. 
        /// assembly.Location returns just the virtual value in case of unit tests and web services.
        /// </summary>
        /// <returns>directory of the given assembly</returns>
        public static string GetAssemblyDirectory(Assembly executingAssembly)
        {

            //// In normal case, exe, use CodeBase and assembly location point to the same folder.
            //// There are a few exceptions, iis and arcgis server, they run assemblies in temporary directories. 
            //// - IIS cannot use temporary directories, as each dll is in its own folder. There we use codebase to find DLL directory.
            //// - need to determine if we run under arcgis server, so that we load the assemblies from
            //// the correct assembly path. Note: under ArcGIS Server the assemblies of the SOE are 
            //// run from a temporary directory
            string pathAssembly;
            bool isAgs = string.Compare(Process.GetCurrentProcess().ProcessName, "ArcSOC", StringComparison.InvariantCulture) == 0;
            if (isAgs)
            {
                pathAssembly = executingAssembly.Location;
                pathAssembly = pathAssembly.Replace("file:\\", string.Empty);
            }
            else
            {
                pathAssembly = new Uri(executingAssembly.EscapedCodeBase).LocalPath;
            }

            var assemblyLocation = pathAssembly;
            string directory = Path.GetDirectoryName(assemblyLocation);
            return directory;
        }
    }
}