using NUMC.Config.Object;
using NUMC.Design.Controls;
using NUMC.Plugins.ScriptEditor;
using NUMC.Script;
using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace AppCommand
{
    public class AppCommandRuntimeMenu : NUMC.Plugin.Runtime.IRuntimeMenu
    {
        private readonly ToolStripMenuItem _addMenu;
        private readonly ToolStripMenuItem _editMenu;
        private readonly ToolStripItem[] _menus;
        private IScriptEditor _scriptEditor;
        private RuntimeScript _runtimeScript;
        private KeyObject _keyObject;

        public AppCommandRuntimeMenu() {
            _menus = new [] { _addMenu = NUMC.Menu.MenuStripSupport.AddMenuItem(null, "ac add", "add"),
                _editMenu = NUMC.Menu.MenuStripSupport.AddMenuItem(null, "ac edit", "edit")};
            _addMenu.Click += Menu_Click;
            _editMenu.Click += Menu_Click;
        }

        private void Menu_Click(object sender, EventArgs e)
        {
            if (_scriptEditor == null ||
                !((sender as ToolStripMenuItem).Tag is string t)) return;
            switch (t)
            {
                case "edit":
                    if (_runtimeScript == null) break;
                    var rcs = AppCommands.ToAppCommnad(_runtimeScript?.Data);
                    using (var acr = new AppCommandDialog(rcs ?? APPCOMMAND.APPCOMMAND_SAVE))
                        if(acr.ShowDialog() == DialogResult.OK && acr.SelectedCommand != null)
                            _runtimeScript.Data = acr.SelectedCommand.GetData();
                    _scriptEditor.RefreshView();
                    break;
                case "add":
                    if (_keyObject == null) break;
                    using (var acr = new AppCommandDialog())
                        if(acr.ShowDialog() == DialogResult.OK && acr.SelectedCommand != null) {
                            _keyObject.Scripts.AddRuntimeScript(new RuntimeScript {
                                RuntimeName = AppCommandRuntime.AppCommandRuntimeName,
                                Data = acr.SelectedCommand.GetData()
                            });
                            _scriptEditor.RefreshView();
                        }
                    break;
            }
        }



        public ToolStripItem[] Menus {
            get {
                var r = AppCommands.GetResource();
                _addMenu.Text = AppCommands.AppCommandAddMenuTextLocalizing(r);
                _editMenu.Text = AppCommands.AppCommandEditMenuTextLocalizing(r);
                return _menus;
            }
        }

        public void Dispose() { NUMC.Menu.MenuStripSupport.DisposeItems(_menus); }

        public void Initialize(IScriptEditor scriptEditor) {

        }

        public void MenuClicking(IScriptEditor scriptEditor, 
            NUMC.Design.Controls.TreeNode node, RuntimeScript runtimeScript, KeyObject obj) {
            _scriptEditor = scriptEditor;
            _runtimeScript = runtimeScript;
            _keyObject = obj;
            if (_editMenu != null)
                _editMenu.Visible = _editMenu.Enabled = runtimeScript != null &&
                    AppCommandRuntime.AppCommandRuntimeName == runtimeScript.RuntimeName;
        }
    }
}
