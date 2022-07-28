using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BsistemaPos.Models
{
    public partial class sistemaPosDBContext : DbContext
    {
        public sistemaPosDBContext()
        {
        }

        public sistemaPosDBContext(DbContextOptions<sistemaPosDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Client> Clients { get; set; } = null!;
        public virtual DbSet<Invoice> Invoices { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Sale> Sales { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>(entity =>
            {
                entity.ToTable("clients");

                entity.Property(e => e.ClientId)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("clientId");

                entity.Property(e => e.CAddress)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("c_address");

                entity.Property(e => e.CName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("c_name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("phone");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("invoices");

                entity.Property(e => e.InvoiceId).HasColumnName("invoiceId");

                entity.Property(e => e.ClientIdFk)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("clientId_fk");

                entity.Property(e => e.InvoiceDate)
                    .HasColumnType("date")
                    .HasColumnName("invoice_date");

                entity.Property(e => e.Total)
                    .HasColumnType("money")
                    .HasColumnName("total");

                /*
                entity.HasOne(d => d.ClientIdFkNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.ClientIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("invoices_client_fk");
                */
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("products");

                entity.Property(e => e.ProductId).HasColumnName("productId");

                entity.Property(e => e.Img)
                    .HasMaxLength(350)
                    .IsUnicode(false)
                    .HasColumnName("img");

                entity.Property(e => e.PDescription)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("p_description");

                entity.Property(e => e.PName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("p_name");

                entity.Property(e => e.Stock).HasColumnName("stock");

                entity.Property(e => e.Price)
                    .HasColumnType("money")
                    .HasColumnName("price");
            });

            modelBuilder.Entity<Sale>(entity =>
            {
                entity.ToTable("sales");

                entity.Property(e => e.SaleId).HasColumnName("saleId");

                entity.Property(e => e.InvoiceIdFk).HasColumnName("invoiceId_fk");

                entity.Property(e => e.ProductIdFk).HasColumnName("productId_fk");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.SubTotal)
                    .HasColumnType("money")
                    .HasColumnName("sub_total");

                entity.Property(e => e.UnitPrice)
                    .HasColumnType("money")
                    .HasColumnName("unit_price");

                /*
                entity.HasOne(d => d.InvoiceIdFkNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.InvoiceIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_invoices_fk");

                entity.HasOne(d => d.ProductIdFkNavigation)
                    .WithMany(p => p.Sales)
                    .HasForeignKey(d => d.ProductIdFk)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("sales_products_fk");
                */
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
