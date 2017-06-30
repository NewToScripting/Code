using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Inspire.Settings.DataContracts;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ServiceTester.ServiceReference1;

namespace ServiceTester
{
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void TestMethod1()
        {
            Setting setting = new Setting();
            setting.Key = "test2";
            setting.Value = "testval";
            ServiceTester.ServiceReference1.SettingServiceContractClient client = new SettingServiceContractClient();
            client.AddSetting(setting);
            setting = client.GetSetting("test2");
            client.DeleteSetting("test2");
        }
    }
}
