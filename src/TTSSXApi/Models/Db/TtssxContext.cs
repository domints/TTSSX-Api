using Microsoft.EntityFrameworkCore;

namespace TTSSXApi.Models.Db
{
    public class TtssxContext : DbContext
    {
        public TtssxContext(DbContextOptions<TtssxContext> options)
            : base(options)
        { }

        public virtual DbSet<Passage> Passages { get; set; }
        public virtual DbSet<Depo> Depos { get; set; }
        public virtual DbSet<TramType> TramTypes { get; set; }
        public virtual DbSet<Tram> Trams { get; set; }
        public virtual DbSet<Fetch> Fetches { get; set; }
        public virtual DbSet<FetchPassage> FetchPassages { get; set; }
    }
}
