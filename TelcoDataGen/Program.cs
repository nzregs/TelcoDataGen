using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Microsoft.ServiceBus.Messaging;
using TelcoDataGen.secrets;
using TelcoDataGen.model;


namespace TelcoDataGen
{
    class Program
    {
        static EventHubClient hubClient;
        static Random random = new Random();
        static AppSecrets secrets = new AppSecrets();

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Simulated cell tower\n");
                
                hubClient = EventHubClient.CreateFromConnectionString(secrets.eventHubConnectionString, secrets.eventHubName);

                // Randomly create instances of the store actions, such as add view remove and checkout a product, 
                // convert it into a JSON string and sends to the IoT Hub.
                GenerateRandomEvents();
                Console.ReadLine();

            }
            catch (Exception e)
            {
                Console.WriteLine("Exception occured: " + e.ToString());

            }
            finally
            {
                Console.WriteLine("DataGen has stopped");
            }

            Console.ReadLine();
        }

        private static void GenerateRandomEvents()
        {
            // Load Sample Data Towers into list
            var towerList = SampleData_Towers.GetTowers().ToList();
            var towerWeight = new List<int>() { 2, 4, 2, 6, 10, 3, 3, 16, 4, 13, 3, 7, 7, 4, 6, 4, 4, 2 };

            // Load sample mobile numbers into list
            var numberList = new List<string>();            
            for (int i = 215550000; i <= 215559999; i++)
            {
                numberList.Add(i.ToString());
            }

            // Load sample websites into list
            var uriList = new List<string>() { "google.com", "bing.com", "facebook.com", "vodafone.net.nz", "nzherald.co.nz",
                                                "stuff.co.nz", "192.168.0.98", "microsoft.com", "hp.com", "lenovo.com", "dell.com",
                                                "acer.com", "whatsapp.com", "skype.com", "viber.com" };
            var uriListWeight = new List<int>() { 10, 11, 16, 8, 13, 8, 3, 5, 2, 2, 2, 3, 8, 7, 2 };

            // load call types into list
            var callTypes = new List<string>() { "call", "sms", "data" };
            var callTypeWeight = new List<int>() { 14, 32, 54 };

            // loop indefinately
            while (true)
            {
                // randomize data
                var randomTower = GetRandomEventNum(towerList.Count, towerWeight);
                var randomCallType = GetRandomEventNum(callTypes.Count, callTypeWeight);
                var randomNumber = numberList[random.Next(0, numberList.Count)];
                var randomUri = GetRandomEventNum(uriList.Count, uriListWeight);

                // construct call detail record
                var callDetailRecord = new CallDetailRecord();

                if (callTypes[randomCallType].Equals("call"))
                {
                    callDetailRecord = new CallDetailRecord
                    {
                        EventDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                        TowerId = towerList[randomTower].TowerId.ToString(),
                        FromNumber = randomNumber.ToString(),
                        ToNumber = randomNumber.ToString(),
                        Type = "call",
                        Duration = random.Next(1, 60),
                        IMEI = ""
                    };

                }
                else if (callTypes[randomCallType].Equals("sms"))
                {
                    callDetailRecord = new CallDetailRecord
                    {
                        EventDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                        TowerId = towerList[randomTower].TowerId.ToString(),
                        FromNumber = randomNumber.ToString(),
                        ToNumber = randomNumber.ToString(),
                        Type = "sms",
                        Duration = 0,
                        IMEI = ""
                    };
                }
                else
                {
                    callDetailRecord = new CallDetailRecord
                    {
                        EventDate = DateTime.UtcNow.ToString("yyyy-MM-ddTHH:mm:ssZ"),
                        TowerId = towerList[randomTower].TowerId.ToString(),
                        FromNumber = randomNumber.ToString(),
                        Type = "data",
                        Duration = 0,
                        Bytes = random.Next(1, 1024),
                        Protocol = 6,
                        Port = 80,
                        IMEI = "",
                        Uri = uriList[randomUri].ToString()
                    };
                }

                SendMessageToEventHub(callDetailRecord);
                TimeOfDayWait();

            }
        }

        private static async void SendMessageToEventHub(CallDetailRecord callDetailRecord)
        {
            // Serialize the Call Detail Record into JSON and send to event hub
            try
            {
                var messagestring = JsonConvert.SerializeObject(callDetailRecord, new JsonSerializerSettings() { ContractResolver = new CamelCasePropertyNamesContractResolver() });

                EventData data = new EventData(Encoding.UTF8.GetBytes(messagestring));
                hubClient.Send(data);

                Console.WriteLine("Sent message: {0} at time {1}.", messagestring.ToString(), DateTime.UtcNow.ToString("yyyyMMdd hh:mm:ss"));
            }
            catch (Exception exception)
            {
                Console.WriteLine(DateTime.Now.ToString() + " > Exception: " + exception.ToString());
            }
        }

        private static void TimeOfDayWait()
        {

            // simulate quiet/busy times of the day by sleeping the thread

            TimeZoneInfo userZone = TimeZoneInfo.FindSystemTimeZoneById("New Zealand Standard Time");

            int hour = TimeZoneInfo.ConvertTime(DateTime.UtcNow, userZone).Hour;

            if (hour >= 22 || hour <= 5)
            {
                Thread.Sleep(900);
            }
            else if (hour >= 6 && hour <= 8)
            {
                Thread.Sleep(400);
            }
            else if (hour >= 9 && hour <= 11)
            {
                Thread.Sleep(300);
            }
            else if (hour >= 12 && hour <= 14)
            {
                Thread.Sleep(200);
            }
            else if (hour >= 15 && hour <= 19)
            {
                Thread.Sleep(400);
            }
            else
            {
                Thread.Sleep(500);
            }

        }

        private static int GetRandomEventNum(int num_choices, List<int> choice_weight)
        {
            int sum_of_weight = 0;
            for (int i = 0; i < num_choices; i++)
            {
                sum_of_weight += choice_weight[i];
            }

            int rnd = random.Next(sum_of_weight);
            for (int i = 0; i < num_choices; i++)
            {
                if (rnd < choice_weight[i])
                    return i;
                rnd -= choice_weight[i];
            }

            return 1;
        }

    }
}
