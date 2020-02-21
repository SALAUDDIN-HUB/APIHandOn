using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace HandsOnPractice.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Department> Department { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }
        public virtual DbSet<Employee1> Employee1 { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Order> Order { get; set; }
        public virtual DbSet<Orders> Orders { get; set; }
        public virtual DbSet<Product> Product { get; set; }
        public virtual DbSet<Project> Project { get; set; }
        public virtual DbSet<Project4> Project4 { get; set; }
        public virtual DbSet<Students> Students { get; set; }
        public virtual DbSet<Works> Works { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-I3GJCG7\\SQLEXPRESS;Initial Catalog=master;User ID=sa;Password=pass@word1;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Companyname)
                    .IsRequired()
                    .HasColumnName("companyname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Contactname)
                    .HasColumnName("contactname")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Customerid)
                    .IsRequired()
                    .HasColumnName("customerid")
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Fax)
                    .HasColumnName("fax")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(14)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Town)
                    .HasColumnName("town")
                    .HasMaxLength(15)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Department>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasColumnName("Dept_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.DeptNo)
                    .IsRequired()
                    .HasColumnName("Dept_no")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasColumnName("location")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.Eid);

                entity.HasIndex(e => e.ProjectId);

                entity.Property(e => e.Eid).HasMaxLength(5);

                entity.Property(e => e.Designation).HasMaxLength(20);

                entity.Property(e => e.Ename)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.JoinDate).HasColumnType("date");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.Salary).HasColumnType("decimal(18, 2)");

                entity.HasOne(d => d.Project)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.ProjectId);
            });

            modelBuilder.Entity<Employee1>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.DeptNo)
                    .IsRequired()
                    .HasColumnName("dept_no")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EmpFname)
                    .IsRequired()
                    .HasColumnName("emp_fname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EmpLname)
                    .IsRequired()
                    .HasColumnName("emp_lname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.ItemName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Ordersid);

                entity.ToTable("order");

                entity.HasIndex(e => e.ItemId);

                entity.Property(e => e.Deliverydate).HasColumnName("deliverydate");

                entity.Property(e => e.ItemId).HasColumnName("ItemID");

                entity.Property(e => e.Ordersdate).HasColumnType("date");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Order)
                    .HasForeignKey(d => d.ItemId);
            });

            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.Customerid)
                    .IsRequired()
                    .HasColumnName("customerid")
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Orderdate)
                    .HasColumnName("orderdate")
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Orderid).HasColumnName("orderid");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.Shipaddress)
                    .HasColumnName("shipaddress")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Shipname)
                    .HasColumnName("shipname")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Shippeddate)
                    .HasColumnName("shippeddate")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("product");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Stock).HasColumnName("stock");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasColumnName("project_name")
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectNo)
                    .IsRequired()
                    .HasColumnName("project_no")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Project4>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectName)
                    .IsRequired()
                    .HasMaxLength(30);
            });

            modelBuilder.Entity<Students>(entity =>
            {
                entity.ToTable("students");

                entity.Property(e => e.Id).HasColumnName("ID");
            });

            modelBuilder.Entity<Works>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmpNo).HasColumnName("emp_no");

                entity.Property(e => e.Enterdate)
                    .HasColumnName("enterdate")
                    .HasColumnType("date");

                entity.Property(e => e.Job)
                    .HasColumnName("job")
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProjectNo)
                    .HasColumnName("project_no")
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
