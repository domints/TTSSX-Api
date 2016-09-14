using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TTSSXApi.Models.Db
{
    [Table("depos")]
    public class Depo
    {
        [Column("depid")]
        public int Id { get; set; }
        [Column("depname")]
        public string Name { get; set; }

        public virtual ICollection<Tram> Trams { get; set; }
    }
}
