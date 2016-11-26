using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTSSXApi.Models.Db
{
    [Table("trams")]
    public class Tram
    {
        [Column("traid")]
        public int Id { get; set; }
        [Column("tratheirid")]
        public string TheirId { get; set; }
        [Column("trasideno")]
        public string SideNo { get; set; }
        [Column("tradepid")]
        public int DepoId { get; set; }
        [Column("trattyid")]
        public int TramTypeId { get; set; }
        [Column("traextrainfo")]
        public string ExtraInfo { get; set; }


        public virtual Depo Depo { get; set; }
        public virtual TramType TramType { get; set; }
	public virtual ICollection<FetchPassage> FetchPassages { get; set; }
    }
}
