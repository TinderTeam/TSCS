using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using ScreenManager.Forms;
using ScreenManager.Model;
using ScreenManager.Util;
using ScreenManager.Service;
namespace ScreenManager
{
    public partial class ScreenSearchForm : System.Windows.Forms.Form
    {


        public ScreenManager.Forms.ScreenEditForm  sef;
     
        //屏幕列表
        public ScreenListModel screenList ;

    
        public ScreenSearchForm(ScreenEditForm s)
        {
            sef = s;
            InitializeComponent();
            InitContent();
        }
    

     
        private void InitContent(){

            XmlDocument xml = new XmlDocument();


            xml.Load(SysConfig.getSystemPath()+"/config.xml");
            //指定一个节点
            XmlNode sysNode = xml.SelectSingleNode("/root/ip");
            this.txtIPStart.Text = sysNode.Attributes["start"].Value;
            this.txtIPEnd.Text = sysNode.Attributes["end"].Value;

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
            sef.loadScreen(screenModel);
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
            
            log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            log.Info("search button");
            this.btnSearchIP.Enabled = false;
            String IPstart = this.txtIPStart.Text;
            String IPend = this.txtIPEnd.Text;
            screenList = ServiceContext.getInstance().getScreenControl().searchByIP(IPstart, IPend,this.psBar);
            //ScreenManager.Service.ScreenDataService service = new ScreenManager.Service.ScreenDataService();
            if (screenList.List.Count == 0)
            {
                MessageBox.Show("没有搜索到屏幕");

            }
            this.btnSearchIP.Enabled = true;
            //搜索屏幕
            //screenList=service.searchByIP(IPstart, IPend);
            //加载屏幕列表
            this.reloadIPList();
        }
     

    }
}
