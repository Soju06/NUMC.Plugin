using NUMC;
using NUMC.Plugin;
using NUMC.Plugin.Menu;
using NUMC.Plugin.Runtime;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Windows.Forms;

namespace RuntimeCsharp
{
    public class RuntimeCsharpInjector
    {
        public static Assembly Assembly;

        public static InjectedPluginInfo InjectAssembly(Assembly assembly, Service service = null)
        {
            Assembly = assembly;
            if (assembly is null) throw new ArgumentNullException("assembly");
            if (service is null) service = Service.GetService();
            if (service is null) throw new ArgumentNullException("service has not started");
            var script = service.GetScript();
            var ipi = new InjectedPluginInfo();
            foreach (var c in Extract.GetPluginContainers(new[] { assembly })) {
                try {
                    var Container = NUMC.Plugin.Container.CreateContainer(c);
                    ipi.Containers.Add(Container);
                    var bt = Container.BaseType;
                    if(bt == typeof(IRuntime)) {
                        var scriptRuntimes = script?.GetRuntimes();
                        if (scriptRuntimes is object)
                            foreach (IRuntime item in Container.Plugins)
                                scriptRuntimes.Add(item);
                        else ipi.Exceptions.Add(new ArgumentNullException(
                            "runtime of the script is incorrect"));
                    } else if(bt == typeof(IApplicationMenu)) {
                        var appMenus = service.GetApplicationMenus();
                        foreach (IApplicationMenu item in Container.Plugins)
                            appMenus.Add(item);
                    } else if(bt == typeof(INotifyMenu)) {
                        var notifyMenus = service.GetNotifyMenus();
                        foreach (INotifyMenu item in Container.Plugins)
                            notifyMenus.Add(item);
                    } else if(bt == typeof(IKeyMenu)) {
                        var keyMenus = service.GetKeyMenus();
                        foreach (IKeyMenu item in Container.Plugins)
                            keyMenus.Add(item);
                    } else ipi.Exceptions.Add(new NotSupportedException("this plugin is not supported"));

                    if (Container.BaseType.GetInterface(typeof(IPluginExp).Name) == typeof(IPluginExp))
                        foreach (IPluginExp item in Container.Plugins)
                            item.Initialize(script);

                    service.GetMain().ReloadLanguage();
                } catch (Exception ex) {
                    ipi.Exceptions.Add(ex);
                }
            } return ipi;
        }
    }

    public class InjectedPluginInfo
    {
        public List<Exception> Exceptions { get; set; } = new List<Exception>();
        public List<Container> Containers { get; set; } = new List<Container>();
    }
}
