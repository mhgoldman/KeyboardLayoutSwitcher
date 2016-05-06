namespace KeyboardLayoutSwitcher
{
    partial class MainForm
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
            this.keyboardLayoutCmb = new System.Windows.Forms.ComboBox();
            this.setLayoutBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // keyboardLayoutCmb
            // 
            this.keyboardLayoutCmb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.keyboardLayoutCmb.FormattingEnabled = true;
            this.keyboardLayoutCmb.Location = new System.Drawing.Point(13, 26);
            this.keyboardLayoutCmb.Name = "keyboardLayoutCmb";
            this.keyboardLayoutCmb.Size = new System.Drawing.Size(259, 21);
            this.keyboardLayoutCmb.TabIndex = 0;
            // 
            // setLayoutBtn
            // 
            this.setLayoutBtn.Location = new System.Drawing.Point(80, 96);
            this.setLayoutBtn.Name = "setLayoutBtn";
            this.setLayoutBtn.Size = new System.Drawing.Size(115, 36);
            this.setLayoutBtn.TabIndex = 1;
            this.setLayoutBtn.Text = "Set Layout && Restart";
            this.setLayoutBtn.UseVisualStyleBackColor = true;
            this.setLayoutBtn.Click += new System.EventHandler(this.setLayoutBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(173, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Select the desired keyboard layout:";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(13, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(259, 27);
            this.label2.TabIndex = 3;
            this.label2.Text = "WARNING: Your VM(s) will be restarted when this setting is changed!";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(282, 139);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.setLayoutBtn);
            this.Controls.Add(this.keyboardLayoutCmb);
            this.Name = "MainForm";
            this.Text = "Keyboard Layout Switcher";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox keyboardLayoutCmb;
        private System.Windows.Forms.Button setLayoutBtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

