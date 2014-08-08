using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenManager.Model;


namespace ScreenManager
{
    partial class ScreenSearchForm
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
        /// 

  
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenSearchForm));
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnSearchIP = new System.Windows.Forms.Button();
            this.listViewScrn = new System.Windows.Forms.ListView();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.ip = new System.Windows.Forms.ColumnHeader();
            this.roadNames = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.psBar = new System.Windows.Forms.ProgressBar();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // btnSearchIP
            // 
            resources.ApplyResources(this.btnSearchIP, "btnSearchIP");
            this.btnSearchIP.Name = "btnSearchIP";
            this.btnSearchIP.UseVisualStyleBackColor = true;
            this.btnSearchIP.Click += new System.EventHandler(this.searchIP);
            // 
            // listViewScrn
            // 
            this.listViewScrn.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.name,
            this.ip,
            this.roadNames});
            this.listViewScrn.ForeColor = System.Drawing.SystemColors.WindowText;
            this.listViewScrn.FullRowSelect = true;
            this.listViewScrn.GridLines = true;
            this.listViewScrn.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            resources.ApplyResources(this.listViewScrn, "listViewScrn");
            this.listViewScrn.Name = "listViewScrn";
            this.listViewScrn.UseCompatibleStateImageBehavior = false;
            this.listViewScrn.View = System.Windows.Forms.View.Details;
            this.listViewScrn.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.selcetedScreen);
            // 
            // name
            // 
            resources.ApplyResources(this.name, "name");
            // 
            // ip
            // 
            resources.ApplyResources(this.ip, "ip");
            // 
            // roadNames
            // 
            resources.ApplyResources(this.roadNames, "roadNames");
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // psBar
            // 
            resources.ApplyResources(this.psBar, "psBar");
            this.psBar.Name = "psBar";
            // 
            // label3
            // 
            resources.ApplyResources(this.label3, "label3");
            this.label3.Name = "label3";
            // 
            // label4
            // 
            resources.ApplyResources(this.label4, "label4");
            this.label4.Name = "label4";
            // 
            // ScreenSearchForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.psBar);
            this.Controls.Add(this.btnSearchIP);
            this.Controls.Add(this.listViewScrn);
            this.Controls.Add(this.statusStrip1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenSearchForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
            this.Load += new System.EventHandler(this.ScreenSearchForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void loadIPList(System.ComponentModel.ComponentResourceManager resources)
        {
            if (screenList != null)
            {
                reloadIPList();
               
                
            }
            resources.ApplyResources(this.listViewScrn, "listView1");
        }

       

       

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Button btnSearchIP;
        private System.Windows.Forms.ListView listViewScrn;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader ip;
        private ProgressBar psBar;
        private Label label3;
        private Label label4;
        private ColumnHeader roadNames;
    }
}

