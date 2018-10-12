using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace coreAPISample.Models
{
    public class TokenRequest
    {
        [Required(AllowEmptyStrings =false,ErrorMessage ="username is required")]
        public string client_id { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "password is required")]
        public string client_secret { get; set; }


        [Required(AllowEmptyStrings = false, ErrorMessage = "audience is required")]
        public string audience { get; set; }

        public override string ToString()
        {
            return this.client_id + ":" + this.audience;
        }
    }
}
