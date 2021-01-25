
namespace AppCommand
{
    partial class AppCommandDialog
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
            this.commandComboBox = new NUMC.Design.Controls.ComboBox();
            this.SuspendLayout();
            // 
            // commandComboBox
            // 
            this.commandComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.commandComboBox.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawVariable;
            this.commandComboBox.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.commandComboBox.FormattingEnabled = true;
            this.commandComboBox.Location = new System.Drawing.Point(12, 45);
            this.commandComboBox.Margin = new System.Windows.Forms.Padding(10, 3, 10, 3);
            this.commandComboBox.Name = "commandComboBox";
            this.commandComboBox.Size = new System.Drawing.Size(395, 26);
            this.commandComboBox.TabIndex = 2;
            // 
            // AppCommandDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(419, 130);
            this.Controls.Add(this.commandComboBox);
            this.DialogButtons = NUMC.Design.Controls.MessageBoxButtons.OkCancel;
            this.Name = "AppCommandDialog";
            this.Resizing = false;
            this.Text = "App Command add or edit";
            this.Controls.SetChildIndex(this.commandComboBox, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private NUMC.Design.Controls.ComboBox commandComboBox;
    }
}