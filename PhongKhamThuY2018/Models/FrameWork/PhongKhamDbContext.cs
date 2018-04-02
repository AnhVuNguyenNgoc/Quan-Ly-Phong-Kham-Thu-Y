namespace Models.FrameWork
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class PhongKhamDbContext : DbContext
    {
        public PhongKhamDbContext()
            : base("name=PhongKhamDbContext")
        {
        }

        public virtual DbSet<Category> Category { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.PassWord)
                .IsUnicode(false);
        }
    }
}
