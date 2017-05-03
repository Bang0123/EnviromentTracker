namespace EviromentWebservice.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

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
