using Newtonsoft.Json.Linq;
using OpenScraping;
using OpenScraping.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScrapLib
{
    public class Scrapper
    {
        public JContainer ExtractDataFromHtmlStringAndConfString(string htmlString, string conf)
        {
            var openScraping = new StructuredDataExtractor(
                StructuredDataConfig.ParseJsonString(conf)
                );
            return openScraping.Extract(htmlString);
        }
    }
}
