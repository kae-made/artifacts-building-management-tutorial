// ------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン: 0.1.1
//  
//     このファイルの各メソッドにユーザーの実装を加えてください。
//     ファイルを削除しなければ、コードが再生成される事はありません。
// </auto-generated>
// ------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;

namespace BuildingManagement.Gen.MeasurementInstrumentsDevice
{
    partial class IoTApp : IIoTApp
    {
        public AppDTDesiredProperties DesiredProperties { get; set; }
        public AppDTReporetedProperties ReportedProperties { get; set; }

        public string Start(string payload)
        {
            string result = "";
            Console.WriteLine($"Invoked 'Start' with '{payload}'");
            // TODO: implement direct method logic 
            return result;
        }


        public string Stop(string payload)
        {
            string result = "";
            Console.WriteLine($"Invoked 'Stop' with '{payload}'");
            // TODO: implement direct method logic 
            return result;
        }




        public async Task ReceivedC2DDataAsync(Message message)
        {
            Console.WriteLine($"Received C2D - {System.Text.Encoding.UTF8.GetString(message.GetBytes())}");
            if (message.Properties.Count > 0)
            {
                Console.WriteLine("  properties...");
                foreach (var prop in message.Properties)
                {
                    Console.WriteLine($"  {prop.Key}:{prop.Value}");
                }
            }
            // TODO: implment logic when message is received from clou
        }

        public async Task UpdatedDTDesiredPropertiesAsync(AppDTDesiredProperties dp)
        {
            Console.WriteLine($"Updated DT Desired Props - {DesiredProperties.Serialize()}");
            // TODO: implment reconfiguration logic with updated desired properties
        }

        public async Task UserPreInitializeAsync()
        {
            // TODO: impliment initialization logic before connecting to IoT Hub
        }

        public async Task UserPostInitializeAsync()
        {
            // TODO: implement initialization logic after connected to IoT Hub
        }

        public async Task UserPreTerminateAsync()
        {
            // TODO: implement termination logic before disconnecting from IoT Hub
        }

        public async Task UserPostTerminateAsync()
        {
            // TODO: implement termination logic after disconnected from IoT Hub
        }

        public async Task DoWorkAsync()
        {
            // Sample Logic
            ReportedProperties.DeviceStatus = "ready";
            ReportedProperties.CurrentInterval = 10000;
            await iotClient.UpdateDeviceTwinsReportedPropertiesAsync(ReportedProperties);
            var task = new Task(async () =>
            {
                var rand = new Random(DateTime.Now.Millisecond);
                var updatingInterval = TimeSpan.FromMilliseconds(1000);
                while (true)
                {
                    // Samples
                    lock (sensingData)
                    {
                        // implement sensing data update logic
                        sensingData.Environment.Temperature = 27;
                        sensingData.Environment.Humidity = 57.4;
                        sensingData.Environment.AtmosphericPressure = 1003.1;
                        sensingData.Environment.CO2Concentration = 300;
                        sensingData.Environment.Brightness = 739.2;
                        sensingData.Environment.MeasuredTime = DateTime.Now;
                    }
                    await iotClient.UpdateD2CDataAsync(sensingData);
                    await Task.Delay(updatingInterval);
                }
            });
            task.Start();
            iotClient.StartSendD2CMessageAsync(TimeSpan.FromSeconds(10));

            var key = Console.ReadKey();
            iotClient.StopSendD2CMessage();
        }
    }
}
