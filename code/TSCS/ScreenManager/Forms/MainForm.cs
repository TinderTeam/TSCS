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
    public partial class MainForm : System.Windows.Forms.Form
    {


        public ScreenForm sf;
        //屏幕列表
        public ScreenListModel screenList ;

        public MainForm(ScreenForm s)
        {
            sf = s;
            InitializeComponent();
        }

     

    

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
          
        }
        /// <summary>
        /// 加载选中的屏幕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            
            System.Windows.Forms.ListView view = (System.Windows.Forms.ListView)sender;
            System.Windows.Forms.ListViewItem item = view.SelectedItems[0];

            //Load Selected Screen


            ScreenModel screenModel = screenList.getModelByIndex(item.Text);
            //UpdateScreen
            sf.loadScreen(screenModel);
            sf.Show();
            this.Close();
        }

        /// <summary>
        /// 搜索IP
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchIP(object sender, EventArgs e)
        {
            String IPstart = this.textBox1.Text;
            String IPend = this.textBox2.Text;
            ScreenManager.Service.ScreenDataService service = new ScreenManager.Service.ScreenDataService();

            //搜索屏幕
            screenList=service.searchByIP(IPstart, IPend);
            //加载屏幕列表
            this.reloadIPList();
        }
     

    }
}
