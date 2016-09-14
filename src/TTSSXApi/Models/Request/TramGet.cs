using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TTSSXApi.Models.Request
{
    public class TramGet
    {
        [DataMember(Name = "trams")]
        public string[] Trams { get; set; }
    }
}
