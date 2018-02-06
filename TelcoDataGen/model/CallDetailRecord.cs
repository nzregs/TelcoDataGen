using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelcoDataGen.model
{
    class CallDetailRecord
    {
        public string TowerId { get; set; }

        public string EventDate { get; set; }

        public string IMEI { get; set; }

        public string FromNumber { get; set; }

        public string ToNumber { get; set; }
  
        public string Type { get; set; }

        public int Duration { get; set; }

        public int Bytes { get; set; }

        public int Protocol { get; set; }

        public int Port { get; set; }

        public string Uri { get; set; }

        public decimal Cost { get; set; }
    }
}
