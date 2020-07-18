namespace WowAltsWS
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class WowAltsDBContext : DbContext
    {
        public WowAltsDBContext()
            : base("name=WowAltsDBContext")
        {
            base.Configuration.ProxyCreationEnabled = false;
        }

        public virtual DbSet<Character> Character { get; set; }
        public virtual DbSet<Class> Class { get; set; }
        public virtual DbSet<Faction> Faction { get; set; }
        public virtual DbSet<Realm> Realm { get; set; }
        public virtual DbSet<Spec> Spec { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .Property(e => e.Class1)
                .IsUnicode(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Character)
                .WithRequired(e => e.Class)
                .HasForeignKey(e => e.Class_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Class>()
                .HasMany(e => e.Spec)
                .WithRequired(e => e.Class)
                .HasForeignKey(e => e.Class_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Faction>()
                .Property(e => e.Faction1)
                .IsUnicode(false);

            modelBuilder.Entity<Faction>()
                .HasMany(e => e.Character)
                .WithRequired(e => e.Faction)
                .HasForeignKey(e => e.Faction_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Realm>()
                .Property(e => e.Realm1)
                .IsUnicode(false);

            modelBuilder.Entity<Realm>()
                .HasMany(e => e.Character)
                .WithRequired(e => e.Realm)
                .HasForeignKey(e => e.Realm_FK)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Spec>()
                .Property(e => e.Spec1)
                .IsUnicode(false);

            modelBuilder.Entity<Spec>()
                .HasMany(e => e.Character)
                .WithRequired(e => e.Spec)
                .HasForeignKey(e => e.Class_Spec_FK)
                .WillCascadeOnDelete(false);
        }
    }
}
