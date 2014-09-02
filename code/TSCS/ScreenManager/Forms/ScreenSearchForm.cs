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
        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        public ScreenManager.Forms.ScreenEditForm  sef;

        private String ipStart;
        private String ipEnd;
     
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
            this.ipStart = sysNode.Attributes["start"].Value;
            this.ipEnd = sysNode.Attributes["end"].Value;
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
            ScreenModel screenModel = screenList.getModelByIndex(item.Index);

            try
            {
                screenModel = ServiceContext.getInstance().getScreenControl().getScreenInfo(screenModel.BasicInfo.ScreenIP);

                //Test Stub
                // screenModel = ScreenManager.Stub.Stub.getScreenModelStub();
                //UpdateScreen
                sef.loadScreen(screenModel);
                sef.refreshScrn();
                sef.Show();
                this.Close();

            }
            catch (SystemException ex)
            {
                log.Error("get screen information failed", ex);
                screenModel = new ScreenModel();
                sef.loadScreen(screenModel);
                sef.refreshScrn();
                this.Cursor = Cursors.Arrow;
                MessageBox.Show("连接屏幕失败，请重新搜索屏幕！");
            }
            view.Items.Clear();
            this.Cursor = Cursors.Arrow;

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

            screenList = ServiceContext.getInstance().getScreenControl().searchByIP(this.ipStart, this.ipEnd, this.psBar);      
            if (screenList.List.Count == 0)
            {
                MessageBox.Show("没有搜索到屏幕");

            }
            this.btnSearchIP.Enabled = true;

            //Test
            //screenList.List = ScreenManager.Stub.Stub.getScreenStub();
            //
            //加载屏幕列表
            this.reloadIPList();
        }

        public void reloadIPList()
        {
            System.Windows.Forms.ListViewItem[] ItemList = new System.Windows.Forms.ListViewItem[screenList.List.Count];
            for (int i = 0; i < screenList.List.Count; i++)
            {

                ListViewItem screenItem = new ListViewItem();

                screenItem.Text = screenList.List[i].BasicInfo.ScreenName;


                System.Windows.Forms.ListViewItem.ListViewSubItem ipItem = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                ipItem.Text = screenList.List[i].ScreenIP;

                System.Windows.Forms.ListViewItem.ListViewSubItem roadItem = new System.Windows.Forms.ListViewItem.ListViewSubItem();
                roadItem.Text = screenList.List[i].getRoadNameString();

                screenItem.SubItems.Add(ipItem);
                screenItem.SubItems.Add(roadItem);
               
                ItemList[i] = screenItem;     
            }
            this.listViewScrn.Items.Clear();
            this.listViewScrn.Items.AddRange(ItemList);
        }


    }
}
