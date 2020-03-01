using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MD2.DataContext;
using MD2.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;



namespace MD2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SensorController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public SensorController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpPost("Sensor")]
        public async Task<IActionResult> TriggerSens([FromForm]SensorModel sensorModel)
        {
            try
            {
                var sensIn = new SensorIn()
                {
                    Detected = sensorModel.detect_id,
                    InsertTime = DateTime.Now,
                    DeviceIP = sensorModel.device_ip,
                    DeviceMac = sensorModel.device_mac,
                    Location = sensorModel.loc
                };

                _context.SensorInput.Add(sensIn);
                await _context.SaveChangesAsync();

                return Ok(sensIn);
            }
            catch (Exception e)
            {
                return BadRequest(e);
            }
        }

        public class SensorModel
        {
            public string detect_id { get; set; }
            public string device_ip { get; set; }
            public string device_mac { get; set; }
            public string loc { get; set; }
        }

    }
}