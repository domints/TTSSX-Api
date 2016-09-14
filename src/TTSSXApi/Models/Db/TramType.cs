using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TTSSXApi.Models.Db
{
    public enum LowFloor
    {
        None = 0,
        Partial = 1,
        Full = 2
    }

    [Table("tramtypes")]
    public class TramType
    {
        [Column("ttyid")]
        public int Id { get; set; }
        [Column("ttyname")]
        public string Name { get; set; }
        [Column("ttylowfloor")]
        public LowFloor LowFloor { get; set; }

        public virtual ICollection<Tram> Trams { get; set; }
    }
}
