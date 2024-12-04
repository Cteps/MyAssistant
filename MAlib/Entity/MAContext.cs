using MAlib.Entity.Models._Obj;
using Microsoft.EntityFrameworkCore;

namespace MAServer.Entity
{
    public class MAContext : DbContext
    {
        public DbSet<ObjEsp> ObjEsp { get; set; }

        public MAContext(DbContextOptions<MAContext> options)
            : base(options)
        { }

    }
}
