using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SampleDataWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            // write tower data to .JSON file
            var towerList = TelcoDataGen.SampleData_Towers.GetTowers().ToList();
            var towerData = "";

            foreach (var tower in towerList)
            {
                var messagestring = JsonConvert.SerializeObject(tower, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                towerData += messagestring + "\n";
            }     
            System.IO.File.WriteAllText(@".\towerData.json", towerData.Substring(0, towerData.Length - 1));

            // write subscriber data to .JSON file
            var subscriberList = TelcoDataGen.SampleData_Subscribers.GetSubscribers().ToList();
            var subscriberData = "";

            foreach (var subscriber in subscriberList)
            {
                var messagestring = JsonConvert.SerializeObject(subscriber, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                subscriberData += messagestring + "\n";
            }
            System.IO.File.WriteAllText(@".\subscriberData.json", subscriberData.Substring(0, subscriberData.Length - 1));

            // write specials data to .JSON file
            var dataSpecialList = TelcoDataGen.SampleData_DataSpecials.GetDataSpecials().ToList();
            var dataSpecialData = "";

            foreach (var dataSpecial in dataSpecialList)
            {
                var messagestring = JsonConvert.SerializeObject(dataSpecial, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });
                dataSpecialData += messagestring + "\n";
            }
            System.IO.File.WriteAllText(@".\dataSpecialData.json", dataSpecialData.Substring(0, dataSpecialData.Length - 1));
        }
    }
}
