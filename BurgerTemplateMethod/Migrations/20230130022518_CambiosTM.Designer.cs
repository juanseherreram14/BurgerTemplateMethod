﻿// <auto-generated />
using BurgerTemplateMethod.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BurgerTemplateMethod.Migrations
{
    [DbContext(typeof(BurgerTemplateMethodContext))]
    [Migration("20230130022518_CambiosTM")]
    partial class CambiosTM
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BurgerTemplateMethod.Models.Burger", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<bool>("WithCheese")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Burger");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Burger");
                });

            modelBuilder.Entity("BurgerTemplateMethod.Models.Americana", b =>
                {
                    b.HasBaseType("BurgerTemplateMethod.Models.Burger");

                    b.HasDiscriminator().HasValue("Americana");
                });
#pragma warning restore 612, 618
        }
    }
}
