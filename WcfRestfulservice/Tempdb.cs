using System.Data.Entity;

namespace WcfRestfulservice
{
    public partial class Tempdb : DbContext
    {
        public Tempdb()
            : base("name=Tempdb")
        {
            Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Measurement> Measurements { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
