using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using Inspire.Interfaces;

namespace Inspire
{
    public class InspireModules
    {
        static InspireModules()
        {
            List<string> assemblyList = FindAllModules();  //Assemblies;

            foreach (var asmbly in assemblyList)
            {

                try
                {
                    Assembly assembly =
                    Assembly.Load(AssemblyName.GetAssemblyName(Paths.ClientModulesDirectory + asmbly));

                    foreach (Type type in assembly.GetTypes())
                    {
                        // Pick up a class in the assembly
                        if (type.IsClass)
                        {
                            // If it does not implement the IMediaModule Interface, skip it
                            if (type.GetInterface("IMediaModule") == null)
                            {
                                continue;
                            }

                            IMediaModule imediaModule = (IMediaModule)Activator.CreateInstance(type);

                            InspireModule inspireModule = new InspireModule();

                            if (imediaModule.GetIsPanelModule())
                                try
                                {
                                    inspireModule.ModuleDLL = assembly.ManifestModule.ToString();

                                    inspireModule.SupportedExtentions = imediaModule.GetSupportedFileTypes();

                                    inspireModules.Add(inspireModule);
                                }
                                catch
                                {
                                    // Log that a module failed to load and continue to load the rest.
                                    continue;
                                }
                        }
                    }
                }
                catch (Exception)
                {
                   // asmbly + "failed to load.";// TODO: Log this
                }
                
            }
            Assemblies = assemblyList;
        }

        public static readonly List<string> Assemblies;

        public bool ModulesLoaded { get; set; }

        public static List<InspireModule> IModules { get { return inspireModules; } }

        private static readonly List<InspireModule> inspireModules = new List<InspireModule>();


        private static List<string> FindAllModules()
        {
            List<string> modules = new List<string>();
            if (Directory.Exists(Paths.ClientModulesDirectory))
            {
                string[] dllFiles = Directory.GetFiles(Paths.ClientModulesDirectory);
                foreach (var module in dllFiles)
                {
                    if (Path.GetExtension(module) == ".dll")
                        modules.Add(Path.GetFileName(module));
                }
            }
            return modules;
        }
    }

    public class InspireModule
    {
        public string ModuleDLL { get; set; }
        public List<string> SupportedExtentions { get; set; }
    }
}
