using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Network.Db_Context
{
    public partial class NetworkContext : DbContext
    {
        public NetworkContext()
        {
        }

        public NetworkContext(DbContextOptions<NetworkContext> options)
            : base(options)
        {
        }

        public virtual DbSet<City> Cities { get; set; }
        public virtual DbSet<Country> Countries { get; set; }
       
        public virtual DbSet<State> States { get; set; }
        public virtual DbSet<Tblimage> Tblimages { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=CHETUIWK1298\\SQLDEV2019 ;Database=Network ;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable("CITY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.Stateid).HasColumnName("STATEID");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Cities)
                    .HasForeignKey(d => d.Stateid)
                    .HasConstraintName("FK__CITY__STATEID__4CA06362");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable("COUNTRY");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");
            });

         

            modelBuilder.Entity<State>(entity =>
            {
                entity.ToTable("STATE");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Countryid).HasColumnName("COUNTRYID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.States)
                    .HasForeignKey(d => d.Countryid)
                    .HasConstraintName("FK__STATE__COUNTRYID__4BAC3F29");
            });

            modelBuilder.Entity<Tblimage>(entity =>
            {
                entity.ToTable("TBLimage");

                entity.Property(e => e.Image)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.CreateRefer);

                entity.Property(e => e.CreateRefer)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AdminReferCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Country)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ImageData)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNo).HasColumnName("Phone_No");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.AdminReferCodeNavigation)
                    .WithMany(p => p.InverseAdminReferCodeNavigation)
                    .HasForeignKey(d => d.AdminReferCode)
                    .HasConstraintName("FK__Users__ReferId__267ABA7A");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        internal void updateModel(User ob)
        {
            throw new NotImplementedException();
        }
    }
}
