using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace TTSSXApi.Models.Response
{
    public class PassagePostRs
    {
        [DataMember(Name = "vNo")]
        public int VehicleInstances { get; set; }
        [DataMember(Name = "pNo")]
        public int PassageInstances { get; set; }

    }
}
