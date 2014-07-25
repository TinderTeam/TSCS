﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ScreenManager.Model.UI
{
    public partial class ComboListView : ListView
    {

        public ComboListView()
        {
　　　　　　// This call is required by the Windows.Forms Form Designer.
　　　　　　InitializeComponent();
　　
　　　　　　// TODO: Add any initialization after the InitForm call
　　　　}
　　
　　　　
　　　　#region Component Designer generated code
　　　　/// <summary>
　　　　/// Required method for Designer support - do not modify
　　　　/// the contents of this method with the code editor.
　　　　/// </summary>
　　　　private void InitializeComponent()
　　　　{
　　　　　　components = new System.ComponentModel.Container();
　　　　}
　　　　#endregion
　　
　　　　private const int WM_HSCROLL = 0x114;
　　　　private const int WM_VSCROLL = 0x115;
　　
　　　　protected override void WndProc(ref Message msg)
　　　　{
　　　　　　// Look for the WM_VSCROLL or the WM_HSCROLL messages.
　　　　　　if ((msg.Msg == WM_VSCROLL) || (msg.Msg == WM_HSCROLL))
　　　　　　{
　　　　　　　　// Move focus to the ListView to cause ComboBox to lose focus.
　　　　　　　　this.Focus();
　　　　　　}
　　
　　　　　　// Pass message to default handler.
　　　　　　base.WndProc(ref msg);
　　　　}
　　}
}