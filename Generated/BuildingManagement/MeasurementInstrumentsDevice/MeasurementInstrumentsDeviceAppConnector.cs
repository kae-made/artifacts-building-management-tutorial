// ------------------------------------------------------------------------------
// <auto-generated>
//     このコードはツールによって生成されました。
//     ランタイム バージョン: 0.1.1
//  
//     このファイルへの変更は、正しくない動作の原因になる可能性があり、
//     コードが再生成されると失われます。
// </auto-generated>
// ------------------------------------------------------------------------------

using Kae.IoT.Framework;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuildingManagement.Gen.MeasurementInstrumentsDevice
{
    class MeasurementInstrumentsDeviceAppConnector : Kae.IoT.Framework.IoTAppConnector
    { 
        private IIoTApp iotApp;

        public MeasurementInstrumentsDeviceAppConnector(IoTAppConfig appConfig, IIoTApp app) : base(appConfig)
        {
            iotApp = app;
        }
        public override async Task<(byte[] result, int statusCode)> InvokeDirectMethodAsync(MethodRequest methodRequest)
        {
            byte[] result = null;
            int statusCode = (int)System.Net.HttpStatusCode.OK;
            try
            {
                switch (methodRequest.Name)
                {
                            case "Start":
                        result = System.Text.Encoding.UTF8.GetBytes(iotApp.Start(methodRequest.DataAsJson));
                        break;
                            case "Stop":
                        result = System.Text.Encoding.UTF8.GetBytes(iotApp.Stop(methodRequest.DataAsJson));
                        break;
                                    default:
                        statusCode = (int)System.Net.HttpStatusCode.BadRequest;
                        break;
                }
            }
            catch (Exception ex)
            {
                result = System.Text.Encoding.UTF8.GetBytes(ex.Message);
                statusCode = (int)System.Net.HttpStatusCode.InternalServerError;
            }
            return (result, statusCode);

        }

        public override async Task NotifyC2DMessageAsync(Message msg)
        {
            await iotApp.ReceivedC2DDataAsync(msg);
        }

        public override async Task NotifyDeviceTwinsDesiredPropertiesAsync(TwinCollection dp)
        {
            iotApp.DesiredProperties.Deserialize(dp.ToJson());
            await iotApp.UpdatedDTDesiredPropertiesAsync(iotApp.DesiredProperties);
        }

        public override TwinCollection ResolveDeviceTwinsReportedProperties(IoTData appRP)
        {
            TwinCollection rp = new TwinCollection(appRP.Serialize());
            return rp;
        }

        public override IoTDataWithProperties GetAppD2CData()
        {
            return iotApp.GetD2CData();
        }

        public override Task NotifyE2DMessageAsync(Message msg, string inputPort)
        {
            throw new NotImplementedException();
        }
    }
}