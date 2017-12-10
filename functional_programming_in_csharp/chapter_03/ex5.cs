using System;
using System.Collections.Generic;
using System.Linq;
using LaYumba.Functional;
using System.Configuration;
using System.Collections.Specialized;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static LaYumba.Functional.F;

//Write implementations for the methods in the following AppConfig class. (For
//both methods, a reasonable one-line method body is possible. Assume the set-
//tings are of type string, numeric, or date.) Can this implementation help you to
//test code that relies on settings in a .config file?

namespace chapter03
{
[TestClass]
    public class AppConfig_Test
    {
        private AppConfig _appConfig;
        [TestInitialize]
        public void Setup()
        {
            var nvc = new NameValueCollection();
            nvc.Add("hello", "goodby");
            nvc.Add("functional", "programming");
            nvc.Add("number", "1000");
            _appConfig = new AppConfig(nvc);
        }

        [TestMethod]
        public void NoSetting_None()
        {
            Assert.AreEqual(None, _appConfig.Get<DateTime>("Snow"));
        }

        [TestMethod]
        public void NoSetting_Default()
        {
            string defaultValue = "Is falling";
            Assert.AreEqual(defaultValue, _appConfig.Get<string>("Snow", defaultValue));
        }

        public void HasSetting()
        {
            int number = _appConfig.Get<int>("number").Match(
                                () => throw new ArgumentException(),
                                (num) => num);
            Assert.AreEqual(1000, number);
        }
    }

    public class AppConfig
    {
        NameValueCollection source;
       
        public AppConfig(NameValueCollection source)
        {
            this.source = source;
        }
        public Option<T> Get<T>(string name)
            =>
                source[name] != null
                ? Some<T>((T)Convert.ChangeType(source.Get(name), typeof(T)))
                : None;
        
        public T Get<T>(string name, T defaultValue)
            =>
              Get<T>(name).Match(
                    () => defaultValue,
                    (value) => value);
        
    }
}