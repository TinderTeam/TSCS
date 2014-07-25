using ScreenManager.Model;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ScreenManager.Form
{
    partial class EditRoadForm
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
         
            this.upDownContainer = new System.Windows.Forms.SplitContainer();
            this.splitContainerPaint = new System.Windows.Forms.SplitContainer();
            this.segNameText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.barContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.paintPanel = new System.Windows.Forms.Panel();
            this.start = new System.Windows.Forms.NumericUpDown();
            this.end = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.colorBox = new System.Windows.Forms.ComboBox();
            this.RLContainer = new System.Windows.Forms.SplitContainer();
            this.segmentListView = new System.Windows.Forms.ListView();
            this.segmentID = new System.Windows.Forms.ColumnHeader();
            this.segmentName = new System.Windows.Forms.ColumnHeader();
            this.segmentColor = new System.Windows.Forms.ColumnHeader();
            this.segmentStart = new System.Windows.Forms.ColumnHeader();
            this.segmentEnd = new System.Windows.Forms.ColumnHeader();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.addSeg = new System.Windows.Forms.Button();
            this.deleteSeg = new System.Windows.Forms.Button();
            this.submitSeg = new System.Windows.Forms.Button();
            this.cancelSeg = new System.Windows.Forms.Button();
            this.upDownContainer.Panel1.SuspendLayout();
            this.upDownContainer.Panel2.SuspendLayout();
            this.upDownContainer.SuspendLayout();
            this.splitContainerPaint.Panel1.SuspendLayout();
            this.splitContainerPaint.Panel2.SuspendLayout();
            this.splitContainerPaint.SuspendLayout();
            this.barContainer.Panel1.SuspendLayout();
            this.barContainer.Panel2.SuspendLayout();
            this.barContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.start)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.end)).BeginInit();
            this.RLContainer.Panel1.SuspendLayout();
            this.RLContainer.Panel2.SuspendLayout();
            this.RLContainer.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // upDownContainer
            // 
            this.upDownContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.upDownContainer.Location = new System.Drawing.Point(0, 0);
            this.upDownContainer.Name = "upDownContainer";
            this.upDownContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // upDownContainer.Panel1
            // 
            this.upDownContainer.Panel1.Controls.Add(this.splitContainerPaint);
            // 
            // upDownContainer.Panel2
            // 
            this.upDownContainer.Panel2.Controls.Add(this.RLContainer);
            this.upDownContainer.Size = new System.Drawing.Size(784, 264);
            this.upDownContainer.SplitterDistance = 99;
            this.upDownContainer.TabIndex = 0;
            // 
            // splitContainerPaint
            // 
            this.splitContainerPaint.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerPaint.Location = new System.Drawing.Point(0, 0);
            this.splitContainerPaint.Name = "splitContainerPaint";
            this.splitContainerPaint.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerPaint.Panel1
            // 
            this.splitContainerPaint.Panel1.Controls.Add(this.segNameText);
            this.splitContainerPaint.Panel1.Controls.Add(this.label1);
            // 
            // splitContainerPaint.Panel2
            // 
            this.splitContainerPaint.Panel2.Controls.Add(this.barContainer);
            this.splitContainerPaint.Size = new System.Drawing.Size(784, 99);
            this.splitContainerPaint.SplitterDistance = 29;
            this.splitContainerPaint.TabIndex = 0;
            // 
            // segNameText
            // 
            this.segNameText.Enabled = false;
            this.segNameText.Location = new System.Drawing.Point(84, 4);
            this.segNameText.Name = "segNameText";
            this.segNameText.Size = new System.Drawing.Size(140, 21);
            this.segNameText.TabIndex = 1;
            this.segNameText.TextChanged += new System.EventHandler(this.segNameText_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选中的路段：";
            // 
            // barContainer
            // 
            this.barContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.barContainer.Location = new System.Drawing.Point(0, 0);
            this.barContainer.Name = "barContainer";
            // 
            // barContainer.Panel1
            // 
            this.barContainer.Panel1.Controls.Add(this.tableLayoutPanel1);
            this.barContainer.Panel1.Padding = new System.Windows.Forms.Padding(50, 20, 50, 20);
            // 
            // barContainer.Panel2
            // 
            this.barContainer.Panel2.Controls.Add(this.colorBox);
            this.barContainer.Panel2.Controls.Add(this.label2);
            this.barContainer.Size = new System.Drawing.Size(784, 66);
            this.barContainer.SplitterDistance = 650;
            this.barContainer.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Controls.Add(this.paintPanel, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.start, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.end, 2, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(50, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 106F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(550, 26);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // paintPanel
            // 
            this.paintPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.paintPanel.Location = new System.Drawing.Point(53, 3);
            this.paintPanel.Name = "paintPanel";
            this.paintPanel.Size = new System.Drawing.Size(444, 20);
            this.paintPanel.TabIndex = 2;
            this.paintPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.paintPanel_Paint);
            this.paintPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseMove_1);
            this.paintPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseDown_1);
            this.paintPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.paintPanel_MouseUp_1);
            // 
            // start
            // 
            this.start.Enabled = false;
            this.start.Location = new System.Drawing.Point(3, 3);
            this.start.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(44, 21);
            this.start.TabIndex = 3;
            this.start.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // end
            // 
            this.end.Enabled = false;
            this.end.Location = new System.Drawing.Point(503, 3);
            this.end.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.end.Name = "end";
            this.end.Size = new System.Drawing.Size(44, 21);
            this.end.TabIndex = 4;
            this.end.ValueChanged += new System.EventHandler(this.ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "路段颜色：";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // colorBox
            // 
            this.colorBox.Enabled = false;
            this.colorBox.FormattingEnabled = true;
            this.colorBox.Items.AddRange(ScreenManager.Model.Constant.Constants.colorArray);
            this.colorBox.Location = new System.Drawing.Point(61, 28);
            this.colorBox.Name = "colorBox";
            this.colorBox.Size = new System.Drawing.Size(57, 20);
            this.colorBox.TabIndex = 0;
            this.colorBox.SelectedValueChanged += new System.EventHandler(this.colorBox_SelectedValueChanged);
            // 
            // RLContainer
            // 
            this.RLContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RLContainer.Location = new System.Drawing.Point(0, 0);
            this.RLContainer.Name = "RLContainer";
            // 
            // RLContainer.Panel1
            // 
            this.RLContainer.Panel1.Controls.Add(this.segmentListView);
            // 
            // RLContainer.Panel2
            // 
            this.RLContainer.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.RLContainer.Size = new System.Drawing.Size(784, 161);
            this.RLContainer.SplitterDistance = 650;
            this.RLContainer.TabIndex = 0;
            // 
            // segmentListView
            // 
   



            this.segmentListView.Activation = System.Windows.Forms.ItemActivation.OneClick;
            this.segmentListView.AllowColumnReorder = true;
            this.segmentListView.AllowDrop = true;
            this.segmentListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.segmentID,
            this.segmentName,
            this.segmentColor,
            this.segmentStart,
            this.segmentEnd});
            this.segmentListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.segmentListView.FullRowSelect = true;
            this.segmentListView.GridLines = true;
            this.segmentListView.HideSelection = false;


            loadSegmentListView();



            this.segmentListView.Location = new System.Drawing.Point(0, 0);
            this.segmentListView.Name = "segmentListView";
            this.segmentListView.Size = new System.Drawing.Size(650, 161);
            this.segmentListView.TabIndex = 0;
            this.segmentListView.UseCompatibleStateImageBehavior = false;
            this.segmentListView.View = System.Windows.Forms.View.Details;
            this.segmentListView.Click += new System.EventHandler(this.segmentListView_Click);
            // 
            // segmentID
            // 
            this.segmentID.Text = "序号";
            // 
            // segmentName
            // 
            this.segmentName.Text = "路段名称";
            this.segmentName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.segmentName.Width = 150;
            // 
            // segmentColor
            // 
            this.segmentColor.Text = "路段颜色";
            this.segmentColor.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.segmentColor.Width = 150;
            // 
            // segmentStart
            // 
            this.segmentStart.Text = "起始值";
            this.segmentStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.segmentStart.Width = 100;
            // 
            // segmentEnd
            // 
            this.segmentEnd.Text = "终止值";
            this.segmentEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.segmentEnd.Width = 100;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.addSeg, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.deleteSeg, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.submitSeg, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.cancelSeg, 0, 3);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 4;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(130, 161);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // addSeg
            // 
            this.addSeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addSeg.Location = new System.Drawing.Point(20, 5);
            this.addSeg.Margin = new System.Windows.Forms.Padding(20, 5, 20, 5);
            this.addSeg.Name = "addSeg";
            this.addSeg.Size = new System.Drawing.Size(90, 30);
            this.addSeg.TabIndex = 0;
            this.addSeg.Text = "增加";
            this.addSeg.UseVisualStyleBackColor = true;
            this.addSeg.Click += new System.EventHandler(this.addSeg_Click);
            // 
            // deleteSeg
            // 
            this.deleteSeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.deleteSeg.Enabled = false;
            this.deleteSeg.Location = new System.Drawing.Point(20, 43);
            this.deleteSeg.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.deleteSeg.Name = "deleteSeg";
            this.deleteSeg.Size = new System.Drawing.Size(90, 34);
            this.deleteSeg.TabIndex = 1;
            this.deleteSeg.Text = "删除";
            this.deleteSeg.UseVisualStyleBackColor = true;
            this.deleteSeg.Click += new System.EventHandler(this.deleteSeg_Click);
            // 
            // submitSeg
            // 
            this.submitSeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.submitSeg.Location = new System.Drawing.Point(20, 83);
            this.submitSeg.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.submitSeg.Name = "submitSeg";
            this.submitSeg.Size = new System.Drawing.Size(90, 34);
            this.submitSeg.TabIndex = 2;
            this.submitSeg.Text = "提交";
            this.submitSeg.UseVisualStyleBackColor = true;
            this.submitSeg.Click += new System.EventHandler(this.submitSeg_Click);
            // 
            // cancelSeg
            // 
            this.cancelSeg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelSeg.Location = new System.Drawing.Point(20, 123);
            this.cancelSeg.Margin = new System.Windows.Forms.Padding(20, 3, 20, 3);
            this.cancelSeg.Name = "cancelSeg";
            this.cancelSeg.Size = new System.Drawing.Size(90, 35);
            this.cancelSeg.TabIndex = 3;
            this.cancelSeg.Text = "取消";
            this.cancelSeg.UseVisualStyleBackColor = true;
            this.cancelSeg.Click += new System.EventHandler(this.cancelSeg_Click);
            // 
            // EditRoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 264);
            this.Controls.Add(this.upDownContainer);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximumSize = new System.Drawing.Size(800, 300);
            this.MinimumSize = new System.Drawing.Size(800, 300);
            this.Name = "EditRoadForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.upDownContainer.Panel1.ResumeLayout(false);
            this.upDownContainer.Panel2.ResumeLayout(false);
            this.upDownContainer.ResumeLayout(false);
            this.splitContainerPaint.Panel1.ResumeLayout(false);
            this.splitContainerPaint.Panel1.PerformLayout();
            this.splitContainerPaint.Panel2.ResumeLayout(false);
            this.splitContainerPaint.ResumeLayout(false);
            this.barContainer.Panel1.ResumeLayout(false);
            this.barContainer.Panel2.ResumeLayout(false);
            this.barContainer.Panel2.PerformLayout();
            this.barContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.start)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.end)).EndInit();
            this.RLContainer.Panel1.ResumeLayout(false);
            this.RLContainer.Panel2.ResumeLayout(false);
            this.RLContainer.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        private void loadSegmentListView()
        {
            List<ListViewItem> list = new List<ListViewItem>();


            for(int i=0;i<editedRoadModel.SegmentList.Count;i++){
                SegmentModel a =editedRoadModel.SegmentList[i];
                System.Windows.Forms.ListViewItem listViewItem = new System.Windows.Forms.ListViewItem(new string[] {
                i.ToString(),
                a.SegmentName,
                a.SegmentColor,
                a.Address.Start.ToString(),
                a.Address.End.ToString()}, -1);
                list.Add(listViewItem);
            }

            System.Windows.Forms.ListViewItem[] itemList= list.ToArray();
            this.segmentListView.Items.Clear();
            this.segmentListView.Items.AddRange(itemList);
        }

        #endregion

        private System.Windows.Forms.SplitContainer upDownContainer;
        private System.Windows.Forms.SplitContainer RLContainer;
        private System.Windows.Forms.ListView segmentListView;
        private System.Windows.Forms.ColumnHeader segmentID;
        private System.Windows.Forms.ColumnHeader segmentName;
        private System.Windows.Forms.ColumnHeader segmentColor;
        private System.Windows.Forms.ColumnHeader segmentStart;
        private System.Windows.Forms.ColumnHeader segmentEnd;
        private System.Windows.Forms.SplitContainer splitContainerPaint;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SplitContainer barContainer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox colorBox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel paintPanel;
        private System.Windows.Forms.NumericUpDown start;
        private System.Windows.Forms.NumericUpDown end;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button addSeg;
        private System.Windows.Forms.Button deleteSeg;
        private System.Windows.Forms.Button submitSeg;
        private System.Windows.Forms.Button cancelSeg;
        private System.Windows.Forms.TextBox segNameText;

   
    }
}