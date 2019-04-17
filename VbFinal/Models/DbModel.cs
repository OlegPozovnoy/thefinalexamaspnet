namespace VbFinal.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DbModel : DbContext
    {
        public DbModel()
            : base("name=DefaultConnection")
        {
        }

        public virtual DbSet<VbPlayer> VbPlayers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<VbPlayer>()
                .Property(e => e.FirstName)
                .IsUnicode(false);

            modelBuilder.Entity<VbPlayer>()
                .Property(e => e.Lastname)
                .IsUnicode(false);           
        }
    }
}
