
namespace RuntimeCsharp
{
    partial class RuntimeCsharpManager
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RuntimeCsharpManager));
            this.scriptsView = new NUMC.Design.Controls.TreeView();
            this.label1 = new NUMC.Design.Controls.Label();
            this.button1 = new NUMC.Design.Controls.Button();
            this.edit_Button = new NUMC.Design.Controls.Button();
            this.button4 = new NUMC.Design.Controls.Button();
            this.remove_Button = new NUMC.Design.Controls.Button();
            this.disEanable_Button = new NUMC.Design.Controls.Button();
            this.fastColoredTextBox1 = new FastColoredTextBoxNS.FastColoredTextBox();
            this.documentMap1 = new FastColoredTextBoxNS.DocumentMap();
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // scriptsView
            // 
            this.scriptsView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.scriptsView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))), ((int)(((byte)(38)))));
            this.scriptsView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(225)))), ((int)(((byte)(225)))), ((int)(((byte)(225)))));
            this.scriptsView.ItemHeight = 25;
            this.scriptsView.Location = new System.Drawing.Point(18, 75);
            this.scriptsView.Margin = new System.Windows.Forms.Padding(3, 3, 3, 7);
            this.scriptsView.MaxDragChange = 25;
            this.scriptsView.Name = "scriptsView";
            this.scriptsView.Size = new System.Drawing.Size(395, 752);
            this.scriptsView.TabIndex = 0;
            this.scriptsView.Text = "treeView1";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.label1.FontSize = 10F;
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.label1.Location = new System.Drawing.Point(18, 49);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(395, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "스크립트 파일:";
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.button1.FontSize = 10F;
            this.button1.Location = new System.Drawing.Point(147, 834);
            this.button1.Margin = new System.Windows.Forms.Padding(0);
            this.button1.Name = "button1";
            this.button1.Padding = new System.Windows.Forms.Padding(5);
            this.button1.Size = new System.Drawing.Size(104, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "스크립트 추가";
            // 
            // edit_Button
            // 
            this.edit_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.edit_Button.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.edit_Button.FontSize = 10F;
            this.edit_Button.Location = new System.Drawing.Point(251, 834);
            this.edit_Button.Margin = new System.Windows.Forms.Padding(0);
            this.edit_Button.Name = "edit_Button";
            this.edit_Button.Padding = new System.Windows.Forms.Padding(5);
            this.edit_Button.Size = new System.Drawing.Size(45, 23);
            this.edit_Button.TabIndex = 2;
            this.edit_Button.Text = "편집";
            // 
            // button4
            // 
            this.button4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button4.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.button4.FontSize = 12F;
            this.button4.Location = new System.Drawing.Point(1502, 41);
            this.button4.Name = "button4";
            this.button4.Padding = new System.Windows.Forms.Padding(5);
            this.button4.Size = new System.Drawing.Size(214, 31);
            this.button4.TabIndex = 3;
            this.button4.Text = "스크립트 컴파일 / 패치";
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // remove_Button
            // 
            this.remove_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.remove_Button.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.remove_Button.FontSize = 10F;
            this.remove_Button.Location = new System.Drawing.Point(296, 834);
            this.remove_Button.Margin = new System.Windows.Forms.Padding(0);
            this.remove_Button.Name = "remove_Button";
            this.remove_Button.Padding = new System.Windows.Forms.Padding(5);
            this.remove_Button.Size = new System.Drawing.Size(45, 23);
            this.remove_Button.TabIndex = 2;
            this.remove_Button.Text = "제거";
            // 
            // disEanable_Button
            // 
            this.disEanable_Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.disEanable_Button.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.disEanable_Button.FontSize = 10F;
            this.disEanable_Button.Location = new System.Drawing.Point(341, 834);
            this.disEanable_Button.Margin = new System.Windows.Forms.Padding(0);
            this.disEanable_Button.Name = "disEanable_Button";
            this.disEanable_Button.Padding = new System.Windows.Forms.Padding(5);
            this.disEanable_Button.Size = new System.Drawing.Size(72, 23);
            this.disEanable_Button.TabIndex = 2;
            this.disEanable_Button.Text = "비활성화";
            // 
            // fastColoredTextBox1
            // 
            this.fastColoredTextBox1.AutoCompleteBracketsList = new char[] {
        '(',
        ')',
        '{',
        '}',
        '[',
        ']',
        '\"',
        '\"',
        '\'',
        '\''};
            this.fastColoredTextBox1.AutoIndentCharsPatterns = "\r\n^\\s*[\\w\\.]+(\\s\\w+)?\\s*(?<range>=)\\s*(?<range>[^;=]+);\r\n^\\s*(case|default)\\s*[^:" +
    "]*(?<range>:)\\s*(?<range>[^;]+);\r\n";
            this.fastColoredTextBox1.AutoScrollMinSize = new System.Drawing.Size(1271, 1872);
            this.fastColoredTextBox1.BackBrush = null;
            this.fastColoredTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.BracketsHighlightStrategy = FastColoredTextBoxNS.BracketsHighlightStrategy.Strategy2;
            this.fastColoredTextBox1.CharHeight = 18;
            this.fastColoredTextBox1.CharWidth = 9;
            this.fastColoredTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.fastColoredTextBox1.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.fastColoredTextBox1.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Bold);
            this.fastColoredTextBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(230)))), ((int)(((byte)(230)))), ((int)(((byte)(230)))));
            this.fastColoredTextBox1.Hotkeys = resources.GetString("fastColoredTextBox1.Hotkeys");
            this.fastColoredTextBox1.IndentBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))), ((int)(((byte)(120)))));
            this.fastColoredTextBox1.IsReplaceMode = false;
            this.fastColoredTextBox1.Language = FastColoredTextBoxNS.Language.CSharp;
            this.fastColoredTextBox1.LeftBracket = '(';
            this.fastColoredTextBox1.LeftBracket2 = '{';
            this.fastColoredTextBox1.Location = new System.Drawing.Point(419, 79);
            this.fastColoredTextBox1.Name = "fastColoredTextBox1";
            this.fastColoredTextBox1.PaddingBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.Paddings = new System.Windows.Forms.Padding(0);
            this.fastColoredTextBox1.RightBracket = ')';
            this.fastColoredTextBox1.RightBracket2 = '}';
            this.fastColoredTextBox1.SelectionColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.fastColoredTextBox1.ServiceColors = new FastColoredTextBoxNS.ServiceColors();
            this.fastColoredTextBox1.ServiceLinesColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.fastColoredTextBox1.Size = new System.Drawing.Size(1083, 748);
            this.fastColoredTextBox1.TabIndex = 4;
            this.fastColoredTextBox1.TabStop = false;
            this.fastColoredTextBox1.Text = resources.GetString("fastColoredTextBox1.Text");
            this.fastColoredTextBox1.Zoom = 100;
            // 
            // documentMap1
            // 
            this.documentMap1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.documentMap1.Location = new System.Drawing.Point(1508, 75);
            this.documentMap1.Name = "documentMap1";
            this.documentMap1.ScrollbarVisible = false;
            this.documentMap1.Size = new System.Drawing.Size(208, 752);
            this.documentMap1.TabIndex = 5;
            this.documentMap1.Target = this.fastColoredTextBox1;
            this.documentMap1.Text = "documentMap1";
            // 
            // RuntimeCsharpManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1734, 872);
            this.Controls.Add(this.documentMap1);
            this.Controls.Add(this.fastColoredTextBox1);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.scriptsView);
            this.Controls.Add(this.edit_Button);
            this.Controls.Add(this.disEanable_Button);
            this.Controls.Add(this.remove_Button);
            this.Controls.Add(this.label1);
            this.MinimizeBox = false;
            this.Name = "RuntimeCsharpManager";
            this.Padding = new System.Windows.Forms.Padding(15, 49, 15, 15);
            this.Text = "RuntimeCsharpManager";
            ((System.ComponentModel.ISupportInitialize)(this.fastColoredTextBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private NUMC.Design.Controls.TreeView scriptsView;
        private NUMC.Design.Controls.Label label1;
        private NUMC.Design.Controls.Button button1;
        private NUMC.Design.Controls.Button edit_Button;
        private NUMC.Design.Controls.Button button4;
        private NUMC.Design.Controls.Button remove_Button;
        private NUMC.Design.Controls.Button disEanable_Button;
        private FastColoredTextBoxNS.FastColoredTextBox fastColoredTextBox1;
        private FastColoredTextBoxNS.DocumentMap documentMap1;
    }
}