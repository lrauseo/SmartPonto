﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SmartPonto.Api.Repository;

namespace SmartPonto.Api.Migrations
{
    [DbContext(typeof(PontoDB))]
    [Migration("20200411160139_Db-v1")]
    partial class Dbv1
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3");

            modelBuilder.Entity("SmartPonto.Api.Models.Empresa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cpnj")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Fantasia")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Inativo")
                        .HasColumnType("INTEGER");

                    b.Property<string>("RazaoSocial")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("SmartPonto.Api.Models.Login", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsLoginRedeSocial")
                        .HasColumnType("INTEGER");

                    b.Property<string>("NomeRedeSocial")
                        .HasColumnType("TEXT");

                    b.Property<string>("Senha")
                        .HasColumnType("TEXT");

                    b.Property<string>("TokenLogin")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("TokenLogin")
                        .IsUnique();

                    b.ToTable("Logins");
                });

            modelBuilder.Entity("SmartPonto.Api.Models.PontoRegistro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("ProntoRegistros");
                });

            modelBuilder.Entity("SmartPonto.Api.Models.Registro", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<bool>("AjusteManual")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataHora")
                        .HasColumnType("TEXT");

                    b.Property<string>("Justificativa")
                        .HasColumnType("TEXT");

                    b.Property<long>("Latitude")
                        .HasColumnType("INTEGER");

                    b.Property<long>("Logintude")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PontoRegistroId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("PontoRegistroId");

                    b.ToTable("Registros");
                });

            modelBuilder.Entity("SmartPonto.Api.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cpf")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("EmpresaId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("Inativo")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsAdmin")
                        .HasColumnType("INTEGER");

                    b.Property<int>("LoginId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Nome")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Cpf")
                        .IsUnique();

                    b.HasIndex("EmpresaId");

                    b.HasIndex("LoginId")
                        .IsUnique();

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("SmartPonto.Api.Models.Registro", b =>
                {
                    b.HasOne("SmartPonto.Api.Models.PontoRegistro", "PontoRegistro")
                        .WithMany("Registros")
                        .HasForeignKey("PontoRegistroId");
                });

            modelBuilder.Entity("SmartPonto.Api.Models.Usuario", b =>
                {
                    b.HasOne("SmartPonto.Api.Models.Empresa", "Empresa")
                        .WithMany("Funcionarios")
                        .HasForeignKey("EmpresaId");

                    b.HasOne("SmartPonto.Api.Models.Login", "Login")
                        .WithOne("Usuario")
                        .HasForeignKey("SmartPonto.Api.Models.Usuario", "LoginId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
