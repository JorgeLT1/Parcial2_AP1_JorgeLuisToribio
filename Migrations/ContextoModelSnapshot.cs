﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Parcial2_AP1_JorgeLuisToribio.Migrations
{
    [DbContext(typeof(Contexto))]
    partial class ContextoModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.4");

            modelBuilder.Entity("Caja", b =>
                {
                    b.Property<int>("CajaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Concepto")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<string>("realizado")
                        .HasColumnType("TEXT");

                    b.HasKey("CajaId");

                    b.ToTable("Caja");
                });

            modelBuilder.Entity("CajaDetalle", b =>
                {
                    b.Property<int>("CajaDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CajaId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.HasKey("CajaDetalleId");

                    b.HasIndex("CajaId");

                    b.ToTable("CajaDetalle");
                });

            modelBuilder.Entity("Producto", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoId");

                    b.ToTable("Producto");

                    b.HasData(
                        new
                        {
                            ProductoId = 1,
                            Costo = 150.0,
                            Descripcion = "Almendra",
                            Existencia = 40,
                            Precio = 5.0
                        },
                        new
                        {
                            ProductoId = 2,
                            Costo = 250.0,
                            Descripcion = "Nuez",
                            Existencia = 50,
                            Precio = 40.0
                        },
                        new
                        {
                            ProductoId = 3,
                            Costo = 200.0,
                            Descripcion = "Pasas",
                            Existencia = 20,
                            Precio = 60.0
                        },
                        new
                        {
                            ProductoId = 5,
                            Costo = 400.0,
                            Descripcion = "Pistachos",
                            Existencia = 100,
                            Precio = 30.0
                        });
                });

            modelBuilder.Entity("CajaDetalle", b =>
                {
                    b.HasOne("Caja", null)
                        .WithMany("cajaDetalle")
                        .HasForeignKey("CajaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Caja", b =>
                {
                    b.Navigation("cajaDetalle");
                });
#pragma warning restore 612, 618
        }
    }
}
