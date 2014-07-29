using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using ScreenManager.Form;
using ScreenManager.Model;
using ScreenManager.Service;
namespace ScreenManager
{
    public partial class MainForm : System.Windows.Forms.Form
    {


        public ScreenManager.Form.ScreenEditForm  sef;
     
        //屏幕列表
        public ScreenListModel screenList ;

    
        public MainForm(ScreenEditForm s)
        {
            sef = s;
            InitializeComponent();
        }
    

     
        /// <summary>
        /// 加载选中的屏幕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void selcetedScreen(object sender, MouseEventArgs e)
        {
            
            System.Windows.Forms.ListView view = (System.Windows.Forms.ListView)sender;
            System.Windows.Forms.ListViewItem item = view.SelectedItems[0];

            //Load Selected Screen


            ScreenModel screenModel = screenList.getModelByIndex(item.Text);
            //TODO

            screenModel = ServiceContext.getInstance().getScreenControl().getScreenInfo(screenModel.ScreenIP);
            
            //UpdateScreen
            sef.ScreenModel = screenModel;
            sef.refrashScrn();
            sef.Show();
            this.Close();


        }

        /// <summary>
        /// 搜索IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchIP(object sender, EventArgs e)
        {
            String IPstart = this.txtIPStart.Text;
            String IPend = this.txtIPEnd.Text;
            screenList = ServiceContext.getInstance().getScreenControl().searchByIP(IPstart, IPend);
            //ScreenManager.Service.ScreenDataService service = new ScreenManager.Service.ScreenDataService();

            //搜索屏幕
            //screenList=service.searchByIP(IPstart, IPend);
            //加载屏幕列表
            this.reloadIPList();
        }
     

    }
}
