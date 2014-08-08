namespace ScreenManager.Forms.basicConfig
{
    partial class OpenCloseCtrlForm
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
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.rdbOpen = new System.Windows.Forms.RadioButton();
            this.rdbClose = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(70, 92);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 16;
            this.btnCancel.Text = "关闭";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 12);
            this.label1.TabIndex = 18;
            this.label1.Text = "当前屏幕状态：";
            // 
            // rdbOpen
            // 
            this.rdbOpen.AutoSize = true;
            this.rdbOpen.Location = new System.Drawing.Point(119, 27);
            this.rdbOpen.Name = "rdbOpen";
            this.rdbOpen.Size = new System.Drawing.Size(47, 16);
            this.rdbOpen.TabIndex = 19;
            this.rdbOpen.TabStop = true;
            this.rdbOpen.Text = "打开";
            this.rdbOpen.UseVisualStyleBackColor = true;
            // 
            // rdbClose
            // 
            this.rdbClose.AutoSize = true;
            this.rdbClose.Location = new System.Drawing.Point(119, 52);
            this.rdbClose.Name = "rdbClose";
            this.rdbClose.Size = new System.Drawing.Size(47, 16);
            this.rdbClose.TabIndex = 20;
            this.rdbClose.TabStop = true;
            this.rdbClose.Text = "关闭";
            this.rdbClose.UseVisualStyleBackColor = true;
            // 
            // OpenCloseCtrlForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(218, 127);
            this.ControlBox = false;
            this.Controls.Add(this.rdbClose);
            this.Controls.Add(this.rdbOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnCancel);
            this.Name = "OpenCloseCtrlForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏幕开关设置";
            this.Load += new System.EventHandler(this.OpenCloseCtrlForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton rdbOpen;
        private System.Windows.Forms.RadioButton rdbClose;
    }
}