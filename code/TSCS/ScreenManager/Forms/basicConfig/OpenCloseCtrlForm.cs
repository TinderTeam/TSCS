﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenManager.Service;
using ScreenManager.Util;
using System.Windows.Forms;
using ScreenManager.Model;
namespace ScreenManager.Forms.basicConfig
{
    public partial class OpenCloseCtrlForm : Form
    {
        ScreenModel screenModel;
        bool change = true;
        public OpenCloseCtrlForm(ScreenModel sm)
        {
            screenModel = sm;
            InitializeComponent();
        }
        bool open;

        private void OpenCloseCtrlForm_Load(object sender, EventArgs e)
        {
            //Get Screen Status
            bool result = ServiceContext.getInstance().getScreenControl().getScreenOpenStatus();
            open = result;
            if (result)
            {
                this.rdbOpen.Checked = true;
                this.rdbClose.Checked = false;
            }
            else
            {
                this.rdbOpen.Checked = false;
                this.rdbClose.Checked = true;
            }
            this.rdbClose.CheckedChanged += new System.EventHandler(this.rdbClose_CheckedChanged);

        }




        private void rdbClose_CheckedChanged(object sender, EventArgs e)
        {
            if (change)
            {
                if (this.rdbOpen.Checked == true)
                {
                    bool result = ServiceContext.getInstance().getScreenControl().openScreen();
                    if (result)
                    {
                        this.screenModel.BasicInfo.ScreenStatus = 0;
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                        change = false;
                        this.rdbClose.Checked = true;
                        change = true;
                    }

                }
                else if (this.rdbClose.Checked == true)
                {
                    bool result = ServiceContext.getInstance().getScreenControl().closeScreen();
                    if (result)
                    {
                        this.screenModel.BasicInfo.ScreenStatus = 1;
                    }
                    else
                    {
                        MessageBox.Show("操作失败");
                        change = false ;
                        this.rdbOpen.Checked = true;
                        change = true;
                    }
                }
            }         
           
       
        }
    }
}
