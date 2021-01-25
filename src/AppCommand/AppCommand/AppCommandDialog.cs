using NUMC;
using NUMC.Script;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NUMC.Expansion;
using System.Diagnostics;

namespace AppCommand
{
    public partial class AppCommandDialog : NUMC.Design.Dialog
    {
        public AppCommand SelectedCommand { get; set; } = null;
        private AppCommand[] _appCommands;

        public AppCommandDialog()
        {
            InitializeComponent();
            InitializeComboBox();
        }

        public AppCommandDialog(APPCOMMAND appCommand)
        {
            InitializeComponent();
            InitializeComboBox();

            for (int i = 0; i < _appCommands.Length; i++) {
                var r = _appCommands[i];
                if (r?.Command != appCommand) continue;
                commandComboBox.SelectedIndex = i;
                break;
            }
        }

        private void InitializeComboBox()
        {
            _appCommands = AppCommands.GetAppCommands();
            for (int i = 0; i < _appCommands.Length; i++)
                commandComboBox.Items.Add(_appCommands[i].Text);
            commandComboBox.SelectedIndex = 0;
            SelectedCommand = _appCommands.TryGetValue(0);
            commandComboBox.SelectedIndexChanged += 
                CommandComboBox_SelectedIndexChanged;
        }

        private void CommandComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var i = commandComboBox.SelectedIndex;
            if (i < 0) return;
            var command = _appCommands.TryGetValue(i);
            SelectedCommand = command;
        }
    }
}
