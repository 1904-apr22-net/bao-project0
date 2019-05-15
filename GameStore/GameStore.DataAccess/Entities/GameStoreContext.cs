﻿using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GameStore.DataAccess.Entities
{
    public partial class GameStoreContext : DbContext
    {
        public GameStoreContext()
        {
        }

        public GameStoreContext(DbContextOptions<GameStoreContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<GameOrder> GameOrder { get; set; }
        public virtual DbSet<GameStore> GameStore { get; set; }
        public virtual DbSet<ItemInventory> ItemInventory { get; set; }
        public virtual DbSet<OrderItem> OrderItem { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.4-servicing-10062");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.HasOne(d => d.DefaultStoreNavigation)
                    .WithMany(p => p.Customer)
                    .HasForeignKey(d => d.DefaultStore)
                    .HasConstraintName("FK__Customer__Defaul__208CD6FA");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<GameOrder>(entity =>
            {
                entity.HasKey(e => e.OrderId)
                    .HasName("PK_OrderId");

                entity.Property(e => e.OrderTime).HasColumnType("datetime");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.GameOrder)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__GameOrder__Custo__25518C17");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.GameOrder)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__GameOrder__Store__2645B050");
            });

            modelBuilder.Entity<GameStore>(entity =>
            {
                entity.HasKey(e => e.StoreId)
                    .HasName("PK_StoreId");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.State)
                    .IsRequired()
                    .HasMaxLength(200);
            });

            modelBuilder.Entity<ItemInventory>(entity =>
            {
                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.ItemInventory)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__ItemInven__GameI__2FCF1A8A");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.ItemInventory)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK__ItemInven__Store__2EDAF651");
            });

            modelBuilder.Entity<OrderItem>(entity =>
            {
                entity.Property(e => e.Quantity).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.Game)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.GameId)
                    .HasConstraintName("FK__OrderItem__GameI__3493CFA7");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderItem)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderItem__Order__339FAB6E");
            });
        }
    }
}
