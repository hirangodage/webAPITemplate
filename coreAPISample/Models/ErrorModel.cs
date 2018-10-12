using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace coreAPISample.Models
{
    public class ErrorModel
    {
        public string ErrorCode { get; set; }
       
        public string ErrorMessage { get; set; }
        public int StatusCode { get; internal set; }

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
