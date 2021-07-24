using NUnit.Framework;
using System;
using static System.Math;
using FirstTests_on_CS;



namespace NUnitTestProject1
{

    public class Tests
    {

        private ForTests obj = new ForTests();
        private DateTime date_from_xml;//�������� ���� �����, ��������� �� xml-���
        private DateTime date_from_json;//�������� ���� �����, ��������� �� json
        private int channel_num;//���� ������� ����� �������, ��������� � xml-���
        [SetUp]
        public void Setup()
        {
            date_from_xml = obj.Server_Time_XML_format();
            date_from_json = obj.Server_Time_JSON_format();
            channel_num = obj.Number_of_Channels();
        }

        [Test]
        public void XML_Time_Is_NOT_Up_15s_returnTrue()//����1: XML, ����� � ������� ��������� ��������� ����� �� 15 �, ������� true, ���� �� ���������
        {
            var checkTime = new TimeSpan(0, 0, 15);
            var time_diff = date_from_xml - DateTime.Now;
            bool result = time_diff < checkTime;
            Assert.IsTrue(result);
        }

        [Test]
        public void JSON_Time_Is_NOT_Up_15s_returnTrue()//����2: JSON, ����� � ������� ��������� ��������� ����� �� 15 �, ������� true, ���� �� ���������
        {
            var checkTime = new TimeSpan(0, 0, 15);
            var time_diff = date_from_json - DateTime.Now;
            bool result = time_diff < checkTime;
            Assert.IsTrue(result);
        }

        [Test]
        public void Number_of_Channels_equal_or_up_to_6_returnTrue()//����3: ����� ������� ������ 6, ������� true, ���� ������ ��� ����� 6
        {
           
            bool result = channel_num>=6;
            Assert.IsTrue(result);
        }
        
    }

}