using NUMC.Config.Object;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCommand
{
    public class AppCommandRuntimeDialog : NUMC.Plugin.Runtime.IRuntimeDialog
    {
        public bool ShowDialog(RuntimeScript runtimeScript, KeyObject obj)
        {
            using (var acd = new AppCommandDialog())
                if(acd.ShowDialog() == DialogResult.OK && acd.SelectedCommand != null) {
                    runtimeScript.RuntimeName = AppCommandRuntime.AppCommandRuntimeName;
                    runtimeScript.Data = acd.SelectedCommand.GetData();
                    return true;
                }
            return false;
        }
    }
}
