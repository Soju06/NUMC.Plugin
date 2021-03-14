using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switch {
    public partial class SwitchOptions : NUMC.Design.Form {
        private readonly Dictionary<string, Keys[]> Options = new Dictionary<string, Keys[]>();
        private readonly Button[] Buttons;

        private const int HotkeyCount = 5;
        private const int HotkeyTypeCount = 3;

        public SwitchOptions() {
            InitializeComponent();
            Buttons = new Button[] {
                button1, button2, button3, button4, button5,
                button6, button7, button8, button9, button10,
                button11, button12, button13, button14, button15
            };
            Options = LoadOptions();
            SetOptions();
        }

        private void SetOptions() {
            for (int i = 0; i < HotkeyTypeCount; i++) {
                if (!Options.TryGetValue(i.ToString(), out var value)) continue;
                for (int l = 0; l < HotkeyCount; l++) {
                    if (value.Length <= l) continue;
                    Buttons[(i * HotkeyCount) + l].Text = value[l].ToString();
                }
            }
        }

        private void HotkeyButtonClick(object sender, EventArgs e) {
            if(sender is Button btn && btn.Tag is int tag) {
                using (var dialog = new NUMC.Forms.Dialogs.KeysDialog()) {
                    if (dialog.ShowDialog() != DialogResult.OK) return;
                    var i = (tag / HotkeyCount).ToString();
                    if (!Options.TryGetValue(i, out var hotkeys)) {
                        Options.Add(i, new Keys[HotkeyCount]);
                        hotkeys = Options[i];
                    }
                    if (hotkeys.Length < HotkeyCount)
                        Array.Resize(ref hotkeys, HotkeyCount);
                    hotkeys[tag >= HotkeyCount ? tag % HotkeyCount : tag] = dialog.SelectItem;
                    btn.Text = dialog.SelectItem.ToString();
                    SaveOptions(i, hotkeys);
                }
            }
        }

        public static void SaveOptions(string i, Keys[] keys) {
            var script = NUMC.Service.GetService().GetScript();
            var value = script.GetObject().Settings["+plugins"]["+switch"].Values[$"+{i}"];
            value.SetString(string.Join(",", keys.Select(x => (int)x)));
            script.Save(NUMC.Setting.Setting.KeySettingPath);
        }

        public static Dictionary<string, Keys[]> LoadOptions() {
            var options = new Dictionary<string, Keys[]>();
            var script = NUMC.Service.GetService().GetScript();
            foreach (var item in script.GetObject().Settings["+plugins"]["+switch"].Values)
                options.Add(item.Key, GetKeys(item.Value.GetString()));
            return options;
        }

        public static Keys[] GetKeys(string s) {
            var keys = new List<Keys>();
            if(s != null) {
                var values = s.Split(',');
                for (int i = 0; i < values.Length; i++)
                    if (values[i] is string v && int.TryParse(v, out var k))
                        keys.Add((Keys)k);
            }
            var r = keys.ToArray();
            Array.Resize(ref r, HotkeyCount);
            return r;
        }
    }
}
