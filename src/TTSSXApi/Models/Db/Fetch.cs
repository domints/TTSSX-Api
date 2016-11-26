using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTSSXApi.Models.Db
{
    [Table("fetches")]
    public class Fetch
    {
        [ColumnAttribute("fetid")]
        public int ID { get; set; }
        [ColumnAttribute("fetstopid")]
        public int StopId { get; set; }
        [ColumnAttribute("fettime")]
        public DateTime Time { get; set; }
        [ColumnAttribute("fetalerts")]
        public string Alerts { get; set; }

        public virtual ICollection<FetchPassage> FetchPassages { get; set; }
    }
}