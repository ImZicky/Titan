﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Titan;

namespace Titan.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20190630021750_PedroAlvares")]
    partial class PedroAlvares
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Titan.Models.ClienteEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CorId");

                    b.Property<DateTime>("DtIns");

                    b.Property<int?>("LojaId");

                    b.Property<int>("Xmax");

                    b.Property<int>("Xmin");

                    b.Property<int>("Ymax");

                    b.Property<int>("Ymin");

                    b.HasKey("Id");

                    b.HasIndex("CorId");

                    b.HasIndex("LojaId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("Titan.Models.Cor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("B");

                    b.Property<int>("G");

                    b.Property<int>("R");

                    b.HasKey("Id");

                    b.ToTable("Cor");
                });

            modelBuilder.Entity("Titan.Models.LojaEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.ToTable("Lojas");
                });

            modelBuilder.Entity("Titan.Models.SatisfacaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DtIns");

                    b.Property<int?>("LojaId");

                    b.Property<int?>("SecaoId");

                    b.Property<int>("Sentimento");

                    b.HasKey("Id");

                    b.HasIndex("LojaId");

                    b.HasIndex("SecaoId");

                    b.ToTable("Satisfacoes");
                });

            modelBuilder.Entity("Titan.Models.SecaoEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Categoria");

                    b.Property<int?>("LojaId");

                    b.Property<string>("Nome");

                    b.HasKey("Id");

                    b.HasIndex("LojaId");

                    b.ToTable("Secoes");
                });

            modelBuilder.Entity("Titan.Models.UsuarioEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email");

                    b.Property<int?>("LojaEntityId");

                    b.Property<string>("Senha");

                    b.Property<int>("Tipo");

                    b.HasKey("Id");

                    b.HasIndex("LojaEntityId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("Titan.Models.ClienteEntity", b =>
                {
                    b.HasOne("Titan.Models.Cor", "Cor")
                        .WithMany()
                        .HasForeignKey("CorId");

                    b.HasOne("Titan.Models.LojaEntity", "Loja")
                        .WithMany()
                        .HasForeignKey("LojaId");
                });

            modelBuilder.Entity("Titan.Models.SatisfacaoEntity", b =>
                {
                    b.HasOne("Titan.Models.LojaEntity", "Loja")
                        .WithMany()
                        .HasForeignKey("LojaId");

                    b.HasOne("Titan.Models.SecaoEntity", "Secao")
                        .WithMany()
                        .HasForeignKey("SecaoId");
                });

            modelBuilder.Entity("Titan.Models.SecaoEntity", b =>
                {
                    b.HasOne("Titan.Models.LojaEntity", "Loja")
                        .WithMany()
                        .HasForeignKey("LojaId");
                });

            modelBuilder.Entity("Titan.Models.UsuarioEntity", b =>
                {
                    b.HasOne("Titan.Models.LojaEntity")
                        .WithMany("Usuarios")
                        .HasForeignKey("LojaEntityId");
                });
#pragma warning restore 612, 618
        }
    }
}
