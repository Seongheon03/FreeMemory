using Newtonsoft.Json;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace FreeMemory.Model
{
    public class Schedule : BindableBase
    {
        private string _name;
        [JsonProperty("name")]
        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private DateTime _startTime;
        [JsonProperty("startDate")]
        public DateTime StartTime
        {
            get => _startTime;
            set => SetProperty(ref _startTime, value);
        }

        private DateTime _endTime;
        [JsonProperty("endDate")]
        public DateTime EndTime
        {
            get => _endTime;
            set => SetProperty(ref _endTime, value);
        }

        private int _target;
        [JsonProperty("target")]
        public int Target
        {

            get => _target;
            set => SetProperty(ref _target, value);
        }

        private int _type;
        [JsonProperty("type")]
        public int Type
        {
            get => _type;
            set => SetProperty(ref _type, value);
        }
    }
}
