using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace TTSSXApi.Models.Db
{
    [Table("fetchpassages")]
    public class FetchPassage
    {
        [Column("ftpid")]
        public int ID { get; set; }
        [ColumnAttribute("ftpfetid")]
        public int FetchId { get; set; }
        [ColumnAttribute("ftptheirtraid")]
        public string TheirTramId { get; set; }
        [ColumnAttribute("ftprelative")]
        public int RelativeTime { get; set; }
        [ColumnAttribute("ftppassageid")]
        public long PassageId { get; set; }
        [ColumnAttribute("ftptripid")]
        public long TripId { get; set; }
        [ColumnAttribute("ftpplanned")]
        public TimeSpan PlannedTime { get; set; }
        [ColumnAttribute("ftpactual")]
        public TimeSpan? ActualTime { get; set; }
        [ColumnAttribute("ftptraid")]
        public int? TramId { get; set; }
	[ColumnAttribute("ftpline")]
        public string LineNo { get; set; }
        [ColumnAttribute("ftpdirection")]
        public string Direction { get; set; }

        
        public virtual Fetch Fetch { get; set; }
        public virtual Tram Tram { get; set; }
    }
}
