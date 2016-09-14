using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TTSSXApi.Models.Response
{
    public class TramGetRs
    {
        [DataMember(Name = "items")]
        public TramGetItem[] Items { get; set; }
    }
}
