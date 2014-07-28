using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ScreenManager.Service.util
{
    class IPAddrHandleUtil
    {
       public static bool isValid(String ipAddr)
        {
            Regex rx = new Regex(@"((?:(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d)))\.){3}(?:25[0-5]|2[0-4]\d|((1\d{2})|([1-9]?\d))))");
            if (rx.IsMatch(ipAddr)) 
            {
                return true;
            }
            return false;
        }
       public  static  List<String>  getIPListFromIPSegment(String startIP,String endIP)
        {
            List <String> ipList = new List <String>(); 
            long startIPValue = ipToLong(startIP);
            long endIPValue = ipToLong(endIP);

            for (long i = startIPValue; i <= endIPValue; i++)
            {

                String nowIPStr = longToIP(startIPValue + i);
                ipList.Add(nowIPStr);
            }
            return ipList;
        }

 
        static public  long ipToLong(String strIP)
        {
            long[] ip = new long[4];
            //先找到IP地址字符串中.的位置
            int position1 = strIP.IndexOf(".");
            int position2 = strIP.IndexOf(".", position1 + 1);
            int position3 = strIP.IndexOf(".", position2 + 1);
            //将每个.之间的字符串转换成整型
            ip[0] = Convert.ToInt32(strIP.Substring(0, position1));
            ip[1] = Convert.ToInt32(strIP.Substring(position1 + 1, position2));
            ip[2] = Convert.ToInt32(strIP.Substring(position2 + 1, position3));
            ip[3] = Convert.ToInt32(strIP.Substring(position3 + 1));
            return (ip[0] << 24) + (ip[1] << 16) + (ip[2] << 8) + ip[3];
        }

        //将10进制整数形式转换成127.0.0.1形式的IP地址
       static public  String longToIP(long longIP)
       {
           StringBuilder sb = new StringBuilder("");
         //直接右移24位
         sb.Append((longIP>>24).ToString());
         sb.Append(".");          
         //将高8位置0，然后右移16位
         sb.Append(((longIP & 0x00FFFFFF) > 16).ToString());
         sb.Append(".");
         sb.Append(((longIP & 0x0000FFFF) > 8).ToString());
         sb.Append(".");
         sb.Append((longIP & 0x000000FF).ToString());
         return sb.ToString(); 
    } 
    }
}
