﻿// <auto-generated />
using System;
using Coeos.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Coeos.Migrations
{
    [DbContext(typeof(CoeosContext))]
    [Migration("20201128225037_ModificationManyToManyInterventionAgent2")]
    partial class ModificationManyToManyInterventionAgent2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("AgentIntervention", b =>
                {
                    b.Property<int>("AgentsId")
                        .HasColumnType("int");

                    b.Property<int>("InterventionsId")
                        .HasColumnType("int");

                    b.HasKey("AgentsId", "InterventionsId");

                    b.HasIndex("InterventionsId");

                    b.ToTable("AgentIntervention");
                });

            modelBuilder.Entity("Coeos.Models.Agent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Categorie")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datecre")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Poste")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prenom")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SocieteId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SocieteId");

                    b.ToTable("Agent");
                });

            modelBuilder.Entity("Coeos.Models.Categorie", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Datecre")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorie");
                });

            modelBuilder.Entity("Coeos.Models.Intervention", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("CategorieId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Datecre")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("Dateintervention")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Encours")
                        .HasColumnType("bit");

                    b.Property<string>("Escalade")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Fin")
                        .HasColumnType("bit");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CategorieId");

                    b.ToTable("Intervention");
                });

            modelBuilder.Entity("Coeos.Models.Lieu", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Datecre")
                        .HasColumnType("datetime2");

                    b.Property<int?>("InterventionId")
                        .HasColumnType("int");

                    b.Property<string>("Libelle")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Site")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InterventionId");

                    b.ToTable("Lieu");
                });

            modelBuilder.Entity("Coeos.Models.Photo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Filename")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("InterventionId")
                        .HasColumnType("int");

                    b.Property<string>("Path")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("InterventionId");

                    b.ToTable("Photo");
                });

            modelBuilder.Entity("Coeos.Models.Societe", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<DateTime>("Datecre")
                        .HasColumnType("datetime2");

                    b.Property<string>("Nom")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Societe");
                });

            modelBuilder.Entity("AgentIntervention", b =>
                {
                    b.HasOne("Coeos.Models.Agent", null)
                        .WithMany()
                        .HasForeignKey("AgentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Coeos.Models.Intervention", null)
                        .WithMany()
                        .HasForeignKey("InterventionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Coeos.Models.Agent", b =>
                {
                    b.HasOne("Coeos.Models.Societe", null)
                        .WithMany("Agents")
                        .HasForeignKey("SocieteId");
                });

            modelBuilder.Entity("Coeos.Models.Intervention", b =>
                {
                    b.HasOne("Coeos.Models.Categorie", "Categorie")
                        .WithMany()
                        .HasForeignKey("CategorieId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Categorie");
                });

            modelBuilder.Entity("Coeos.Models.Lieu", b =>
                {
                    b.HasOne("Coeos.Models.Intervention", null)
                        .WithMany("Lieux")
                        .HasForeignKey("InterventionId");
                });

            modelBuilder.Entity("Coeos.Models.Photo", b =>
                {
                    b.HasOne("Coeos.Models.Intervention", null)
                        .WithMany("Photos")
                        .HasForeignKey("InterventionId");
                });

            modelBuilder.Entity("Coeos.Models.Intervention", b =>
                {
                    b.Navigation("Lieux");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Coeos.Models.Societe", b =>
                {
                    b.Navigation("Agents");
                });
#pragma warning restore 612, 618
        }
    }
}
