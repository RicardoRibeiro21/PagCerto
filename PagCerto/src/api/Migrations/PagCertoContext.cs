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

        public virtual DbSet<AcquirerConfirmation> AcquirerConfirmations { get; set; }
        public virtual DbSet<Anticipation> Anticipations { get; set; }
        public virtual DbSet<AnticipationTransaction> AnticipationTransactions { get; set; }
        public virtual DbSet<Parcel> Parcels { get; set; }
        public virtual DbSet<ResultAnticipation> ResultAnticipations { get; set; }
        public virtual DbSet<Transaction> Transactions { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=ROGER\\SQLEXPRESS01;Initial Catalog=DBPAGCERTO;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<AcquirerConfirmation>(entity =>
            {
                entity.HasKey(e => e.IdStatus)
                    .HasName("PK__ACQUIRER__C55A1764345540FC");

                entity.ToTable("ACQUIRER_CONFIRMATIONS");

                entity.HasIndex(e => e.DescriptionAcquirer, "UQ__ACQUIRER__2D83C8C564220107")
                    .IsUnique();

                entity.Property(e => e.IdStatus).HasColumnName("ID_STATUS");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.DescriptionAcquirer)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION_ACQUIRER");
            });

            modelBuilder.Entity<Anticipation>(entity =>
            {
                entity.HasKey(e => e.IdAnticipation)
                    .HasName("PK__ANTICIPA__B73FB100DD4A5269");

                entity.ToTable("ANTICIPATIONS");

                entity.Property(e => e.IdAnticipation).HasColumnName("ID_ANTICIPATION");

                entity.Property(e => e.DateBegin)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_BEGIN");

                entity.Property(e => e.DateFinish)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_FINISH");

                entity.Property(e => e.DateRequest)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_REQUEST");

                entity.Property(e => e.IdResultAnticipation).HasColumnName("ID_RESULT_ANTICIPATION");

                entity.Property(e => e.ValueAnticipation)
                    .HasColumnType("decimal(20, 4)")
                    .HasColumnName("VALUE_ANTICIPATION");

                entity.Property(e => e.ValueRequest)
                    .HasColumnType("decimal(20, 4)")
                    .HasColumnName("VALUE_REQUEST");

                entity.HasOne(d => d.IdResultAnticipationNavigation)
                    .WithMany(p => p.Anticipations)
                    .HasForeignKey(d => d.IdResultAnticipation)
                    .HasConstraintName("FK__ANTICIPAT__ID_RE__0E6E26BF");
            });

            modelBuilder.Entity<AnticipationTransaction>(entity =>
            {
                entity.HasKey(e => e.IdAnticipationTransaction)
                    .HasName("PK__ANTICIPA__D83FA6126811EB7D");

                entity.ToTable("ANTICIPATION_TRANSACTIONS");

                entity.Property(e => e.IdAnticipationTransaction).HasColumnName("ID_ANTICIPATION_TRANSACTION");

                entity.Property(e => e.IdAnticipation).HasColumnName("ID_ANTICIPATION");

                entity.Property(e => e.IdResultAnticipation).HasColumnName("ID_RESULT_ANTICIPATION");

                entity.Property(e => e.IdTransaction).HasColumnName("ID_TRANSACTION");

                entity.HasOne(d => d.IdAnticipationNavigation)
                    .WithMany(p => p.AnticipationTransactions)
                    .HasForeignKey(d => d.IdAnticipation)
                    .HasConstraintName("FK__ANTICIPAT__ID_AN__114A936A");

                entity.HasOne(d => d.IdResultAnticipationNavigation)
                    .WithMany(p => p.AnticipationTransactions)
                    .HasForeignKey(d => d.IdResultAnticipation)
                    .HasConstraintName("FK__ANTICIPAT__ID_RE__123EB7A3");

                entity.HasOne(d => d.IdTransactionNavigation)
                    .WithMany(p => p.AnticipationTransactions)
                    .HasForeignKey(d => d.IdTransaction)
                    .HasConstraintName("FK__ANTICIPAT__ID_TR__1332DBDC");
            });

            modelBuilder.Entity<Parcel>(entity =>
            {
                entity.HasKey(e => e.IdParcel)
                    .HasName("PK__PARCELS__BE6868C8DC5DFCC9");

                entity.ToTable("PARCELS");

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
                    .WithMany(p => p.Parcels)
                    .HasForeignKey(d => d.IdTransaction)
                    .HasConstraintName("FK__PARCELS__ID_TRAN__08B54D69");
            });

            modelBuilder.Entity<ResultAnticipation>(entity =>
            {
                entity.HasKey(e => e.IdResult)
                    .HasName("PK__RESULT_A__D5088D441E12E16D");

                entity.ToTable("RESULT_ANTICIPATIONS");

                entity.HasIndex(e => e.DescriptionResult, "UQ__RESULT_A__923B26E54DD7B839")
                    .IsUnique();

                entity.Property(e => e.IdResult).HasColumnName("ID_RESULT");

                entity.Property(e => e.Active).HasColumnName("ACTIVE");

                entity.Property(e => e.DescriptionResult)
                    .IsRequired()
                    .HasMaxLength(40)
                    .IsUnicode(false)
                    .HasColumnName("DESCRIPTION_RESULT");
            });

            modelBuilder.Entity<Transaction>(entity =>
            {
                entity.HasKey(e => e.IdTransaction)
                    .HasName("PK__TRANSACT__2029827DAC68520F");

                entity.ToTable("TRANSACTIONS");

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
                    .WithMany(p => p.Transactions)
                    .HasForeignKey(d => d.AcquirerConfirmation)
                    .HasConstraintName("FK__TRANSACTI__ACQUI__02FC7413");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
