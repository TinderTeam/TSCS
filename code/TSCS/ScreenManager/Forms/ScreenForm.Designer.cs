using ScreenManager.Model.UI;
namespace ScreenManager
{

    partial class ScreenForm
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



            this.menuStrip = new System.Windows.Forms.MenuStrip();


            this.fileMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.newMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.openMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.functionMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.searchScreenMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.关闭软屏幕ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.版本说明ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.roadLong = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.InfoModify = new System.Windows.Forms.Button();
            this.EditInfo = new System.Windows.Forms.Button();
            this.lightLeverB = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.lightLeverA = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comStreenColor = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textScreenName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            
           
            this.setScreenBtn = new System.Windows.Forms.Button();
            this.defaltBtn = new System.Windows.Forms.Button();
   
           
            this.ipTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.IPModify = new System.Windows.Forms.Button();
            this.IPEdit = new System.Windows.Forms.Button();
           
            this.menuStrip.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roadLong)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightLeverB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightLeverA)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();

            // 
            // menuStrip1
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMntm,
            this.functionMntm,
            this.帮助ToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip1";
            this.menuStrip.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.fileMntm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMntm,
            this.openMntm,
            this.saveMntm,
            this.exitMntm});
            this.fileMntm.Name = "文件ToolStripMenuItem";
            this.fileMntm.Size = new System.Drawing.Size(44, 21);
            this.fileMntm.Text = "文件";
            // 
            // 新建模板ToolStripMenuItem
            // 
            this.newMntm.Name = "新建模板ToolStripMenuItem";
            this.newMntm.Size = new System.Drawing.Size(124, 22);
            this.newMntm.Text = "新建模板";
            // 
            // 打开模板ToolStripMenuItem
            // 
            this.openMntm.Name = "打开模板ToolStripMenuItem";
            this.openMntm.Size = new System.Drawing.Size(124, 22);
            this.openMntm.Text = "打开模板";
            // 
            // 保存ToolStripMenuItem
            // 
            this.saveMntm.Name = "保存ToolStripMenuItem";
            this.saveMntm.Size = new System.Drawing.Size(124, 22);
            this.saveMntm.Text = "保存";
            // 
            // 退出ToolStripMenuItem
            // 
            this.exitMntm.Name = "退出ToolStripMenuItem";
            this.exitMntm.Size = new System.Drawing.Size(124, 22);
            this.exitMntm.Text = "退出";
            // 
            // 功能ToolStripMenuItem
            // 
            this.functionMntm.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.searchScreenMntm,
            this.关闭软屏幕ToolStripMenuItem});
            this.functionMntm.Name = "功能ToolStripMenuItem";
            this.functionMntm.Size = new System.Drawing.Size(44, 21);
            this.functionMntm.Text = "功能";
            // 
            // 搜索屏幕ToolStripMenuItem
            // 
            this.searchScreenMntm.Name = "搜索屏幕ToolStripMenuItem";
            this.searchScreenMntm.Size = new System.Drawing.Size(133, 22);
            this.searchScreenMntm.Text = "搜索屏幕...";
            this.searchScreenMntm.Click += new System.EventHandler(this.搜索屏幕ToolStripMenuItem_Click);
            // 
            // 关闭软屏幕ToolStripMenuItem
            // 
            this.关闭软屏幕ToolStripMenuItem.Name = "关闭软屏幕ToolStripMenuItem";
            this.关闭软屏幕ToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.关闭软屏幕ToolStripMenuItem.Text = "关闭屏幕";
            this.关闭软屏幕ToolStripMenuItem.Click += new System.EventHandler(this.关闭软屏幕ToolStripMenuItem_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帮助ToolStripMenuItem1,
            this.版本说明ToolStripMenuItem,
            this.关于我们ToolStripMenuItem});
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 帮助ToolStripMenuItem1
            // 
            this.帮助ToolStripMenuItem1.Name = "帮助ToolStripMenuItem1";
            this.帮助ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.帮助ToolStripMenuItem1.Text = "帮助";
            // 
            // 版本说明ToolStripMenuItem
            // 
            this.版本说明ToolStripMenuItem.Name = "版本说明ToolStripMenuItem";
            this.版本说明ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.版本说明ToolStripMenuItem.Text = "版本说明";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 708);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.roadLong);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.InfoModify);
            this.groupBox1.Controls.Add(this.EditInfo);
            this.groupBox1.Controls.Add(this.lightLeverB);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.lightLeverA);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.comStreenColor);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textScreenName);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(15, 139);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 332);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "屏幕信息";
            // 
            // roadLong
            // 
            this.roadLong.Enabled = false;
            this.roadLong.Location = new System.Drawing.Point(19, 250);
            this.roadLong.Name = "roadLong";
            this.roadLong.Size = new System.Drawing.Size(162, 21);
            this.roadLong.TabIndex = 15;
            this.roadLong.Maximum = 500;
            this.roadLong.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 228);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 14;
            this.label1.Text = "设置屏幕长度";
            // 
            // InfoModify
            // 
            this.InfoModify.Enabled = false;
            this.InfoModify.Location = new System.Drawing.Point(19, 290);
            this.InfoModify.Name = "InfoModify";
            this.InfoModify.Size = new System.Drawing.Size(75, 23);
            this.InfoModify.TabIndex = 13;
            this.InfoModify.Text = "下发";
            this.InfoModify.UseVisualStyleBackColor = true;
            this.InfoModify.Click += new System.EventHandler(this.InfoModify_Click);
            // 
            // EditInfo
            // 
            this.EditInfo.Location = new System.Drawing.Point(106, 290);
            this.EditInfo.Name = "EditInfo";
            this.EditInfo.Size = new System.Drawing.Size(75, 23);
            this.EditInfo.TabIndex = 12;
            this.EditInfo.Text = "修改";
            this.EditInfo.UseVisualStyleBackColor = true;
            this.EditInfo.Click += new System.EventHandler(this.EditInfo_Click);
            // 
            // lightLeverB
            // 
            this.lightLeverB.Enabled = false;
            this.lightLeverB.Location = new System.Drawing.Point(67, 184);
            this.lightLeverB.Name = "lightLeverB";
            this.lightLeverB.Size = new System.Drawing.Size(114, 21);
            this.lightLeverB.TabIndex = 10;
            this.lightLeverB.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(38, 186);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(23, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "B级";
            // 
            // lightLeverA
            // 
            this.lightLeverA.Enabled = false;
            this.lightLeverA.Location = new System.Drawing.Point(67, 157);
            this.lightLeverA.Name = "lightLeverA";
            this.lightLeverA.Size = new System.Drawing.Size(114, 21);
            this.lightLeverA.TabIndex = 8;
            this.lightLeverA.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(38, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(23, 12);
            this.label5.TabIndex = 7;
            this.label5.Text = "A级";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 135);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "屏幕亮度";
            // 
            // comStreenColor
            // 
            this.comStreenColor.Enabled = false;
            this.comStreenColor.FormattingEnabled = true;
            this.comStreenColor.Location = new System.Drawing.Point(19, 94);
            this.comStreenColor.Name = "comStreenColor";
            this.comStreenColor.Size = new System.Drawing.Size(162, 20);
            this.comStreenColor.TabIndex = 5;
            this.comStreenColor.Text = "无";

            this.comStreenColor.Items.AddRange(Model.Constant.Constants.colorArray);
          
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 78);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "背景颜色";
            // 
            // textScreenName
            // 
            this.textScreenName.Enabled = false;
            this.textScreenName.Location = new System.Drawing.Point(19, 45);
            this.textScreenName.Name = "textScreenName";
            this.textScreenName.Size = new System.Drawing.Size(162, 21);
            this.textScreenName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 30);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "屏幕名称";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel1);
            this.groupBox2.Location = new System.Drawing.Point(218, 28);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(779, 637);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "显示内容设置";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 74F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 103F));





            //
            loadTable();


            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tableLayoutPanel1.RowCount = 10;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 9.615383F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.06261F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.04025F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.04025F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.04025F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.04025F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.04025F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.04025F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.04025F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.04025F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(773, 617);
            this.tableLayoutPanel1.TabIndex = 0;
           
            // 
            // screenShow
            // 
            this.setScreenBtn.Location = new System.Drawing.Point(903, 671);
            this.setScreenBtn.Name = "screenShow";
            this.setScreenBtn.Size = new System.Drawing.Size(94, 34);
            this.setScreenBtn.TabIndex = 4;
            this.setScreenBtn.Text = "下发显示";
            this.setScreenBtn.UseVisualStyleBackColor = true;
            // 
            // saveFile
            // 
            this.defaltBtn.Location = new System.Drawing.Point(803, 671);
            this.defaltBtn.Name = "saveFile";
            this.defaltBtn.Size = new System.Drawing.Size(94, 34);
            this.defaltBtn.TabIndex = 5;
            this.defaltBtn.Text = "保存模版";
            this.defaltBtn.UseVisualStyleBackColor = true;
           
          
            // 
            // ipTextBox
            // 
            this.ipTextBox.Enabled = false;
            this.ipTextBox.Location = new System.Drawing.Point(19, 29);
            this.ipTextBox.Name = "ipTextBox";
            this.ipTextBox.Size = new System.Drawing.Size(162, 21);
            this.ipTextBox.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.IPModify);
            this.groupBox3.Controls.Add(this.IPEdit);
            this.groupBox3.Controls.Add(this.ipTextBox);
            this.groupBox3.Location = new System.Drawing.Point(15, 28);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 105);
            this.groupBox3.TabIndex = 8;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "IP 地址";
            // 
            // IPModify
            // 
            this.IPModify.Enabled = false;
            this.IPModify.Location = new System.Drawing.Point(19, 71);
            this.IPModify.Name = "IPModify";
            this.IPModify.Size = new System.Drawing.Size(75, 23);
            this.IPModify.TabIndex = 13;
            this.IPModify.Text = "下发";
            this.IPModify.UseVisualStyleBackColor = true;
            this.IPModify.Click += new System.EventHandler(this.IPModify_Click);
            // 
            // IPEdit
            // 
            this.IPEdit.Location = new System.Drawing.Point(106, 71);
            this.IPEdit.Name = "IPEdit";
            this.IPEdit.Size = new System.Drawing.Size(75, 23);
            this.IPEdit.TabIndex = 12;
            this.IPEdit.Text = "修改";
            this.IPEdit.UseVisualStyleBackColor = true;
            this.IPEdit.Click += new System.EventHandler(this.IPEdit_Click);
            // 
            // ScreenForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.groupBox3);
            
           
            this.Controls.Add(this.defaltBtn);
            this.Controls.Add(this.setScreenBtn);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "ScreenForm";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.roadLong)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightLeverB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.lightLeverA)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        public  void loadTable()
        {
            RoadListView l=this.InitRoadList();
            this.tableLayoutPanel1.Controls.Clear();
            ScreenManager.Model.ScreenModel screenModel=this.InitModel();
            for (int i = 0; i < screenModel.roadList.Count; i++)
            {
                Model.RoadModel roadModel = this.model.roadList[i];
                roadModel.RoadID = i.ToString();

                RoadView rv = new RoadView();
                // 
                // labelid
                // 
                rv.id = new System.Windows.Forms.Label();
                rv.id.Text = (i+1).ToString();            
                rv.id.AutoSize = true;
                rv.id.Dock = System.Windows.Forms.DockStyle.Fill;
                rv.id.Location = new System.Drawing.Point(3, 0);
                rv.id.Name = "roadID_"+i.ToString();
                rv.id.Size = new System.Drawing.Size(34, 59);
                rv.id.TabIndex = i;
                rv.id.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;


                rv.name = new System.Windows.Forms.Label();
                rv.name.Text = roadModel.RoadName;
                rv.name.AutoSize = true;
                rv.name.Dock = System.Windows.Forms.DockStyle.Fill;
                rv.name.Location = new System.Drawing.Point(43, 0);
                rv.name.Name = "roadName_" + i.ToString();
                rv.name.Size = new System.Drawing.Size(68, 59);
                rv.name.TabIndex = i;
                rv.name.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;



                rv.btn = new IDButton(roadModel.RoadID);
                rv.btn.Anchor = System.Windows.Forms.AnchorStyles.None;
                rv.btn.Location = new System.Drawing.Point(684, 18);
                rv.btn.Name = "roadEdit_"+i.ToString();
                rv.btn.Size = new System.Drawing.Size(75, 23);
                rv.btn.TabIndex = i;
                rv.btn.Text = "编辑";
                rv.btn.UseVisualStyleBackColor = true;
                rv.btn.Click += new System.EventHandler(this.roadEdit);


                rv.panel = new RoadPanel(roadModel.RoadID);
                rv.panel.Dock = System.Windows.Forms.DockStyle.Fill;
                rv.panel.Location = new System.Drawing.Point(124, 20);
                rv.panel.Margin = new System.Windows.Forms.Padding(10, 20, 10, 20);
                rv.panel.Name = "roadPanel_"+i.ToString();
                rv.panel.Size = new System.Drawing.Size(536, 19);
                rv.panel.TabIndex = i;
                rv.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.roadPanel_Paint);



                this.tableLayoutPanel1.Controls.Add(rv.id, 0, i);
                this.tableLayoutPanel1.Controls.Add(rv.name, 1, i);            
                this.tableLayoutPanel1.Controls.Add(rv.panel, 2, i);
                this.tableLayoutPanel1.Controls.Add(rv.btn, 3, i);
            }
           
        }


        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textScreenName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown lightLeverB;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown lightLeverA;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comStreenColor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button setScreenBtn;
        private System.Windows.Forms.Button defaltBtn;

   

        private System.Windows.Forms.ToolStripMenuItem fileMntm;
        private System.Windows.Forms.ToolStripMenuItem newMntm;
        private System.Windows.Forms.ToolStripMenuItem openMntm;

        private System.Windows.Forms.Button InfoModify;
        private System.Windows.Forms.Button EditInfo;
        private System.Windows.Forms.TextBox ipTextBox;

        public System.Windows.Forms.TextBox IpTextBox
        {
            get { return ipTextBox; }
            set { ipTextBox = value; }
        }
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button IPModify;
        private System.Windows.Forms.Button IPEdit;
        private System.Windows.Forms.ToolStripMenuItem exitMntm;
        private System.Windows.Forms.ToolStripMenuItem functionMntm;
        private System.Windows.Forms.ToolStripMenuItem searchScreenMntm;
        private System.Windows.Forms.ToolStripMenuItem saveMntm;
        private System.Windows.Forms.ToolStripMenuItem 关闭软屏幕ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 版本说明ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.NumericUpDown roadLong;
        private System.Windows.Forms.Label label1;



   
    }
}