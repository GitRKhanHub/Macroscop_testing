using System;
using System.Net;
using System.IO;
using System.Xml;
using System.Text.Json;

namespace FirstTests_on_CS
{
    class ForTests
    {
        public static DateTime Server_Time_XML_format()
        {
            
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://demo.macroscop.com:8080/command?type=gettime&login=root&password=");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();



            DateTime date = new DateTime();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.


                // Read the content.
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                string xml_file = "C:\\Users\\User\\Documents\\File\\example.xml";
                //убираем всё, что не является xml-элементами
                responseFromServer = responseFromServer.Remove(0, responseFromServer.IndexOf("<"));
                //пишем полученное в xml-документ
                File.WriteAllText(xml_file, responseFromServer);
                //загружаем xml-док
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(xml_file);
                
                XmlElement xRoot = xDoc.DocumentElement;
                //находим элемент, содержащий время
                XmlNode node = xRoot.SelectSingleNode("//string");

                date = Convert.ToDateTime(node.InnerText);

                //Console.WriteLine(date);
                //Console.WriteLine(DateTime.Now);
                //Console.WriteLine(date - DateTime.Now);

                
            }
            response.Close();


            return date;
        }

        public static DateTime Server_Time_JSON_format()
        {

           
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://demo.macroscop.com:8080/command?type=gettime&login=root&password=&responsetype=json");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            DateTime date = new DateTime();
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.


                // Read the content.
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                //убираем всё, что не json-объект
                responseFromServer = responseFromServer.Remove(0, responseFromServer.IndexOf("\""));
                //убираем кавычки
                responseFromServer = responseFromServer.Replace("\"", "");
                date = Convert.ToDateTime(responseFromServer);

                //Console.WriteLine(date);
                //Console.WriteLine(DateTime.Now);
                //Console.WriteLine(date - DateTime.Now);
            }

            response.Close();

            return date;
        }

        public static int Number_of_Channels()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://demo.macroscop.com:8080/configex?login=root&password=");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();


            int flag = 0;
            using (Stream dataStream = response.GetResponseStream())
            {
                // Open the stream using a StreamReader for easy access.


                // Read the content.
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();

                string xml_file = "C:\\Users\\User\\Documents\\File\\example2.xml";
                //удаляем всё, что не xml-элемент
                responseFromServer = responseFromServer.Remove(0, responseFromServer.IndexOf("<"));
                //пишем в xml-файл
                File.WriteAllText(xml_file, responseFromServer);
                //загружаем xml-док
                XmlDocument xDoc = new XmlDocument();
                xDoc.Load(xml_file);

                XmlElement xRoot = xDoc.DocumentElement;
                //находим все элементы-каналы
                XmlNodeList nodes = xRoot.SelectNodes("//Channels/ChannelInfo");
                //считаем число каналов
                foreach (XmlNode n in nodes)
                    flag++;


                //Console.WriteLine(flag);
            }
            response.Close();

            return flag;
        }
        static void Main(string[] args)
        {

            




        }
    }
}
