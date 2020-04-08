using System;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using System.Text;

namespace MyLibrary
{

    public class NetAdapter : NetAdapterBase
    {

        public List<NetAdapterBase> GetNetAdapter()
        {

            NetworkInterface[] adapters = NetworkInterface.GetAllNetworkInterfaces();//获取本地计算机上网络接口的对象
            //Console.WriteLine("适配器个数：" + adapters.Length);
            //Console.WriteLine();
            List<NetAdapterBase> NetAdapterList = new List<NetAdapterBase>();
            foreach (NetworkInterface adapter in adapters)
            {
                NetAdapterBase ada = new NetAdapterBase();
                ada.Description = adapter.Description;
                ada.Identifier = adapter.Id;
                ada.Name = adapter.Name;
                ada.Type = adapter.NetworkInterfaceType.ToString();
                ada.OperationStatus = adapter.OperationalStatus.ToString();
                if (ada.OperationStatus.ToLower() == "up")  //如果网卡未连接,speed为 -1
                {
                    ada.Speed = Math.Ceiling(adapter.Speed * 0.001 * 0.001) + "M";
                }


                // 格式化显示MAC地址                
                PhysicalAddress pa = adapter.GetPhysicalAddress();//获取适配器的媒体访问（MAC）地址

                byte[] bytes = pa.GetAddressBytes();//返回当前实例的地址
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    sb.Append(bytes[i].ToString("X2"));//以十六进制格式化
                    if (i != bytes.Length - 1)
                    {
                        sb.Append("-");
                        
                    }
                    ada.MACAddress1 = pa.ToString();
                    ada.MACAddress2 = sb.ToString();
                }

                IPInterfaceProperties ip = adapter.GetIPProperties();     //IP配置信息
                if (ip.DhcpServerAddresses.Count == 0)
                {
                    ada.DHCP = false;
                }
                    

                if (ip.UnicastAddresses.Count >0)
                {
                    for (int i = 0; i < ip.UnicastAddresses.Count; i++)
                    {
                        string ipStr = ip.UnicastAddresses[i].Address.ToString();  //IP地址
                        if (ipStr.Contains(":"))
                        {
                            ada.IPv6 = ipStr;
                        }
                        else
                        {
                            ada.IPv4 = ipStr;
                            ada.Mask = ip.UnicastAddresses[i].IPv4Mask.ToString(); //子网掩码
                            ada.MaskLength = ip.UnicastAddresses[i].PrefixLength;
                        }
                    }                    
                }
              
             

                if (ip.GatewayAddresses.Count > 0)
                {
                    ada.Gateway = ip.GatewayAddresses[0].Address.ToString();  //默认网关
                }
                if (ip.DnsAddresses.Count > 0)
                {
                    for (int i = 0; i < ip.DnsAddresses.Count; i++)
                    {
                        string dnsStr = ip.DnsAddresses[i].ToString();
                        if (!dnsStr.Contains(":"))
                        {
                            if (ada.DNS1 == string.Empty)
                            {
                                ada.DNS1 = dnsStr;
                                continue;
                            }
                            if (ada.DNS2 == string.Empty)
                            {
                                ada.DNS2 = dnsStr;
                                continue;

                            }
                        }
                    }
                            
                }


                NetAdapterList.Add(ada);


            }
            return NetAdapterList;
        }

        public void SetNetAdapter(NetAdapterBase NetAdapter)
        {

        }
    }
}
