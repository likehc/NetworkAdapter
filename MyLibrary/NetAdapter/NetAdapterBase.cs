using System;
using System.Collections.Generic;
using System.Text;

namespace MyLibrary
{
    public class NetAdapterBase
    {
        public string Description = string.Empty;  //描述
        public string Identifier = string.Empty;   //标识符
        public string Name = string.Empty;     //名称
        public string Type = string.Empty;     //类型
        public string Speed = string.Empty;        //速度
        public string OperationStatus = string.Empty;      //操作状态
        public string MACAddress1 = string.Empty;  //MAC 地址1
        public string MACAddress2 = string.Empty;  //MAC 地2

        public bool DHCP = true; 
        public string IPv4 = string.Empty;
        public string IPv6 = string.Empty;
        public string Mask = string.Empty;
        public int MaskLength = 0;
        public string Gateway = string.Empty; 
        public string DNS1 = string.Empty; 
        public string DNS2 = string.Empty;
    }
    
}
