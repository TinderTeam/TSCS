namespace ScreenManager.Form
{
    partial class ScreenEditForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ScreenEditForm));
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileMnlst = new System.Windows.Forms.ToolStripMenuItem();
            this.newMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.openMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.saveMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.exitMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.functionMnlst = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMnlst = new System.Windows.Forms.ToolStripMenuItem();
            this.helpMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutMntm = new System.Windows.Forms.ToolStripMenuItem();
            this.formTablePanel = new System.Windows.Forms.TableLayoutPanel();
            this.groupScreenView = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.groupRoadSegmentEdit = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.lstVwSgmt = new System.Windows.Forms.ListView();
            this.sgmtID = new System.Windows.Forms.ColumnHeader();
            this.rdName = new System.Windows.Forms.ColumnHeader();
            this.start = new System.Windows.Forms.ColumnHeader();
            this.end = new System.Windows.Forms.ColumnHeader();
            this.clr = new System.Windows.Forms.ColumnHeader();
            this.groupBoxSgmtEdit = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.labelSgmtID = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.btnSet = new System.Windows.Forms.Button();
            this.btnDefault = new System.Windows.Forms.Button();
            this.tableLeft = new System.Windows.Forms.TableLayoutPanel();
            this.tableLeftN = new System.Windows.Forms.TableLayoutPanel();
            this.logoBox = new System.Windows.Forms.PictureBox();
            this.groupScreenInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanelScrnInfo = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.labelLtB = new System.Windows.Forms.Label();
            this.txtNumB = new System.Windows.Forms.NumericUpDown();
            this.labelScrnLt = new System.Windows.Forms.Label();
            this.cmbScrnClr = new System.Windows.Forms.ComboBox();
            this.labelScrnBckClr = new System.Windows.Forms.Label();
            this.btnIpMacEdit = new System.Windows.Forms.Button();
            this.btnScrnLthEdit = new System.Windows.Forms.Button();
            this.labelScrnName = new System.Windows.Forms.Label();
            this.txtScrnName = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.labelLtA = new System.Windows.Forms.Label();
            this.txtNumA = new System.Windows.Forms.NumericUpDown();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.btnScrnEdit = new System.Windows.Forms.Button();
            this.btnScrnSet = new System.Windows.Forms.Button();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
            this.numericUpDown2 = new System.Windows.Forms.NumericUpDown();
            this.menuStrip.SuspendLayout();
            this.formTablePanel.SuspendLayout();
            this.groupScreenView.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            this.groupRoadSegmentEdit.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.groupBoxSgmtEdit.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.tableLeft.SuspendLayout();
            this.tableLeftN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).BeginInit();
            this.groupScreenInfo.SuspendLayout();
            this.tableLayoutPanelScrnInfo.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumB)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumA)).BeginInit();
            this.tableLayoutPanel3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileMnlst,
            this.functionMnlst,
            this.helpMnlst});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(1008, 25);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "菜单栏";
            // 
            // fileMnlst
            // 
            this.fileMnlst.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMntm,
            this.openMntm,
            this.saveMntm,
            this.exitMntm});
            this.fileMnlst.Name = "fileMnlst";
            this.fileMnlst.Size = new System.Drawing.Size(44, 21);
            this.fileMnlst.Text = "文件";
            // 
            // newMntm
            // 
            this.newMntm.Name = "newMntm";
            this.newMntm.Size = new System.Drawing.Size(109, 22);
            this.newMntm.Text = "新建";
            // 
            // openMntm
            // 
            this.openMntm.Name = "openMntm";
            this.openMntm.Size = new System.Drawing.Size(109, 22);
            this.openMntm.Text = "打开...";
            // 
            // saveMntm
            // 
            this.saveMntm.Name = "saveMntm";
            this.saveMntm.Size = new System.Drawing.Size(109, 22);
            this.saveMntm.Text = "保存...";
            // 
            // exitMntm
            // 
            this.exitMntm.Name = "exitMntm";
            this.exitMntm.Size = new System.Drawing.Size(109, 22);
            this.exitMntm.Text = "退出";
            // 
            // functionMnlst
            // 
            this.functionMnlst.Name = "functionMnlst";
            this.functionMnlst.Size = new System.Drawing.Size(44, 21);
            this.functionMnlst.Text = "功能";
            // 
            // helpMnlst
            // 
            this.helpMnlst.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.helpMntm,
            this.aboutMntm});
            this.helpMnlst.Name = "helpMnlst";
            this.helpMnlst.Size = new System.Drawing.Size(44, 21);
            this.helpMnlst.Text = "帮助";
            // 
            // helpMntm
            // 
            this.helpMntm.Name = "helpMntm";
            this.helpMntm.Size = new System.Drawing.Size(124, 22);
            this.helpMntm.Text = "帮助...";
            // 
            // aboutMntm
            // 
            this.aboutMntm.Name = "aboutMntm";
            this.aboutMntm.Size = new System.Drawing.Size(124, 22);
            this.aboutMntm.Text = "关于软件";
            // 
            // formTablePanel
            // 
            this.formTablePanel.ColumnCount = 3;
            this.formTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.18182F));
            this.formTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 54.54546F));
            this.formTablePanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 27.27273F));
            this.formTablePanel.Controls.Add(this.groupScreenView, 1, 0);
            this.formTablePanel.Controls.Add(this.groupRoadSegmentEdit, 2, 0);
            this.formTablePanel.Controls.Add(this.tableLeft, 0, 0);
            this.formTablePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.formTablePanel.Location = new System.Drawing.Point(0, 25);
            this.formTablePanel.Name = "formTablePanel";
            this.formTablePanel.RowCount = 1;
            this.formTablePanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.formTablePanel.Size = new System.Drawing.Size(1008, 705);
            this.formTablePanel.TabIndex = 1;
            // 
            // groupScreenView
            // 
            this.groupScreenView.Controls.Add(this.tableLayoutPanel4);
            this.groupScreenView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupScreenView.Location = new System.Drawing.Point(186, 3);
            this.groupScreenView.Name = "groupScreenView";
            this.groupScreenView.Size = new System.Drawing.Size(543, 699);
            this.groupScreenView.TabIndex = 0;
            this.groupScreenView.TabStop = false;
            this.groupScreenView.Text = "图示";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 80F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.textBox1, 1, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 10;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(537, 679);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.textBox1.Location = new System.Drawing.Point(23, 23);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(74, 21);
            this.textBox1.TabIndex = 0;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // groupRoadSegmentEdit
            // 
            this.groupRoadSegmentEdit.Controls.Add(this.tableLayoutPanel5);
            this.groupRoadSegmentEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupRoadSegmentEdit.Location = new System.Drawing.Point(735, 3);
            this.groupRoadSegmentEdit.Name = "groupRoadSegmentEdit";
            this.groupRoadSegmentEdit.Size = new System.Drawing.Size(270, 699);
            this.groupRoadSegmentEdit.TabIndex = 1;
            this.groupRoadSegmentEdit.TabStop = false;
            this.groupRoadSegmentEdit.Text = "路段管理";
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel5.Controls.Add(this.lstVwSgmt, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.groupBoxSgmtEdit, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tableLayoutPanel6, 0, 2);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 3;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(264, 679);
            this.tableLayoutPanel5.TabIndex = 0;
            // 
            // lstVwSgmt
            // 
            this.lstVwSgmt.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sgmtID,
            this.rdName,
            this.start,
            this.end,
            this.clr});
            this.lstVwSgmt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lstVwSgmt.GridLines = true;
            this.lstVwSgmt.Location = new System.Drawing.Point(3, 3);
            this.lstVwSgmt.Name = "lstVwSgmt";
            this.lstVwSgmt.Size = new System.Drawing.Size(258, 313);
            this.lstVwSgmt.TabIndex = 0;
            this.lstVwSgmt.UseCompatibleStateImageBehavior = false;
            this.lstVwSgmt.View = System.Windows.Forms.View.Details;
            // 
            // sgmtID
            // 
            this.sgmtID.Text = "路段号";
            // 
            // rdName
            // 
            this.rdName.Text = "道路名";
            this.rdName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.rdName.Width = 80;
            // 
            // start
            // 
            this.start.Text = "起";
            this.start.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.start.Width = 30;
            // 
            // end
            // 
            this.end.Text = "止";
            this.end.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.end.Width = 30;
            // 
            // clr
            // 
            this.clr.Text = "颜色";
            this.clr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.clr.Width = 50;
            // 
            // groupBoxSgmtEdit
            // 
            this.groupBoxSgmtEdit.Controls.Add(this.tableLayoutPanel7);
            this.groupBoxSgmtEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBoxSgmtEdit.Location = new System.Drawing.Point(3, 322);
            this.groupBoxSgmtEdit.Name = "groupBoxSgmtEdit";
            this.groupBoxSgmtEdit.Size = new System.Drawing.Size(258, 313);
            this.groupBoxSgmtEdit.TabIndex = 1;
            this.groupBoxSgmtEdit.TabStop = false;
            this.groupBoxSgmtEdit.Text = "路段编辑";
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.Controls.Add(this.label1, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.labelSgmtID, 0, 0);
            this.tableLayoutPanel7.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel8, 0, 3);
            this.tableLayoutPanel7.Controls.Add(this.tableLayoutPanel9, 0, 4);
            this.tableLayoutPanel7.Location = new System.Drawing.Point(6, 39);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 7;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Size = new System.Drawing.Size(246, 242);
            this.tableLayoutPanel7.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "192.168.1.1";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelSgmtID
            // 
            this.labelSgmtID.AutoSize = true;
            this.labelSgmtID.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelSgmtID.Location = new System.Drawing.Point(3, 0);
            this.labelSgmtID.Name = "labelSgmtID";
            this.labelSgmtID.Size = new System.Drawing.Size(240, 66);
            this.labelSgmtID.TabIndex = 3;
            this.labelSgmtID.Text = "路段号:";
            this.labelSgmtID.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(96, 136);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 5;
            this.label2.Text = "路段位置";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.ColumnCount = 2;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel6.Controls.Add(this.btnSet, 1, 0);
            this.tableLayoutPanel6.Controls.Add(this.btnDefault, 0, 0);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 641);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 1;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(258, 35);
            this.tableLayoutPanel6.TabIndex = 2;
            // 
            // btnSet
            // 
            this.btnSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSet.Location = new System.Drawing.Point(132, 3);
            this.btnSet.Name = "btnSet";
            this.btnSet.Size = new System.Drawing.Size(123, 29);
            this.btnSet.TabIndex = 1;
            this.btnSet.Text = "下发修改";
            this.btnSet.UseVisualStyleBackColor = true;
            // 
            // btnDefault
            // 
            this.btnDefault.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnDefault.Location = new System.Drawing.Point(3, 3);
            this.btnDefault.Name = "btnDefault";
            this.btnDefault.Size = new System.Drawing.Size(123, 29);
            this.btnDefault.TabIndex = 0;
            this.btnDefault.Text = "恢复默认";
            this.btnDefault.UseVisualStyleBackColor = true;
            // 
            // tableLeft
            // 
            this.tableLeft.ColumnCount = 1;
            this.tableLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLeft.Controls.Add(this.tableLeftN, 0, 0);
            this.tableLeft.Controls.Add(this.groupScreenInfo, 0, 1);
            this.tableLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLeft.Location = new System.Drawing.Point(3, 3);
            this.tableLeft.Name = "tableLeft";
            this.tableLeft.RowCount = 2;
            this.tableLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tableLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLeft.Size = new System.Drawing.Size(177, 699);
            this.tableLeft.TabIndex = 2;
            // 
            // tableLeftN
            // 
            this.tableLeftN.ColumnCount = 1;
            this.tableLeftN.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLeftN.Controls.Add(this.logoBox, 0, 1);
            this.tableLeftN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLeftN.Location = new System.Drawing.Point(3, 3);
            this.tableLeftN.Name = "tableLeftN";
            this.tableLeftN.RowCount = 3;
            this.tableLeftN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLeftN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLeftN.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLeftN.Size = new System.Drawing.Size(171, 144);
            this.tableLeftN.TabIndex = 0;
            // 
            // logoBox
            // 
            this.logoBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.logoBox.Image = ((System.Drawing.Image)(resources.GetObject("logoBox.Image")));
            this.logoBox.Location = new System.Drawing.Point(3, 23);
            this.logoBox.Name = "logoBox";
            this.logoBox.Size = new System.Drawing.Size(165, 98);
            this.logoBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoBox.TabIndex = 0;
            this.logoBox.TabStop = false;
            // 
            // groupScreenInfo
            // 
            this.groupScreenInfo.Controls.Add(this.tableLayoutPanelScrnInfo);
            this.groupScreenInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupScreenInfo.Location = new System.Drawing.Point(3, 153);
            this.groupScreenInfo.Name = "groupScreenInfo";
            this.groupScreenInfo.Size = new System.Drawing.Size(171, 543);
            this.groupScreenInfo.TabIndex = 1;
            this.groupScreenInfo.TabStop = false;
            this.groupScreenInfo.Text = "屏幕信息";
            // 
            // tableLayoutPanelScrnInfo
            // 
            this.tableLayoutPanelScrnInfo.ColumnCount = 1;
            this.tableLayoutPanelScrnInfo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelScrnInfo.Controls.Add(this.tableLayoutPanel2, 0, 8);
            this.tableLayoutPanelScrnInfo.Controls.Add(this.labelScrnLt, 0, 6);
            this.tableLayoutPanelScrnInfo.Controls.Add(this.cmbScrnClr, 0, 5);
            this.tableLayoutPanelScrnInfo.Controls.Add(this.labelScrnBckClr, 0, 4);
            this.tableLayoutPanelScrnInfo.Controls.Add(this.btnIpMacEdit, 0, 0);
            this.tableLayoutPanelScrnInfo.Controls.Add(this.btnScrnLthEdit, 0, 1);
            this.tableLayoutPanelScrnInfo.Controls.Add(this.labelScrnName, 0, 2);
            this.tableLayoutPanelScrnInfo.Controls.Add(this.txtScrnName, 0, 3);
            this.tableLayoutPanelScrnInfo.Controls.Add(this.tableLayoutPanel1, 0, 7);
            this.tableLayoutPanelScrnInfo.Controls.Add(this.tableLayoutPanel3, 0, 11);
            this.tableLayoutPanelScrnInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelScrnInfo.Location = new System.Drawing.Point(3, 17);
            this.tableLayoutPanelScrnInfo.Name = "tableLayoutPanelScrnInfo";
            this.tableLayoutPanelScrnInfo.RowCount = 12;
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 31F));
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrnInfo.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanelScrnInfo.Size = new System.Drawing.Size(165, 523);
            this.tableLayoutPanelScrnInfo.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.labelLtB, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtNumB, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 234);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(159, 23);
            this.tableLayoutPanel2.TabIndex = 9;
            // 
            // labelLtB
            // 
            this.labelLtB.AutoSize = true;
            this.labelLtB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLtB.Location = new System.Drawing.Point(3, 0);
            this.labelLtB.Name = "labelLtB";
            this.labelLtB.Size = new System.Drawing.Size(23, 23);
            this.labelLtB.TabIndex = 8;
            this.labelLtB.Text = "B级";
            this.labelLtB.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumB
            // 
            this.txtNumB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumB.Location = new System.Drawing.Point(32, 3);
            this.txtNumB.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtNumB.Name = "txtNumB";
            this.txtNumB.Size = new System.Drawing.Size(124, 21);
            this.txtNumB.TabIndex = 9;
            // 
            // labelScrnLt
            // 
            this.labelScrnLt.AutoSize = true;
            this.labelScrnLt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelScrnLt.Location = new System.Drawing.Point(3, 171);
            this.labelScrnLt.Name = "labelScrnLt";
            this.labelScrnLt.Size = new System.Drawing.Size(159, 31);
            this.labelScrnLt.TabIndex = 7;
            this.labelScrnLt.Text = "背景亮度";
            this.labelScrnLt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cmbScrnClr
            // 
            this.cmbScrnClr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbScrnClr.FormattingEnabled = true;
            this.cmbScrnClr.Location = new System.Drawing.Point(3, 148);
            this.cmbScrnClr.Name = "cmbScrnClr";
            this.cmbScrnClr.Size = new System.Drawing.Size(159, 20);
            this.cmbScrnClr.TabIndex = 6;
            // 
            // labelScrnBckClr
            // 
            this.labelScrnBckClr.AutoSize = true;
            this.labelScrnBckClr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelScrnBckClr.Location = new System.Drawing.Point(3, 115);
            this.labelScrnBckClr.Name = "labelScrnBckClr";
            this.labelScrnBckClr.Size = new System.Drawing.Size(159, 30);
            this.labelScrnBckClr.TabIndex = 4;
            this.labelScrnBckClr.Text = "背景颜色";
            this.labelScrnBckClr.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // btnIpMacEdit
            // 
            this.btnIpMacEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnIpMacEdit.Location = new System.Drawing.Point(3, 3);
            this.btnIpMacEdit.Name = "btnIpMacEdit";
            this.btnIpMacEdit.Size = new System.Drawing.Size(159, 23);
            this.btnIpMacEdit.TabIndex = 0;
            this.btnIpMacEdit.Text = "IP/MAC 配置";
            this.btnIpMacEdit.UseVisualStyleBackColor = true;
            // 
            // btnScrnLthEdit
            // 
            this.btnScrnLthEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnScrnLthEdit.Location = new System.Drawing.Point(3, 32);
            this.btnScrnLthEdit.Name = "btnScrnLthEdit";
            this.btnScrnLthEdit.Size = new System.Drawing.Size(159, 23);
            this.btnScrnLthEdit.TabIndex = 1;
            this.btnScrnLthEdit.Text = "屏长度配置";
            this.btnScrnLthEdit.UseVisualStyleBackColor = true;
            // 
            // labelScrnName
            // 
            this.labelScrnName.AutoSize = true;
            this.labelScrnName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelScrnName.Location = new System.Drawing.Point(3, 58);
            this.labelScrnName.Name = "labelScrnName";
            this.labelScrnName.Size = new System.Drawing.Size(159, 30);
            this.labelScrnName.TabIndex = 2;
            this.labelScrnName.Text = "屏体名称";
            this.labelScrnName.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // txtScrnName
            // 
            this.txtScrnName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtScrnName.Location = new System.Drawing.Point(3, 91);
            this.txtScrnName.Name = "txtScrnName";
            this.txtScrnName.Size = new System.Drawing.Size(159, 21);
            this.txtScrnName.TabIndex = 3;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.labelLtA, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtNumA, 1, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 205);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(159, 23);
            this.tableLayoutPanel1.TabIndex = 8;
            // 
            // labelLtA
            // 
            this.labelLtA.AutoSize = true;
            this.labelLtA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelLtA.Location = new System.Drawing.Point(3, 0);
            this.labelLtA.Name = "labelLtA";
            this.labelLtA.Size = new System.Drawing.Size(23, 23);
            this.labelLtA.TabIndex = 8;
            this.labelLtA.Text = "A级";
            this.labelLtA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtNumA
            // 
            this.txtNumA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumA.Location = new System.Drawing.Point(32, 3);
            this.txtNumA.Maximum = new decimal(new int[] {
            500,
            0,
            0,
            0});
            this.txtNumA.Name = "txtNumA";
            this.txtNumA.Size = new System.Drawing.Size(124, 21);
            this.txtNumA.TabIndex = 9;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.btnScrnEdit, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.btnScrnSet, 1, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 263);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 1;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(159, 257);
            this.tableLayoutPanel3.TabIndex = 10;
            // 
            // btnScrnEdit
            // 
            this.btnScrnEdit.Location = new System.Drawing.Point(3, 3);
            this.btnScrnEdit.Name = "btnScrnEdit";
            this.btnScrnEdit.Size = new System.Drawing.Size(73, 23);
            this.btnScrnEdit.TabIndex = 0;
            this.btnScrnEdit.Text = "修改";
            this.btnScrnEdit.UseVisualStyleBackColor = true;
            // 
            // btnScrnSet
            // 
            this.btnScrnSet.Location = new System.Drawing.Point(82, 3);
            this.btnScrnSet.Name = "btnScrnSet";
            this.btnScrnSet.Size = new System.Drawing.Size(74, 23);
            this.btnScrnSet.TabIndex = 1;
            this.btnScrnSet.Text = "下发";
            this.btnScrnSet.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 2;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Controls.Add(this.label3, 0, 0);
            this.tableLayoutPanel8.Controls.Add(this.label4, 1, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(3, 155);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 1;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(240, 14);
            this.tableLayoutPanel8.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(51, 1);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(17, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "起";
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(171, 1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(17, 12);
            this.label4.TabIndex = 1;
            this.label4.Text = "止";
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 2;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Controls.Add(this.numericUpDown2, 1, 0);
            this.tableLayoutPanel9.Controls.Add(this.numericUpDown1, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(3, 175);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 1;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel9.Size = new System.Drawing.Size(240, 24);
            this.tableLayoutPanel9.TabIndex = 7;
            // 
            // numericUpDown1
            // 
            this.numericUpDown1.Location = new System.Drawing.Point(3, 3);
            this.numericUpDown1.Name = "numericUpDown1";
            this.numericUpDown1.Size = new System.Drawing.Size(114, 21);
            this.numericUpDown1.TabIndex = 0;
            // 
            // numericUpDown2
            // 
            this.numericUpDown2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numericUpDown2.Location = new System.Drawing.Point(123, 3);
            this.numericUpDown2.Name = "numericUpDown2";
            this.numericUpDown2.Size = new System.Drawing.Size(114, 21);
            this.numericUpDown2.TabIndex = 1;
            // 
            // ScreenEditForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 730);
            this.Controls.Add(this.formTablePanel);
            this.Controls.Add(this.menuStrip);
            this.MainMenuStrip = this.menuStrip;
            this.MaximumSize = new System.Drawing.Size(1024, 768);
            this.MinimumSize = new System.Drawing.Size(1024, 768);
            this.Name = "ScreenEditForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "诱导屏控制系统";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.formTablePanel.ResumeLayout(false);
            this.groupScreenView.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            this.groupRoadSegmentEdit.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.groupBoxSgmtEdit.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLeft.ResumeLayout(false);
            this.tableLeftN.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.logoBox)).EndInit();
            this.groupScreenInfo.ResumeLayout(false);
            this.tableLayoutPanelScrnInfo.ResumeLayout(false);
            this.tableLayoutPanelScrnInfo.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumB)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtNumA)).EndInit();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDown2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileMnlst;
        private System.Windows.Forms.ToolStripMenuItem newMntm;
        private System.Windows.Forms.ToolStripMenuItem openMntm;
        private System.Windows.Forms.ToolStripMenuItem saveMntm;
        private System.Windows.Forms.ToolStripMenuItem exitMntm;
        private System.Windows.Forms.ToolStripMenuItem functionMnlst;
        private System.Windows.Forms.ToolStripMenuItem helpMnlst;
        private System.Windows.Forms.ToolStripMenuItem helpMntm;
        private System.Windows.Forms.ToolStripMenuItem aboutMntm;
        private System.Windows.Forms.TableLayoutPanel formTablePanel;
        private System.Windows.Forms.GroupBox groupScreenView;
        private System.Windows.Forms.GroupBox groupRoadSegmentEdit;
        private System.Windows.Forms.TableLayoutPanel tableLeft;
        private System.Windows.Forms.TableLayoutPanel tableLeftN;
        private System.Windows.Forms.PictureBox logoBox;
        private System.Windows.Forms.GroupBox groupScreenInfo;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelScrnInfo;
        private System.Windows.Forms.Button btnIpMacEdit;
        private System.Windows.Forms.Button btnScrnLthEdit;
        private System.Windows.Forms.Label labelScrnBckClr;
        private System.Windows.Forms.Label labelScrnName;
        private System.Windows.Forms.TextBox txtScrnName;
        private System.Windows.Forms.Label labelScrnLt;
        private System.Windows.Forms.ComboBox cmbScrnClr;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label labelLtB;
        private System.Windows.Forms.NumericUpDown txtNumB;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label labelLtA;
        private System.Windows.Forms.NumericUpDown txtNumA;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Button btnScrnEdit;
        private System.Windows.Forms.Button btnScrnSet;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel5;
        private System.Windows.Forms.ListView lstVwSgmt;
        private System.Windows.Forms.ColumnHeader sgmtID;
        private System.Windows.Forms.ColumnHeader rdName;
        private System.Windows.Forms.ColumnHeader start;
        private System.Windows.Forms.ColumnHeader end;
        private System.Windows.Forms.ColumnHeader clr;
        private System.Windows.Forms.GroupBox groupBoxSgmtEdit;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel6;
        private System.Windows.Forms.Button btnSet;
        private System.Windows.Forms.Button btnDefault;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel7;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelSgmtID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel9;
        private System.Windows.Forms.NumericUpDown numericUpDown1;
        private System.Windows.Forms.NumericUpDown numericUpDown2;
    }
}