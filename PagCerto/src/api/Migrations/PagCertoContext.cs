using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using PagCerto.src.api.Models;

#nullable disable

namespace PagCerto.src.api.Migrations
{
    public partial class PagCertoContext : DbContext
    {
        public PagCertoContext()
        {
        }

        public PagCertoContext(DbContextOptions<PagCertoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAcquirerConfirmation> TbAcquirerConfirmations { get; set; }
        public virtual DbSet<TbParcel> TbParcels { get; set; }
        public virtual DbSet<TbTransaction> TbTransactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ROGER\\SQLEXPRESS01; Initial Catalog=DBPAGCERTO;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<TbAcquirerConfirmation>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__TB_ACQUI__C55A17644B792568");

                entity.ToTable("TB_ACQUIRER_CONFIRMATION");

                entity.HasIndex(e => e.DescriptionAcquirer, "UQ__TB_ACQUI__2D83C8C5FF76CD7A")
                    .IsUnique();

                entity.Property(e => e.IdStatus).HasColumnName("ID_STATUS");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.DescriptionAcquirer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION_ACQUIRER");
            });

            modelBuilder.Entity<TbParcel>(entity =>
            {
                entity.HasKey(e => e.IdParcel)
                    .HasName("PK__TB_PARCE__BE6868C85A6D8D9E");

                entity.ToTable("TB_PARCEL");

                entity.Property(e => e.IdParcel).HasColumnName("ID_PARCEL");

                entity.Property(e => e.AdvanceAmount)
                    .HasColumnType("decimal(20, 4)")
                    .HasColumnName("ADVANCE_AMOUNT");

                entity.Property(e => e.DateAdvanceInstallment)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_ADVANCE_INSTALLMENT");

                entity.Property(e => e.DateExpectedInstallment)
                    .HasColumnType("date")
                    .HasColumnName("DATE_EXPECTED_INSTALLMENT");

                entity.Property(e => e.GrossValue)
                    .HasColumnType("decimal(20, 4)")
                    .HasColumnName("GROSS_VALUE");

                entity.Property(e => e.IdTransaction).HasColumnName("ID_TRANSACTION");

                entity.Property(e => e.NetValue)
                    .HasColumnType("decimal(20, 4)")
                    .HasColumnName("NET_VALUE");

                entity.Property(e => e.NumberParcel).HasColumnName("NUMBER_PARCEL");

                entity.HasOne(d => d.IdTransactionNavigation)
                    .WithMany(p => p.TbParcels)
                    .HasForeignKey(d => d.IdTransaction)
                    .HasConstraintName("FK__TB_PARCEL__ID_TR__5812160E");
            });

            modelBuilder.Entity<TbTransaction>(entity =>
            {
                entity.HasKey(e => e.IdTransaction)
                    .HasName("PK__TB_TRANS__2029827D7A72FACE");

                entity.ToTable("TB_TRANSACTION");

                entity.Property(e => e.IdTransaction).HasColumnName("ID_TRANSACTION");

                entity.Property(e => e.AcquirerConfirmation).HasColumnName("ACQUIRER_CONFIRMATION");

                entity.Property(e => e.Anticipation)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ANTICIPATION")
                    .IsFixedLength(true);

                entity.Property(e => e.DataDisapproval)
                    .HasColumnType("datetime")
                    .HasColumnName("DATA_DISAPPROVAL");

                entity.Property(e => e.DateApproval)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_APPROVAL");

                entity.Property(e => e.DateTransaction)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_TRANSACTION");

                entity.Property(e => e.FlatRate)
                    .HasColumnType("decimal(10, 4)")
                    .HasColumnName("FLAT_RATE");

                entity.Property(e => e.GrossValue)
                    .HasColumnType("decimal(20, 4)")
                    .HasColumnName("GROSS_VALUE");

                entity.Property(e => e.NetValue)
                    .HasColumnType("decimal(20, 4)")
                    .HasColumnName("NET_VALUE");

                entity.Property(e => e.NumberParcel).HasColumnName("NUMBER_PARCEL");

                entity.Property(e => e.TypeCard)
                    .IsRequired()
                    .HasMaxLength(4)
                    .IsUnicode(false)
                    .HasColumnName("TYPE_CARD")
                    .IsFixedLength(true);

                entity.HasOne(d => d.AcquirerConfirmationNavigation)
                    .WithMany(p => p.TbTransactions)
                    .HasForeignKey(d => d.AcquirerConfirmation)
                    .HasConstraintName("FK__TB_TRANSA__ACQUI__5535A963");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
