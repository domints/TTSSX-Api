using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using TTSSXApi.Models.Db;

namespace TTSSXApi.Models.Response
{
    public class TramGetItem
    {
        [DataMember(Name = "id")]
        public string TramId { get; set; }
        [DataMember(Name = "no")]
        public string TramNo { get; set; }
        [DataMember(Name = "name")]
        public string Name { get; set; }
        [DataMember(Name = "lowfloor")]
        public LowFloor LowFloor { get; set; }
        [DataMember(Name = "extrainfo")]
        public string ExtraInfo { get; set; }
    }
}
