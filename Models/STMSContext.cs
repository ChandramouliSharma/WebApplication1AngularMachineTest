using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebApplication1AngularMachineTest.Models
{
    public partial class STMSContext : DbContext
    {
        public STMSContext()
        {
        }

        public STMSContext(DbContextOptions<STMSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Login> Login { get; set; }
        public virtual DbSet<Visit> Visit { get; set; }
        /*
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=LAPTOP-K1HJSEQG; Initial Catalog=STMS; Integrated security=True");
            }
        }
        */
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Empid)
                    .HasName("PK__EMPLOYEE__AF2EBFA1453004B9");

                entity.ToTable("EMPLOYEE");

                entity.Property(e => e.Empid)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Lid).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.PhoneNumber).HasColumnType("numeric(18, 0)");

                entity.HasOne(d => d.L)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.Lid)
                    .HasConstraintName("FK__EMPLOYEE__Lid__267ABA7A");
            });

            modelBuilder.Entity<Login>(entity =>
            {
                entity.HasKey(e => e.Lid)
                    .HasName("PK__LOGIN__C6505B393E6FA5EC");

                entity.ToTable("LOGIN");

                entity.Property(e => e.Lid)
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Visit>(entity =>
            {
                entity.ToTable("VISIT");

                entity.Property(e => e.VisitId)
                    .HasColumnName("Visit_id")
                    .HasColumnType("numeric(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ContactNo)
                    .HasColumnName("Contact_no")
                    .HasColumnType("numeric(18, 0)");

                entity.Property(e => e.ContactPerson)
                    .HasColumnName("Contact_person")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CustName)
                    .HasColumnName("Cust_name")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Empid).HasColumnType("numeric(18, 0)");

                entity.Property(e => e.InterestProduct)
                    .HasColumnName("Interest_product")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IsDeleted).HasColumnName("Is_deleted");

                entity.Property(e => e.IsDisabled).HasColumnName("Is_disabled");

                entity.Property(e => e.VisitDatetime)
                    .HasColumnName("Visit_datetime")
                    .HasColumnType("datetime");

                entity.Property(e => e.VisitSubject)
                    .HasColumnName("Visit_subject")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.Emp)
                    .WithMany(p => p.Visit)
                    .HasForeignKey(d => d.Empid)
                    .HasConstraintName("FK__VISIT__Empid__29572725");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
