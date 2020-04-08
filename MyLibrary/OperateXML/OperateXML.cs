using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;

namespace MyLibrary
{
    public class OperateXML
    {

        public static bool IsExistFile(string filePath)
        {
            bool result = false;


            return result;

        }
        public static void WriteXML(string filePath, string xmlStr)
        {            
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                sw.WriteLine(xmlStr);
            }
        }
        //查询多属性XML
        public static bool IsExist(string filePath, NetAdapterBase ada)
        {
            bool result = false;
            XmlDocument doc = new XmlDocument();
            doc.Load(@filePath);
            XmlNodeList xnl = doc.SelectNodes("/setIP/Character");
            foreach (XmlNode item in xnl)
            {
                if (item.Attributes["IPv4"].Value.Trim() == ada.IPv4 )
                {
                    result = true;
                    break;
                }
                //Console.WriteLine(item.Attributes["IP"].Value);
            }
            return result;
        }
        public static void Add_XML(string filePath, NetAdapterBase ada)
        {

            XmlDocument doc = new XmlDocument();
            if (File.Exists(@filePath))
            {
                doc.Load(filePath);
                XmlNode xmldocSelect = doc.SelectSingleNode("setIP");

                XmlElement character1 = doc.CreateElement("Character");
                character1.SetAttribute("IPv4", ada.IPv4);
                character1.SetAttribute("Mask", ada.Mask);
                character1.SetAttribute("Gateway", ada.Gateway);
                character1.SetAttribute("DNS1", ada.DNS1);
                character1.SetAttribute("DNS2", ada.DNS2);
                xmldocSelect.AppendChild(character1);               
                doc.Save(@filePath);  
            }
            else
            {
                Console.WriteLine("文件不存在!");
            }
        }
        public static void initXML(string filePath, NetAdapterBase ada)
        {
            XmlDocument doc = new XmlDocument();
            XmlDeclaration describe = doc.CreateXmlDeclaration("1.0", "utf-8", null);
            doc.AppendChild(describe);
            XmlElement setIP = doc.CreateElement("setIP");
            doc.AppendChild(setIP);
            doc.Save(@filePath);
        }
        public static List<NetAdapterBase> GetXML(string filePath, string xmlStr)
        {
            
            List<NetAdapterBase> adaList = new List<NetAdapterBase>();

            XmlDocument doc = new XmlDocument();
            doc.Load(@filePath);
            XmlNodeList xnl = doc.SelectNodes("/setIP/Character");
            foreach (XmlNode item in xnl)
            {
                NetAdapterBase ada = new NetAdapterBase();
                ada.IPv4 = item.Attributes["IPv4"].Value.Trim();
                ada.Mask = item.Attributes["Mask"].Value.Trim();
                ada.Gateway = item.Attributes["Gateway"].Value.Trim();
                ada.DNS1 = item.Attributes["DNS1"].Value.Trim();
                ada.DNS2 = item.Attributes["DNS2"].Value.Trim();
                //if (item.Attributes["IP"].Value.Trim() == ada.IPv4)
                //{
                //    result = true;
                //    break;
                //}
                //Console.WriteLine(item.Attributes["IP"].Value);
                adaList.Add(ada);
            }
            return adaList;
        }
        public static void DelAttribute(string filePath, NetAdapterBase ada)
        {
            XElement xl = XDocument.Load(@filePath).Root;
            xl.Elements("Character").Where(el => el.Attribute("IPv4").Value.Equals(ada.IPv4)).Remove();
            xl.Save(@filePath);
            //Console.WriteLine("修改成功!");
        }
        public static void EditXML(string filePath, string xmlStr)
        {
            XElement doc = XElement.Load(@filePath);
            XElement heroes = (from p in doc.Elements() where p.Attribute("Name").Value == "超人" select p).FirstOrDefault();
            if (heroes != null)
            {
                heroes.Attribute("Age").Value = "99";
                doc.Save(@filePath);
                //Console.WriteLine("修改成功!");
            }
        }
    }
   

}
   


