﻿// <auto-generated />
using System;
using Doctors.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Doctors.Infrastructure.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Doctors.Domain.Entities.DataSheet", b =>
                {
                    b.Property<int>("DataSheetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DataSheetId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Details")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PacientId")
                        .HasColumnType("int");

                    b.HasKey("DataSheetId");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PacientId");

                    b.ToTable("DataSheets");
                });

            modelBuilder.Entity("Doctors.Domain.Entities.Doctor", b =>
                {
                    b.Property<int>("DoctorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("DoctorId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Crm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Specialty")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("DoctorId");

                    b.ToTable("Doctors");

                    b.HasData(
                        new
                        {
                            DoctorId = 1,
                            Active = true,
                            Cpf = "79769206008",
                            Crm = "12345",
                            Name = "Doctor Teste",
                            Specialty = "Pediatra"
                        });
                });

            modelBuilder.Entity("Doctors.Domain.Entities.Pacient", b =>
                {
                    b.Property<int>("PacientId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PacientId"));

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CellphoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("PacientId");

                    b.HasIndex("AddressId");

                    b.ToTable("Pacients");
                });

            modelBuilder.Entity("Doctors.Domain.Utils.Address", b =>
                {
                    b.Property<int>("AddressId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AddressId"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Complement")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AddressId");

                    b.ToTable("Address");
                });

            modelBuilder.Entity("Doctors.Domain.Entities.DataSheet", b =>
                {
                    b.HasOne("Doctors.Domain.Entities.Doctor", "Doctor")
                        .WithMany("DataSheets")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Doctors.Domain.Entities.Pacient", "Pacient")
                        .WithMany("DataSheets")
                        .HasForeignKey("PacientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Pacient");
                });

            modelBuilder.Entity("Doctors.Domain.Entities.Pacient", b =>
                {
                    b.HasOne("Doctors.Domain.Utils.Address", "Address")
                        .WithMany()
                        .HasForeignKey("AddressId");

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Doctors.Domain.Entities.Doctor", b =>
                {
                    b.Navigation("DataSheets");
                });

            modelBuilder.Entity("Doctors.Domain.Entities.Pacient", b =>
                {
                    b.Navigation("DataSheets");
                });
#pragma warning restore 612, 618
        }
    }
}
