using NUnit.Framework;
using System;
using static System.Math;
using FirstTests_on_CS;



namespace NUnitTestProject1
{

    public class Tests
    {

        private ForTests obj = new ForTests();
        private DateTime date_from_xml;//сохраним сюда врем€, считанное из xml-док
        private DateTime date_from_json;//сохраним сюда врем€, считанное из json
        private int channel_num;//сюда считаем число каналов, описанных в xml-док
        [SetUp]
        public void Setup()
        {
            date_from_xml = obj.Server_Time_XML_format();
            date_from_json = obj.Server_Time_JSON_format();
            channel_num = obj.Number_of_Channels();
        }

        [Test]
        public void XML_Time_Is_NOT_Up_15s_returnTrue()//тест1: XML, врем€ с сервера ѕ–≈¬џЎј≈“ локальное врем€ на 15 с, вернуть true, если не превышает
        {
            var checkTime = new TimeSpan(0, 0, 15);
            var time_diff = date_from_xml - DateTime.Now;
            bool result = time_diff < checkTime;
            Assert.IsTrue(result);
        }

        [Test]
        public void JSON_Time_Is_NOT_Up_15s_returnTrue()//тест2: JSON, врем€ с сервера ѕ–≈¬џЎј≈“ локальное врем€ на 15 с, вернуть true, если не превышает
        {
            var checkTime = new TimeSpan(0, 0, 15);
            var time_diff = date_from_json - DateTime.Now;
            bool result = time_diff < checkTime;
            Assert.IsTrue(result);
        }

        [Test]
        public void Number_of_Channels_equal_or_up_to_6_returnTrue()//тест3: число каналов меньше 6, вернуть true, если больше или равно 6
        {
           
            bool result = channel_num>=6;
            Assert.IsTrue(result);
        }
        
    }

}