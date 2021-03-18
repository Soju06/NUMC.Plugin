using NUMC;
using NUMC.Plugin.Menu;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switch
{
    public class Switch : IApplicationMenu {
        private SwitchCore Core;
        public Switch() {
            var items = new List<ToolStripItem>();
            NUMC.Menu.MenuStripSupport.AddMenuItem(items, "Switch Options", "opt").Click += SwitchOptionClick;
            Menus = items.ToArray();
        }

        private void SwitchOptionClick(object sender, EventArgs e) {
            using (var dialog = new SwitchOptions())
                dialog.ShowDialog();
        }

        public int Index => 0;

        public ToolStripItem[] Menus { get; private set; }


        public void Dispose() {
            NUMC.Menu.MenuStripSupport.DisposeItems(Menus);
            Core?.Dispose();
        }

        public void Initialize(Service service) {
            if(Core == null)
                Core = new SwitchCore();
        }

        public void MenuClicking() {

        }
    }
}
