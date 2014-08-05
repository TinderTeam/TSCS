using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ScreenManager.Model;

using System.ComponentModel;
using System.Data;
using System.Xml.Serialization;
using System.Xml;
using System.Drawing;

using System.IO;

using System.Windows.Forms;

using ScreenManager.Model.UI;
using ScreenManager.Service;
using ScreenManager.Util;
using ScreenManager.Forms;

namespace ScreenManager.Dao
{
    public class RoadDao
    {

        public bool saveAsFile(List<RoadModel> roadModel)
        {
            SaveFileDialog fileDialog = new SaveFileDialog();

            fileDialog.InitialDirectory = "C://";

            fileDialog.Filter = "TrafficScreen files(*.ts)|*.ts|所有文件(*.*)|*.*";

            fileDialog.FilterIndex = 1;

            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {

                XmlSerializer serializer = new XmlSerializer(typeof(List<RoadModel>));
                Stream writer = new FileStream(fileDialog.FileName, FileMode.Create);
                // Serialize the object, and close the TextWriter
                serializer.Serialize(writer, roadModel);
                return true;
            }
            else
            {
                return false;
            }
          
        }

        public List<RoadModel> loadByFile()
        {
            OpenFileDialog fileDialog = new OpenFileDialog();

            fileDialog.InitialDirectory = "C://";

            fileDialog.Filter = "TrafficScreen files(*.ts)|*.ts|所有文件(*.*)|*.*";

            fileDialog.FilterIndex = 1;

            fileDialog.RestoreDirectory = true;

            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                XmlSerializer formatter = new XmlSerializer(typeof(List<RoadModel>));
                System.Console.WriteLine(fileDialog.FileName);
                StreamReader sr = new StreamReader(fileDialog.FileName);
                List<RoadModel> s = (List<RoadModel>)formatter.Deserialize(sr);
                sr.Close();

                return s;
            }
            else
            {
                return null;
            }
        }
    }
}
