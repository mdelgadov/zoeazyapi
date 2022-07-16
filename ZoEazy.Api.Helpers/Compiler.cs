using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ZoEazy.Api.Model;
using System.IO;
using System.Text.RegularExpressions;
using Newtonsoft.Json.Serialization;
using ZoEazy.Api.Model.Branch;

namespace ZoEazy.Api.Helpers
{
    public class Compiler
    {
        private Branch Branch { get; set; }
        private List<Country> Countries { get; set; }
        private List<CreditCardBrand> CcBrands { get; set; }
        private Currency Currency { get; set; }

        public Compiler(Branch br, List<Country> ctries, List<CreditCardBrand> brands, Currency curr)
        {
            Branch = br;
            Countries = ctries;
            CcBrands = brands;
            Currency = curr;
        }

        public void Execute(string filePath = null, string source = null, string compiled = null)
        {

            var setting = new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            };


            if (filePath == null)
                filePath = "C:\\Users\\Miguel\\Documents\\Visual Studio 2015\\Projects\\ZoEazy\\ZoEazy.SPA\\wwwroot\\app\\factories\\";
            //filePath = "C:\\Users\\Miguel\\Source\\Repos\\ZoEazy\\ZoEazy.SPA\\wwwroot\\app\\factories\\";

            if (source == null)
                source = "template.txt";

            if (compiled == null)
                compiled = "data.ts";


            var br = JsonConvert.SerializeObject(Branch, Formatting.Indented, setting);
            var cr = JsonConvert.SerializeObject(Countries, Formatting.Indented, setting);
            var brs = JsonConvert.SerializeObject(CcBrands, Formatting.Indented, setting);
            var cy = JsonConvert.SerializeObject(Currency, Formatting.Indented, setting);



            var content = string.Empty;
            using (StreamReader reader = File.OpenText(filePath + source))
            {
                content = reader.ReadToEnd();
            }

            var tmplt = content.Replace("{branch}", br.Replace("'", "+++'").Replace("+++", "\\").Replace('"', '\''))
                .Replace("{countries}", cr.Replace("'", "+++'").Replace("+++", "\\").Replace('"', '\''))
                .Replace("{brands}", brs.Replace("'", "+++'").Replace("+++", "\\").Replace('"', '\''))
                .Replace("{currency}", cy.Replace("'", "+++'").Replace("+++", "\\").Replace('"', '\''));

            var file = File.Create(filePath + compiled);
            //var logWriter = new System.IO.StreamWriter(logFile);
            using (StreamWriter writer = new StreamWriter(file))
            {
                writer.Write(tmplt);
                writer.Dispose();
            }

        }

    }
    
}
