using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace ScreenManager.Service
{
 
    public class PingThread
    {
        private static  int port = 6000;
        private static int timeout = 500; // Timeout 


        private static log4net.ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        private static int count = 0;
        private static List<String> succussList = new List<String>();
        object objLock = new object();
        public PingThread()
        {
             
        }

        public List<String>  PingWorker(List<String> ipList,ProgressBar bar)
        {

            count = 0;
            succussList.Clear();

            PingThread thread = new PingThread();

            for (int i = 0; i < ipList.Count; i++)
            {
               
                Thread td = new Thread(new ParameterizedThreadStart(thread.ping));   //需要引入System.Threading命名空间
 
                td.Start(ipList[i]);
            }

            log.Info("the sum ip address is " + ipList.Count);
            while (true)
            {

                if (count == ipList.Count)
                {
                    log.Info("connect finish.");
                    break;
                }
                bar.Value = 100 * count / ipList.Count;
                Thread.Sleep(100);
            }

            log.Info("connect success ip count is " + succussList.Count);
            for (int i = 0; i < succussList.Count; i++)
            {
                log.Info("success ip is "+succussList[i]);
            }

            return succussList;
 

        
        }
        public  void ping(object obj)
        {
            bool result = false;

            String ipAddr = (String)obj;
            log.Info("start a new thread to connect " + ipAddr);
            try
            {
                PingOptions pOption = new PingOptions();
                pOption.DontFragment = true;
                Ping p = new Ping();

                PingReply reply = p.Send(ipAddr,timeout);
                if (reply.Status == IPStatus.Success)
                {

                    //TcpClient tcp = new TcpClient();
                    //tcp.Connect(ipAddr, port);
                    bool socket = connectSocket(ipAddr);
                    //if (tcp.Connected)
                    if (socket)
                    {
                        result = true;
                    }
                    else
                    {
                        log.Error("the ip address can not connect success. the ip address is :" + ipAddr);
                    }
                }
                else
                {
                    log.Error("the ip address can not ping success. the ip address is :" + ipAddr);

                }



             
            }
            catch (Exception ex)
            {

                log.Error("the ip address can not connect success. the ip address is :" + ipAddr);
            }
            

            lock (objLock)
            {
                log.Info("count ++ " + result);
                if (result)
                {

                    succussList.Add(ipAddr);
                }

                count++;
            }
        
         
            log.Info("thread finish of connect " + ipAddr);
            log.Info("now finish count is " + count);

        }

        public bool connectSocket(String ipAddr)
        {
            bool result = false;
            IPAddress ip = IPAddress.Parse(ipAddr);  
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                clientSocket.Connect(new IPEndPoint(ip, port)); //配置服务器IP与端口  
                result = true;
            }
            catch
            {
                log.Error("connect socket failed");
            }
            return result;
        }
    }
}
