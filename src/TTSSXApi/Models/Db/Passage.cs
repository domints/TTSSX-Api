using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TTSSXApi.Models.Db
{
    [Table("passages")]
    public class Passage
    {
        [Column("id")]
        public int Id { get; set; }
        [Column("theirid")]
        public string TheirId { get; set; }
        [Column("line")]
        public string Line { get; set; }
        [Column("plannedtime")]
        public string PlannedTime { get; set; }
        [Column("vehicleid")]
        public string VehicleId { get; set; }
        [Column("tramno")]
        public string TramNo { get; set; }
        [Column("compositionno")]
        public string CompositionNo { get; set; }
        [Column("submittime")]
        public DateTime submitTime { get; set; }
        [Column("routeid")]
        public string RouteId { get; set; }
        [Column("tripid")]
        public string TripId { get; set; }
        [Column("direction")]
        public string Direction { get; set; }
    }
}
