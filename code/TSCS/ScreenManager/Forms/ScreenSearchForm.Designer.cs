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
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPStart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIPEnd = new System.Windows.Forms.TextBox();
            this.btnSearchIP = new System.Windows.Forms.Button();
            this.listViewScrn = new System.Windows.Forms.ListView();
            this.id = new System.Windows.Forms.ColumnHeader();
            this.name = new System.Windows.Forms.ColumnHeader();
            this.ip = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.psBar = new System.Windows.Forms.ProgressBar();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            resources.ApplyResources(this.toolStripStatusLabel1, "toolStripStatusLabel1");
            // 
            // label1
            // 
            resources.ApplyResources(this.label1, "label1");
            this.label1.Name = "label1";
            // 
            // txtIPStart
            // 
            resources.ApplyResources(this.txtIPStart, "txtIPStart");
            this.txtIPStart.Name = "txtIPStart";
            // 
            // label2
            // 
            resources.ApplyResources(this.label2, "label2");
            this.label2.Name = "label2";
            // 
            // txtIPEnd
            // 
            resources.ApplyResources(this.txtIPEnd, "txtIPEnd");
            this.txtIPEnd.Name = "txtIPEnd";
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
            this.id,
            this.name,
            this.ip});
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
            // id
            // 
            resources.ApplyResources(this.id, "id");
            // 
            // name
            // 
            resources.ApplyResources(this.name, "name");
            // 
            // ip
            // 
            resources.ApplyResources(this.ip, "ip");
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
            // ScreenSearchForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.Controls.Add(this.psBar);
            this.Controls.Add(this.btnSearchIP);
            this.Controls.Add(this.listViewScrn);
            this.Controls.Add(this.txtIPEnd);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.txtIPStart);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ScreenSearchForm";
            this.ShowInTaskbar = false;
            this.TopMost = true;
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

        public void reloadIPList()
        {
            System.Windows.Forms.ListViewItem[] ItemList = new System.Windows.Forms.ListViewItem[screenList.List.Count];
            for (int i = 0; i < screenList.List.Count; i++)
            {

                ListViewItem mainItem = new ListViewItem();
                mainItem.Text = i.ToString();

                System.Windows.Forms.ListViewItem.ListViewSubItem ipItem = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                ipItem.Text = screenList.List[i].ScreenIP;

                System.Windows.Forms.ListViewItem.ListViewSubItem nameItem = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                nameItem.Text = screenList.List[i].ScreenName;


                mainItem.SubItems.Add(nameItem);
                mainItem.SubItems.Add(ipItem);
                ItemList[i] = mainItem;
                //   this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {mainItem});

            }
            this.listViewScrn.Items.Clear();
            this.listViewScrn.Items.AddRange(ItemList);
        }

       

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPStart;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIPEnd;
        private System.Windows.Forms.Button btnSearchIP;
        private System.Windows.Forms.ListView listViewScrn;
        private System.Windows.Forms.ColumnHeader id;
        private System.Windows.Forms.ColumnHeader name;
        private System.Windows.Forms.ColumnHeader ip;
        private ProgressBar psBar;
    }
}

