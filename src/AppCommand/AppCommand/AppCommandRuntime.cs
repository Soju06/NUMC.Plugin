using NUMC;
using NUMC.Plugin.Runtime;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCommand
{
    public class AppCommandRuntime : IRuntime
    {
        public string[] RuntimeNames { get; } = new string[] { AppCommandRuntimeName };
        public static string AppCommandRuntimeName { get => "Plugin.AppCommand"; }

        public IRuntimeDialog Dialog => new AppCommandRuntimeDialog();

        public IRuntimeMenu Menu => new AppCommandRuntimeMenu();

        public int Index => 10;

        public void Dispose() { }

        public void Initialize(Script script) { }

        public void Run(ScriptInfo scriptInfo, RuntimeScript script, bool isDown)
        {
            if (isDown) {
                switch (script.RuntimeName) {
                    case "Plugin.AppCommand":
                        var command = AppCommands.ToAppCommnad(script.Data);
                        if (command.HasValue)
                            AppCommandAPI.Send(command.Value);
                        break;
                    default: return;
                }
            }
        }

        public string ScriptContent(RuntimeScript script, KeyObject obj)
        {
            var ac = AppCommands.ToAppCommnad(script?.Data);
            var r = AppCommands.GetResource();
            return string.Format(AppCommands.AppCommandContextLocalizing(r), ac.HasValue ?
                AppCommands.APPCOMMANDToString(ac.Value, r) : "unknown");
        }
    }
}
