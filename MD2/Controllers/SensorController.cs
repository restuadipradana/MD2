using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MD2.DataContext;
using MD2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MQTTnet;
using MQTTnet.Client;
using MQTTnet.Client.Options;

namespace MD2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public string stat;
        public SensorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Sensor")]
        public async Task<IActionResult> TriggerSens([FromForm]SensorModel sensorModel)
        {
            try
            {
                
                String mac = sensorModel.device_mac;
                var loc = _context.DeviceLocaton.Where(x => x.DeviceMac == mac).Select(x => x.Location).FirstOrDefault();
                var sensIn = new SensorIn()
                {
                    Detected = sensorModel.detect_id,
                    InsertTime = DateTime.Now,
                    DeviceIP = sensorModel.device_ip,
                    DeviceMac = sensorModel.device_mac,
                    Location = loc,
                    DeviceInsertDate = sensorModel.date_only,
                    DeviceInsertTime = sensorModel.date_time
                };
                _context.SensorInput.Add(sensIn);
                await _context.SaveChangesAsync();
                //SendMQTT();
                return Ok(sensIn);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }


        private async void SendMQTT()
        {
            //documentation about mqtt asp .net core at here https://github.com/chkr1011/MQTTnet/wiki/Client#client-options
            try
            {
                var factory = new MqttFactory();
                var mqttClient = factory.CreateMqttClient();

                var options = new MqttClientOptionsBuilder()
                    .WithTcpServer("localhost", 1883)
                    .Build();

                await mqttClient.ConnectAsync(options, CancellationToken.None);

                var message = new MqttApplicationMessageBuilder()
                    .WithTopic("mqttmessenger/bob/messagedump")
                    .WithPayload(stat)
                    .WithExactlyOnceQoS()
                    .WithRetainFlag()
                    .Build();

                await mqttClient.PublishAsync(message);
            }
            catch 
            {

            }
            
        }

        public class SensorModel
        {
            public string detect_id { get; set; }
            public string device_ip { get; set; }
            public string device_mac { get; set; }
            public DateTime date_time { get; set; }
            public DateTime date_only { get; set; }

            //device_ip=172.16.3.80&device_mac=24:0A:C4:30:E8:90&detect_id=2&date_time=2020/3/9 18:1:40&date_only=2020/3/9
        }

    }
}