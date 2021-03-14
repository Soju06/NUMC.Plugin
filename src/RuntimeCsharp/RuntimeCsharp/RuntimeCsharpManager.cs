using NUMC.Design.Controls;
using NUMC.Plugin.Runtime;
using NUMC.Plugins.ScriptEditor;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuntimeCsharp
{
    public partial class RuntimeCsharpManager : NUMC.Design.Form
    {
        private RuntimeCsharpCompiler.CsharpCompilerParameters Parameters;

        public RuntimeCsharpManager()
        {
            InitializeComponent();
            Fasdfsa();
        }

        private void Fasdfsa()
        {
            Parameters = RuntimeCsharpCore.GetScripts();
            //textBox1.Text = string.Join(Environment.NewLine, Parameters.ReferencedAssemblies.Cast<string>().ToArray());
            //textBox1.Text += "\r\n\r\n\r\n" + string.Join(Environment.NewLine, Parameters.Codes.Cast<string>().ToArray());
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            var rcc = RuntimeCsharpCompiler.Compiler(Parameters);
            for (int i = 0; i < rcc.Errors.Length; i++) {
                    MessageBox.Show(rcc.Errors[i].ToString());
                return;
            }
            MessageBox.Show(string.Join(Environment.NewLine, rcc.Outputs.Cast<string>().ToArray()));
            RuntimeCsharpInjector.InjectAssembly(rcc.CompiledAssembly);
        }
    }

    //public class IF : IRuntime
    //{
    //    private Script Script;

    //    public IF()
    //    {
    //        Dialog = new IFDialog();
    //        Menu = new IFMenu(Dialog as IFDialog);
    //    }

    //    public string[] RuntimeNames => new[] { "IF.KeyDown" };

    //    public IRuntimeDialog Dialog { get; private set; }

    //    public IRuntimeMenu Menu { get; private set; }

    //    public int Index => -200;

    //    public void Dispose()
    //    {

    //    }

    //    public void Initialize(Script script)
    //    {
    //        Script = script;
    //    }

    //    public void Run(ScriptInfo scriptInfo, RuntimeScript script, bool isDown)
    //    {
    //        if(isDown) {
    //            switch (script?.RuntimeName) {
    //                case "IF.KeyDown":
    //                    if (!int.TryParse(script.Data, out var v)) break;
    //                    if (!Script.GetSimulator().InputDeviceState.IsHardwareKeyDown((Keys)v))
    //                        scriptInfo.Index = int.MaxValue;
    //                    break;
    //            }
    //        }
    //    }

    //    public string ScriptContent(RuntimeScript script, KeyObject obj)
    //    {
    //        if (script == null) return null;
    //        switch (script.RuntimeName) {
    //            case "IF.KeyDown":
    //                return $"만약 {(int.TryParse(script.Data, out var v) ? ((Keys)v).ToString() : "{알수없음}")}키를 눌려있다면...";
    //        }
    //        return null;
    //    }

    //    public class IFMenu : IRuntimeMenu
    //    {
    //        private readonly IFDialog dialog;
    //        private KeyObject Object;

    //        public IFMenu(IFDialog dialog)
    //        {
    //            this.dialog = dialog;
    //            Menus = new[] { NUMC.Menu.MenuStripSupport.AddMenuItem(null, "만약 키가 눌려있다면..", null) };
    //            Menus[0].Click += IFMenu_Click;
    //        }

    //        private void IFMenu_Click(object sender, EventArgs e)
    //        {
    //            if (Object != null) dialog.ShowDialog(null, Object);
    //        }

    //        public ToolStripItem[] Menus { get; private set; }

    //        public void Dispose()
    //        {
    //            NUMC.Menu.MenuStripSupport.DisposeItems(Menus);
    //        }

    //        public void MenuClicking(IScriptEditor scriptEditor, IListViewItem listViewItem, RuntimeScript runtimeScript, KeyObject obj)
    //        {
    //            Object = obj;
    //        }
    //    }

    //    public class IFDialog : IRuntimeDialog
    //    {
    //        public bool ShowDialog(RuntimeScript runtimeScript, KeyObject obj)
    //        {
    //            using (NUMC.Forms.Dialogs.KeysDialog kd = new NUMC.Forms.Dialogs.KeysDialog())
    //                if(kd.ShowDialog() == DialogResult.OK && kd.SelectItem != Keys.None) {
    //                    obj.Script.CreateAddRuntimeScript("IF.KeyDown", ((int)kd.SelectItem).ToString());
    //                    return true;
    //                }
    //            return false;
    //        }
    //    }
    //}
}
