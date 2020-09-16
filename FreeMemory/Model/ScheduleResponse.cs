using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreeMemory.Model
{
    class ScheduleResponse
    {
        [JsonProperty("schedules")]
        public List<Schedule> schedules { get; set; }
    }
}
