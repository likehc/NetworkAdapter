using Microsoft.Win32;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Deployment.Application;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net.NetworkInformation;
using System.Text;
using System.Windows.Forms;
using System.Xml;

namespace NetworkAdapter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        List<NetAdapterBase> NetAdapters;
        ManagementObjectCollection collections;
        NetAdapterBase adaObj = new NetAdapterBase();  //获取输入信息，防止设置时更新
        static string APP_PATH = System.IO.Directory.GetCurrentDirectory();
        static string XmlFileName = "config.XML";
        List<NetAdapterBase> adaList;
        private void Form1_Load(object sender, EventArgs e)
        {
            string xmlFullPath = APP_PATH + "\\" + XmlFileName;
            if (!File.Exists(@xmlFullPath))
            {
                OperateXML.initXML(xmlFullPath, adaObj);

            }
            initCmb_AdaEdit();
            combox_NetAdapters.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_AdaEdit.DropDownStyle = ComboBoxStyle.DropDownList;
            labIsDHCP.Text = string.Empty;
            GetAdaInfo();

           
        }
        /// <summary>
        /// 后台执行CMD命令
        /// </summary>
        /// <param name="command">cmd 命令</param>
        /// <returns></returns>
        public string ExecuteCMDWithOutput(string command)
        {
            ProcessStartInfo processInfo = new ProcessStartInfo("cmd.exe", "/S /C " + command)
            {
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden,
                RedirectStandardOutput = true
            };

            Process process = new Process { StartInfo = processInfo };
            process.Start();
            string outpup = process.StandardOutput.ReadToEnd();

            process.WaitForExit();
            return outpup;
        }
        public void InitAdaObj()
        {
            adaObj.Name = combox_NetAdapters.Text.Trim();
            adaObj.Description = getDesByName(adaObj.Name);
            adaObj.IPv4 = txtIP.Text.Trim();
            adaObj.Mask = txtMask.Text.Trim();
            adaObj.Gateway = txtGateway.Text.Trim();
            adaObj.DNS1 = txtDNS1.Text.Trim();
            adaObj.DNS2 = txtDNS2.Text.Trim();
        }
        public void SetElements(bool type = true)
        {
            if (type)
            {
                txtIP.Enabled = true;
                txtMask.Enabled = true;
                txtGateway.Enabled = true;
                txtDNS1.Enabled = true;
                txtDNS2.Enabled = true;
            }
            else
            {
                txtIP.Enabled = false;
                txtMask.Enabled = false;
                txtGateway.Enabled = false;
                txtDNS1.Enabled = false;
                txtDNS2.Enabled = false;
            }
        }
        public void GetCollections()
        {
            string manage = "SELECT * FROM Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
            collections = searcher.Get();
        }
        public void DisableCollectionByDes(string adaDes)
        {
            string manage = "SELECT * FROM Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
            collections = searcher.Get();
            foreach (ManagementObject obj in collections)
            {
                if (obj["Name"].ToString() == adaDes)
                {

                    //obj.InvokeMethod("RenewDHCPLease", null, null);
                    //obj.InvokeMethod("Auto", null);


                    obj.InvokeMethod("Disable", null);
                    //System.Threading.Thread.Sleep(3000);
                    //obj.InvokeMethod("Enable", null);
                    
                }
            }
        }
        public void EnableCollectionByDes(string adaDes)
        {
            string manage = "SELECT * FROM Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
            collections = searcher.Get();
            foreach (ManagementObject obj in collections)
            {
                if (obj["Name"].ToString() == adaDes)
                {
                    obj.InvokeMethod("Enable", null);
                }
            }
        }

        public void SwitchToDHCP()
        {
            string networcCardName = getDesByName(combox_NetAdapters.Text.Trim());
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                string Desc = (string)(mo["Description"]);

                if (Desc == networcCardName)
                {

                    //IpRelease(mo);
                    //mo.InvokeMethod("ReleaseDHCPLease", null, null);
                    var ndns = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    ndns["DNSServerSearchOrder"] = null;
                    var enableDhcp = mo.InvokeMethod("EnableDHCP", null, null);
                    var setDns = mo.InvokeMethod("SetDNSServerSearchOrder", ndns, null);


                    ///////
                    //inPar = mo.GetMethodParameters("EnableDHCP");

                    //outPar = mo.InvokeMethod("EnableDHCP", inPar, null);
                    //mo.InvokeMethod("EnableDHCP", null, null);
                    break;
                }

            }
        }

        /// <summary>
        /// Function:重新分配指定网卡的IP
        /// </summary>
        /// <param name="obj">ManagementObject obj --对应网卡的管理对象</param>
        /// <returns>返回值，整数，0和1表示成功</returns>
        public void IpRenew(ManagementObject obj)
        {
            ManagementBaseObject utPar = null;
            utPar = obj.InvokeMethod("RenewDHCPLease", null, null);
            //return Convert.ToInt32(outPar["returnValue"]);
        }
        /// <summary>
        /// Function:释放指定网卡IP
        /// </summary>
        /// <param name="obj">ManagementObject obj--对应网卡的管理对象</param>
        /// <returns>返回值，整数，0和1表示成功</returns>
        public void IpRelease(ManagementObject obj)
        {
            ManagementBaseObject utPar = null;
            utPar = obj.InvokeMethod("ReleaseDHCPLease", null, null);
            //return Convert.ToInt32(outPar["returnValue"]);
        }

        public bool CheckExist(string ip,ref string adaName)
        {
            bool result = false;
            MyLibrary.NetAdapter NetAdapterObj = new MyLibrary.NetAdapter();
            NetAdapters = NetAdapterObj.GetNetAdapter();
            if (NetAdapters.Count > 0)
            {
                foreach (var net in NetAdapters)
                {
                    string[] net1 = net.IPv4.Split('.');
                    string[] net2 = ip.Split('.');

                    if (net1[0] == net2[0] && net1[1] == net2[1] && net1[2] == net2[2])
                    {
                        result = true;
                        adaName = net.Name;
                        break;
                    }                    
                }
            }
            return result;
        }
        public void GetAdaInfo()
        {
            MyLibrary.NetAdapter NetAdapterObj = new MyLibrary.NetAdapter();
            NetAdapters = NetAdapterObj.GetNetAdapter();
            combox_NetAdapters.Items.Clear();
            if (NetAdapters.Count > 0)
            {
                foreach (var net in NetAdapters)
                {
                    if (net.OperationStatus.ToLower() != "up")  //如果网卡未连接,speed为 -1
                    {
                        continue;
                    }
                    combox_NetAdapters.Items.Add(net.Name);
                }
                combox_NetAdapters.SelectedIndex = 0;
            }
        }
        private void btn_SearchNetAdapters_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(combox_NetAdapters.Text))
            {
                GetAdaInfo();
            }
            else
            {
                UpdateInfo();
            }
            
        }

        public void UpdateInfo()
        {
            string adaName = combox_NetAdapters.Text;
            if (string.IsNullOrEmpty(adaName))
            {
                return;
            }

            MyLibrary.NetAdapter NetAdapterObj = new MyLibrary.NetAdapter();
            NetAdapters = NetAdapterObj.GetNetAdapter();
            if (NetAdapters.Count > 0)
            {
                foreach (var net in NetAdapters)
                {
                    if (net.Name == adaName)
                    {
                        txtIP.Text = net.IPv4;
                        txtMask.Text = net.Mask;
                        txtGateway.Text = net.Gateway;
                        txtDNS1.Text = net.DNS1;
                        txtDNS2.Text = net.DNS2;
                        txtIPv6.Text = net.IPv6;

                        lab_OperationStatus.Text = net.OperationStatus.ToUpper();
                        if (net.OperationStatus.ToUpper() == "UP")
                        {
                            lab_OperationStatus.ForeColor = Color.Green;
                        }
                        else
                        {
                            lab_OperationStatus.ForeColor = Color.Red;
                            txt_mac_speed.Text = string.Empty;
                        }
                        labMaskLength.Text = net.MaskLength.ToString();
                        
                        if (!string.IsNullOrEmpty(net.Speed))
                        {
                            txt_mac_speed.Text = net.MACAddress2;
                            lab_speed.Text =  net.Speed;
                        }
                        if (net.DHCP)
                        {
                            labIsDHCP.Text = "DHCP";
                        }
                        else
                        {
                            labIsDHCP.Text = "Static";
                        }

                        break;
                    }                    
                }
            }

            
            


            /* if (NetAdapters == null)
             {
                 return;
             }
             string adaName = combox_NetAdapters.Text;
             foreach (var net in NetAdapters)
             {
                 if (net.Name == adaName)
                 {
                     txtIP.Text = net.IPv4;
                     txtMask.Text = net.Mask;
                     txtGateway.Text = net.Gateway;
                     txtDNS1.Text = net.DNS1;
                     txtDNS2.Text = net.DNS2;
                     txtIPv6.Text = net.IPv6;
                     labMaskLength.Text = net.MaskLength.ToString();
                     lab_mac_speed.Text = net.MACAddress2;
                     if (!string.IsNullOrEmpty(net.Speed))
                     {
                         lab_mac_speed.Text = net.MACAddress2 + " -- " + net.Speed;
                     }
                     if (net.DHCP)
                     {
                         labIsDHCP.Text = "DHCP";
                     }
                     else
                     {
                         labIsDHCP.Text = "Static";
                     }


                     break;
                 }
             }*/
        }
        private void combox_NetAdapters_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateInfo();
        }

        public ManagementObject GetInstancesByDescription(string adaDescription)
        {
            ManagementObject result = null; ;
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();
            if (objMOC.Count>0)
            {
                foreach (ManagementObject item in objMOC)
                {
                    string DesString = (string)(item["Description"].ToString());
                    if (DesString.Trim() == adaDescription.Trim())
                    {
                        result = item;
                        break;
                    }
                }
            }

           
            return result;
        }


        private void EditIP(NetAdapterBase ada)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                string Desc = (string)(objMO["Description"]);
                this.Text = Desc;
                if (Desc == ada.Description)
                {
                    try
                    {
                        ManagementBaseObject setIP;
                        ManagementBaseObject newIP = objMO.GetMethodParameters("EnableStatic");


                       

                        //设置ip地址和子网掩码
                        newIP["IPAddress"] = new string[] { ada.IPv4 };
                        newIP["SubnetMask"] = new string[] { ada.Mask };
                        //newIP["DefaultIPGateway"] = new string[] { gateway };
                        //newIP["SetDNSServerSearchOrder"] = new string[] { dns1 };
                        setIP = objMO.InvokeMethod("EnableStatic", newIP, null);

                        //设置网关地址                        
                        newIP = objMO.GetMethodParameters("SetGateways");
                        
                        if (string.IsNullOrEmpty(ada.Gateway))
                        {
                            newIP["DefaultIPGateway"] = new string[] { "0.0.0.0" };
                        }
                        else
                        {
                            newIP["DefaultIPGateway"] = new string[] { ada.Gateway}; // 1.网关;2.备用网关
                        }

                        //newIP["GatewayCostMetric"] = new string[] { null, null }; // 1.网关;2.备用网关
                        
                        newIP = objMO.InvokeMethod("SetGateways", newIP, null);
                        objMO.Dispose();
                        objMO.InvokeMethod("SetGateways", new object[] {
                           new string[] { null },
                           new string[] { "1" }
                        });

                        object[] parm = new object[] { null, null };
                        objMO.InvokeMethod("SetGateways", parm);

                        //设置DNS
                        newIP = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        newIP["DNSServerSearchOrder"] = new string[] { ada.DNS1, ada.DNS2 }; // 1.DNS 2.备用DNS
                        newIP = objMO.InvokeMethod("SetDNSServerSearchOrder", newIP, null);
                       
                        break;

                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;
                }

            }
        }
        private string getDesByName(string name)
        {
            string result = string.Empty;
            if (NetAdapters != null)
            {
                foreach (var ada in NetAdapters)
                {
                    if (ada.Name == name)
                    {
                        result = ada.Description;
                    }
                }
            }


            return result;

        }
        private void btnAdaEdit_Click(object sender, EventArgs e)
        {
            InitAdaObj();
            if (adaObj.OperationStatus.ToLower() != "up")  //如果网卡未连接,speed为 -1
            {
                
            }
            string adaName =string.Empty ;
            bool has = CheckExist(txtIP.Text, ref adaName);
            if (has && adaName != combox_NetAdapters.Text.Trim())
            {
                DialogResult resault = MessageBox.Show($"{adaName}  -- 有相似IP, 是否继续", "注意", MessageBoxButtons.OKCancel);                
                if (resault == DialogResult.Cancel)
                {                    
                    return;
                }
            }
            SetIP();
        }


        public void setGateway(string gateway)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    ManagementBaseObject setGateway;
                    ManagementBaseObject newGateway =
                      objMO.GetMethodParameters("SetGateways");

                    newGateway["DefaultIPGateway"] = new string[] { gateway };
                    newGateway["GatewayCostMetric"] = new int[] { 1 };

                    setGateway = objMO.InvokeMethod("SetGateways", newGateway, null);
                }
            }
        }

        public void setDNS(string NIC, string DNS)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    // if you are using the System.Net.NetworkInformation.NetworkInterface
                    // you'll need to change this line to
                    // if (objMO["Caption"].ToString().Contains(NIC))
                    // and pass in the Description property instead of the name 
                    if (objMO["Caption"].Equals(NIC))
                    {
                        ManagementBaseObject newDNS =
                          objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        newDNS["DNSServerSearchOrder"] = DNS.Split(',');
                        ManagementBaseObject setDNS =
                          objMO.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                    }
                }
            }
        }

        public void setWINS(string NIC, string priWINS, string secWINS)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    if (objMO["Caption"].Equals(NIC))
                    {
                        ManagementBaseObject setWINS;
                        ManagementBaseObject wins =
                        objMO.GetMethodParameters("SetWINSServer");
                        wins.SetPropertyValue("WINSPrimaryServer", priWINS);
                        wins.SetPropertyValue("WINSSecondaryServer", secWINS);

                        setWINS = objMO.InvokeMethod("SetWINSServer", wins, null);
                    }
                }
            }
        }

        public static void SetNameservers(string nicDescription, string[] dnsServers)
        {
            using (var networkConfigMng = new ManagementClass("Win32_NetworkAdapterConfiguration"))
            {
                using (var networkConfigs = networkConfigMng.GetInstances())
                {
                    foreach (var managementObject in networkConfigs.Cast<ManagementObject>().Where(mo => (bool)mo["IPEnabled"] && (string)mo["Description"] == nicDescription))
                    {
                        using (var newDNS = managementObject.GetMethodParameters("SetDNSServerSearchOrder"))
                        {
                            newDNS["DNSServerSearchOrder"] = dnsServers;
                            managementObject.InvokeMethod("SetDNSServerSearchOrder", newDNS, null);
                        }
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            SetNameservers("192.168.7.230", new string[] { "8.8.8.8" });

        }
        public void setIP(string description, string ip_address, string subnet_mask)
        {
            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                if ((bool)objMO["IPEnabled"])
                {
                    string Desc = (string)(objMO["Description"]);
                    this.Text = Desc;
                    if (Desc != description)
                    {
                        continue;
                    }

                    try
                    {
                        ManagementBaseObject setIP;
                        ManagementBaseObject newIP =
                        objMO.GetMethodParameters("EnableStatic");

                        newIP["IPAddress"] = new string[] { ip_address };
                        newIP["SubnetMask"] = new string[] { subnet_mask };

                        setIP = objMO.InvokeMethod("EnableStatic", newIP, null);
                    }
                    catch (Exception)
                    {
                        throw;
                    }


                }
            }
        }
        public void initCmb_AdaEdit() 
        {
            adaList = OperateXML.GetXML(@APP_PATH + "\\" + XmlFileName, "");
            if (adaList != null)
            {
                for (int i = 0; i < adaList.Count; i++)
                {
                    cmb_AdaEdit.Items.Add(adaList[i].IPv4);
                }
                //cmb_AdaEdit.SelectedIndex = 0;

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //string s = System.IO.Directory.GetCurrentDirectory();
            //MessageBox.Show(APP_PATH+XmlFileName);

           

        }

        private void button3_Click(object sender, EventArgs e)
        {

            const string networcCardName = "VMware Virtual Ethernet Adapter for VMnet8"; //Example NIC name
            var management = new ManagementClass("Win32_NetworkAdapterConfiguration");
            var moc = management.GetInstances();

            foreach (var o in moc)
            {
                var mo = (ManagementObject)o;
                //if (!(bool)mo["IPEnabled"]) continue;
                if (!mo["Caption"].Equals(networcCardName)) continue;

            }
        }

        private void btn_OpenConn_Click(object sender, EventArgs e)
        {
            string result = ExecuteCMDWithOutput("ncpa.cpl");
        }



        private void button4_Click(object sender, EventArgs e)
        {
            NetAdapterBase ada = new NetAdapterBase();
            ada.Name = combox_NetAdapters.Text.Trim();
            ada.Description = getDesByName(ada.Name);
            ada.IPv4 = txtIP.Text.Trim();
            ada.Mask = txtMask.Text.Trim();
            ada.Gateway = txtGateway.Text.Trim();
            ada.DNS1 = txtDNS1.Text.Trim();
            ada.DNS2 = txtDNS2.Text.Trim();

            ManagementClass objMC = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection objMOC = objMC.GetInstances();

            foreach (ManagementObject objMO in objMOC)
            {
                string Desc = (string)(objMO["Description"]);
                this.Text = Desc;
                if (Desc == ada.Description)
                {
                    try
                    {
                        objMO.InvokeMethod("ReleaseDHCPLease", null);

                        objMO.InvokeMethod("RenewDHCPLease", null);
                        System.Threading.Thread.Sleep(3000);

                        ManagementBaseObject setIP;
                        ManagementBaseObject newIP = objMO.GetMethodParameters("EnableStatic");

                       

                        //设置ip地址和子网掩码
                        newIP["IPAddress"] = new string[] { ada.IPv4};
                        newIP["SubnetMask"] = new string[] { ada.Mask};
                        setIP = objMO.InvokeMethod("EnableStatic", newIP, null);

                        //设置网关地址
                        newIP = objMO.GetMethodParameters("SetGateways");
                        newIP["DefaultIPGateway"] = new string[] {"" }; // 1.网关;2.备用网关
                        newIP["GatewayCostMetric"] = new int[] { 2 };
                        newIP = objMO.InvokeMethod("SetGateways", newIP, null);

                        //设置DNS
                        newIP = objMO.GetMethodParameters("SetDNSServerSearchOrder");
                        newIP["DNSServerSearchOrder"] = new string[] { ada.DNS1, ada.DNS2 }; // 1.DNS 2.备用DNS
                        newIP = objMO.InvokeMethod("SetDNSServerSearchOrder", newIP, null);

                        objMO.Dispose();


                    }
                    catch (Exception)
                    {
                        throw;
                    }
                    break;
                }
            }
        }
        private void btn_StartDHCP_Click(object sender, EventArgs e)
        {
            InitAdaObj();
            SetDHCP();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            ManagementClass c = new ManagementClass("Win32_Process");
            ManagementClass mc;
            mc = new ManagementClass("Win32_NetworkAdapterConfiguration");//网卡信息

            //mc = new ManagementClass("Win32_Process");//查看系统进程信息

            ManagementObjectCollection moc = mc.GetInstances();

            foreach (ManagementObject o in moc)
                foreach (PropertyData prop in o.Properties)
                    txt_Info.Text += prop.Name + "---" + prop.Value + "\r\n";  //列出所有可以使用的属性名和值
        }

        static void SwitchToDHCP1()
        {
            ManagementBaseObject inPar = null;
            ManagementBaseObject outPar = null;
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                //if (!(bool)mo["IPEnabled "])
                //    continue;
                if ((string)mo["Description"] == "VMware Virtual Ethernet Adapter for VMnet8")
                {
                    mo.InvokeMethod("ReleaseDHCPLease", null, null);
                    var ndns = mo.GetMethodParameters("SetDNSServerSearchOrder");
                    ndns["DNSServerSearchOrder"] = null;
                    var enableDhcp = mo.InvokeMethod("EnableDHCP", null, null);
                    var setDns = mo.InvokeMethod("SetDNSServerSearchOrder", ndns, null);

                    //inPar = mo.GetMethodParameters("EnableDHCP");

                    //outPar = mo.InvokeMethod("EnableDHCP", inPar, null);
                
                    break;
                }
                
            }
        }
        /// <summary>
        /// 将IP，DNS设置为自动获取
        /// </summary>
        private void setIPDHCP()
        {
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((string)mo["Description"] == "VMware Virtual Ethernet Adapter for VMnet8")
                {
                    //if (!(bool)mo["IPEnabled"]) continue;
                    mo.InvokeMethod("SetDNSServerSearchOrder", null);
                    mo.InvokeMethod("EnableStatic", null);
                    mo.InvokeMethod("SetGateways", null);
                    mo.InvokeMethod("EnableDHCP", null);
                    //mo.InvokeMethod("ReleaseDHCPLease", null, null);
                    //mo.InvokeMethod("RenewDHCPLease", null, null);

                    break;
                }
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            string manage = "SELECT * FROM Win32_NetworkAdapter";
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(manage);
            ManagementObjectCollection collections = searcher.Get();
            List<string> netWorkList = new List<string>();

            //foreach (ManagementObject o in collection)
            //    foreach (PropertyData prop in o.Properties)
            //        textBox1.Text += prop.Name + "---" + prop.Value + "\r\n";

            foreach (ManagementObject obj in collections)
            {
                string s = obj["Name"].ToString();
                if (obj["Name"].ToString() == "VMware Virtual Ethernet Adapter for VMnet8")
                {
                    //obj.InvokeMethod("EnableDHCP", null, null);

                    //obj.InvokeMethod("RenewDHCPLease", null, null);
                    //obj.InvokeMethod("Auto", null);


                    //obj.InvokeMethod("Disable", null);
                    //System.Threading.Thread.Sleep(3000);
                    //obj.InvokeMethod("Enable", null);
                    //return;
                }
            }
        }

      

        private void timerUpdateInfo_Tick(object sender, EventArgs e)
        {
            if (txtIP.Focused || txtMask.Focused ||txtGateway.Focused || txtDNS1.Focused||txtDNS2.Focused)
            {
                return;
            }
            if (chkBox_UpdateInfo.Checked)
            {
                UpdateInfo();
            }
        }

        public void ClearDnsByName(string adaName)
        {
            string clearDNS = $"netsh interface ip del dns name= \"{adaName}\" all";
            ExecuteCMDWithOutput(clearDNS);
        }
        public void SetIP()
        {
            
            StringBuilder sbIP = new StringBuilder();
            //string setIP = $"netsh interface ip set address name=\"{adaObj.Name}\" source=static addr={adaObj.IPv4} mask={adaObj.Mask} gateway={adaObj.Gateway}";
            if (string.IsNullOrEmpty(adaObj.Name))
            {
                MessageBox.Show("未选择网卡","错误");
                return;
            }
            sbIP.Append($"netsh interface ip set address name=\"{adaObj.Name}\" source=static ");
            if (string.IsNullOrEmpty(adaObj.IPv4))
            {
                MessageBox.Show("未输入IP", "错误");
                return;
            }
            sbIP.Append($"addr={adaObj.IPv4} ");
            if (string.IsNullOrEmpty(adaObj.Mask))
            {
                MessageBox.Show("未输入子网掩码", "错误");
                return;
            }
            sbIP.Append($"mask={adaObj.Mask} ");

            if (!string.IsNullOrEmpty(adaObj.Gateway))
            {
                sbIP.Append($"gateway={adaObj.Gateway}");
            }

            string setIP = sbIP.ToString();
            ExecuteCMDWithOutput(setIP);

            ClearDnsByName(adaObj.Name);
            if (!string.IsNullOrEmpty(adaObj.DNS1))
            {
                string setDns1 = $"netsh interface ip add dnsservers name=\"{adaObj.Name}\" address={adaObj.DNS1} index=1";
                ExecuteCMDWithOutput(setDns1);
            }

            if (!string.IsNullOrEmpty(adaObj.DNS2))
            {
                string clearDNS = $"netsh interface ip del dns name= \"{adaObj.Name}\" ";
                ExecuteCMDWithOutput(clearDNS);
            }
            this.Text = adaObj.Name + "  修改完毕！ " + DateTime.Now.ToString("HH:mm:ss"); 

        }


        public void SetDHCP()
        {
            if (string.IsNullOrEmpty(adaObj.Name))
            {
                MessageBox.Show("未选择网卡", "错误");
                return;
            }
            ClearDnsByName(adaObj.Name);
            string setDHCP = $"netsh interface ip set address name = \"{adaObj.Name}\" source = dhcp";
            ExecuteCMDWithOutput(setDHCP);
            this.Text = adaObj.Name + "  修改完毕！ " + DateTime.Now.ToString("HH:mm:ss");
        }

        private void btn_SetMaskLength_Click(object sender, EventArgs e)
        {
            txtMask.Text = "255.255.255.0";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            InitAdaObj();
            XmlDocument doc = new XmlDocument();
            XmlDeclaration describe = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(describe);

            XmlElement setIP = doc.CreateElement("setIP");
            doc.AppendChild(setIP);

            XmlElement character1 = doc.CreateElement("Character");
            character1.SetAttribute("IPv4", adaObj.IPv4);
            character1.SetAttribute("Mask", adaObj.Mask);
            character1.SetAttribute("Gateway", adaObj.Gateway);
            character1.SetAttribute("DNS1", adaObj.DNS1);
            character1.SetAttribute("DNS2", adaObj.DNS2);
            setIP.AppendChild(character1);


            //doc.Save(@filePath);
            //doc.Save(@"W:\Attribute.xml");
            Console.WriteLine("写入成功!");
        }

        private void btn_SaveToxml_Click(object sender, EventArgs e)
        {
            InitAdaObj();
            bool isExist = MyLibrary.OperateXML.IsExist(@APP_PATH + "\\" + XmlFileName, adaObj);
            if (isExist)
            {
                MyLibrary.OperateXML.DelAttribute(@APP_PATH + "\\" + XmlFileName, adaObj);                ;
            }
            MyLibrary.OperateXML.Add_XML(@APP_PATH + "\\" + XmlFileName, adaObj);
        }

        private void cmb_AdaEdit_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (adaList != null)
            {
                for (int i = 0; i < adaList.Count; i++)
                {
                    if (adaList[i].IPv4 == cmb_AdaEdit.Text.Trim())
                    {
                        StringBuilder sb = new StringBuilder();
                        sb.AppendLine($"IPv4- {adaList[i].IPv4}");
                        sb.AppendLine($"Mask- {adaList[i].Mask}");
                        sb.AppendLine($"Gateway- {adaList[i].Gateway}");
                        sb.AppendLine($"DNS1- {adaList[i].DNS1}");
                        sb.AppendLine($"DNS2- {adaList[i].DNS2}");
                        txt_Info.Text = sb.ToString();
                        break;
                    }                    
                }
            }
            
              
           
        }

        private void btn_SetFromTxt_Click(object sender, EventArgs e)
        {
            chkBox_UpdateInfo.Checked = false;
            string[] strArr = txt_Info.Text.Split(Environment.NewLine.ToCharArray());
            if (strArr.Length>0)
            {
                txtIPv6.Text = string.Empty;
                for (int i = 0; i < strArr.Length; i++)
                {
                    //NetAdapterBase ada = new NetAdapterBase();
                    string[] temp = strArr[i].Split('-');
                    if (temp[0].Trim() == "IPv4")
                    {
                        txtIP.Text = temp[1].Trim();
                        //ada.IPv4 = temp[1].Trim();
                    }
                    if (temp[0].Trim() == "Mask")
                    {
                        txtMask.Text = temp[1].Trim();
                        //ada.Mask = temp[1].Trim();
                    }
                    if (temp[0].Trim() == "Gateway")
                    {
                        txtGateway.Text = temp[1].Trim();
                        //ada.Gateway = temp[1].Trim();
                    }
                    if (temp[0].Trim() == "DNS1")
                    {
                        txtDNS1.Text = temp[1].Trim();
                        //ada.DNS1 = temp[1].Trim();
                    }
                    if (temp[0].Trim() == "DNS2")
                    {
                        txtDNS2.Text = temp[1].Trim();
                        //ada.DNS2 = temp[1].Trim();
                    }
                }
                    
                
            }
            //string[] s txt_Info.Text.Split(new string[] { "\r\n" }, StringSplitOptions.None);
            //string[] s = txt_Info.Text.Split("\r\n");
        }
    }
}
