using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RuntimeCsharp
{
    public class RuntimeCsharpApplicationMenu : NUMC.Plugin.Menu.IApplicationMenu
    {
        public RuntimeCsharpApplicationMenu()
        {
            Menus = new ToolStripItem[] {
                NUMC.Menu.MenuStripSupport.AddMenuItem(null, "런타임 스크립트 관리", "rsm")
            };
            Menus[0].Click += RuntimeCsharpApplicationMenu_Click;
        }

        private void RuntimeCsharpApplicationMenu_Click(object sender, EventArgs e)
        {
            using (var rcm = new RuntimeCsharpManager())
                rcm.ShowDialog();
        }

        public int Index => -30;

        public ToolStripItem[] Menus { get; set; }

        public void Dispose()
        {
            NUMC.Menu.MenuStripSupport.DisposeItems(Menus);
        }

        public void Initialize(Script script)
        {

        }

        public void MenuClicking()
        {
             
        }
    }
}
