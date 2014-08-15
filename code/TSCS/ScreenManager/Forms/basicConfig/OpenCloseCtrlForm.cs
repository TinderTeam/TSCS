using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ScreenManager.Service;
using ScreenManager.Util;
using ScreenManager.Forms;
using ScreenManager.Model;
namespace ScreenManager.Forms.basicConfig
{
    public partial class OpenCloseCtrlForm : Form
    {
        ScreenModel screenModel;
        bool change = false;
        public OpenCloseCtrlForm(ScreenModel sm)
        {
            screenModel = sm;
            InitializeComponent();
        }
        bool open;

        private void OpenCloseCtrlForm_Load(object sender, EventArgs e)
        {
            //Get Screen Status
            int result = screenModel.BasicInfo.ScreenStatus;
    
            if (result == ScreenManager.Model.Constant.Constants.SCREEN_OPEN_VALUE)
            {
                open = true;
                this.rdbOpen.Checked = true;
                this.rdbClose.Checked = false;
            }
            else
            {
                open = false;
                this.rdbOpen.Checked = false;
                this.rdbClose.Checked = true;
            }

            change = true;
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
                        MessageBox.Show("操作成功");
                        this.screenModel.BasicInfo.ScreenStatus = ScreenManager.Model.Constant.Constants.SCREEN_OPEN_VALUE;
                    }
                    else
                    {
                     
                        change = false;
                        MessageBox.Show("操作失败");
                        this.rdbClose.Checked = true;
                        change = true;
                    }

                }
                else if (this.rdbClose.Checked == true)
                {
                    bool result = ServiceContext.getInstance().getScreenControl().closeScreen();
                    if (result)
                    {
                        MessageBox.Show("操作成功");
                        this.screenModel.BasicInfo.ScreenStatus = ScreenManager.Model.Constant.Constants.SCREEN_CLOSE_VALUE;
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
