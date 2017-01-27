using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Net;
using ScrapLib;
using Newtonsoft.Json;
using System.Diagnostics;
namespace ScrapLibTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestInitialize]
        public void PrepTest()
        {
            if (!File.Exists("input.htm"))
            {
                byte[] result = new WebClient().DownloadData("http://www.Ikea.com/us/en");
                File.OpenWrite("input.htm").Write(result, 0, result.Length);
            }
        }
        [TestMethod]
        public void Extract_Title_From_Page_Should_Return_Json()
        {
            Scrapper s = new Scrapper();
            var conf = @"{ 'title': '//div[contains(@class,\'productTitle\')]' }";
            string htmlString = File.ReadAllText("input.htm");
           var result = s.ExtractDataFromHtmlStringAndConfString(htmlString,conf);
           Assert.IsNotNull(result);
             Assert.AreEqual("MOSTORP", result["title"]);

        }
    }
}
