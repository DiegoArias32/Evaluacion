﻿// <auto-generated />
using System;
using Entity.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Entity.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Entity.Model.DatesPerson.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AddressLine")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressLine2")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AddressType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int?>("NeighborhoodId")
                        .HasColumnType("int");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("CountryId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("NeighborhoodId");

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<string>("MainPostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Cities");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Country", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("IsoCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumericCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Countries");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("CountryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Neighborhood", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CityId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("ZoneType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Neighborhoods");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Provider", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPersonName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ContactPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("PersonId")
                        .HasColumnType("int");

                    b.Property<string>("ProviderCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ProviderType")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<string>("TaxId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TradeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.HasIndex("PersonId");

                    b.ToTable("Providers");
                });

            modelBuilder.Entity("Entity.Model.Security.Form", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("FormType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Route")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Forms");
                });

            modelBuilder.Entity("Entity.Model.Security.FormModule", b =>
                {
                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("ModuleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("FormId", "ModuleId");

                    b.HasIndex("ModuleId");

                    b.ToTable("FormModules");
                });

            modelBuilder.Entity("Entity.Model.Security.Module", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("DisplayOrder")
                        .HasColumnType("int");

                    b.Property<string>("Icon")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Modules");
                });

            modelBuilder.Entity("Entity.Model.Security.Permission", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsSystemPermission")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PermissionValue")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Permissions");
                });

            modelBuilder.Entity("Entity.Model.Security.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AddressId")
                        .HasColumnType("int");

                    b.Property<string>("AlternativePhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("nvarchar(8)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Gender")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nationality")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicturePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AddressId");

                    b.ToTable("Persons");

                    b.HasDiscriminator().HasValue("Person");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Entity.Model.Security.Rol", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsSystemRole")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Entity.Model.Security.RolFormPermission", b =>
                {
                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int>("FormId")
                        .HasColumnType("int");

                    b.Property<int>("PermissionId")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("RolId", "FormId", "PermissionId");

                    b.HasIndex("FormId");

                    b.HasIndex("PermissionId");

                    b.ToTable("RolFormPermissions");
                });

            modelBuilder.Entity("Entity.Model.Security.RolUser", b =>
                {
                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<int>("RolId")
                        .HasColumnType("int");

                    b.Property<int?>("AssignedByUserId")
                        .HasColumnType("int");

                    b.Property<DateTime>("AssignedDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int?>("UserId1")
                        .HasColumnType("int");

                    b.HasKey("UserId", "RolId");

                    b.HasIndex("AssignedByUserId");

                    b.HasIndex("RolId");

                    b.HasIndex("UserId1");

                    b.ToTable("RolUsers");
                });

            modelBuilder.Entity("Entity.Model.Security.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DeleteAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("LastLoginDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonId")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(true);

                    b.Property<DateTime?>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("PersonId")
                        .IsUnique();

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Client", b =>
                {
                    b.HasBaseType("Entity.Model.Security.Person");

                    b.Property<string>("ClientNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClientType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.HasDiscriminator().HasValue("Client");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Employee", b =>
                {
                    b.HasBaseType("Entity.Model.Security.Person");

                    b.Property<int?>("ContractType")
                        .HasColumnType("int");

                    b.Property<string>("Department")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmployeeCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("HireDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Position")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("Salary")
                        .HasPrecision(18, 2)
                        .HasColumnType("decimal(18,2)");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Address", b =>
                {
                    b.HasOne("Entity.Model.DatesPerson.City", "City")
                        .WithMany("Addresses")
                        .HasForeignKey("CityId");

                    b.HasOne("Entity.Model.DatesPerson.Country", "Country")
                        .WithMany("Addresses")
                        .HasForeignKey("CountryId");

                    b.HasOne("Entity.Model.DatesPerson.Department", "Department")
                        .WithMany("Addresses")
                        .HasForeignKey("DepartmentId");

                    b.HasOne("Entity.Model.DatesPerson.Neighborhood", "Neighborhood")
                        .WithMany("Addresses")
                        .HasForeignKey("NeighborhoodId");

                    b.Navigation("City");

                    b.Navigation("Country");

                    b.Navigation("Department");

                    b.Navigation("Neighborhood");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.City", b =>
                {
                    b.HasOne("Entity.Model.DatesPerson.Department", "Department")
                        .WithMany("Cities")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Department", b =>
                {
                    b.HasOne("Entity.Model.DatesPerson.Country", "Country")
                        .WithMany("Departments")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Neighborhood", b =>
                {
                    b.HasOne("Entity.Model.DatesPerson.City", "City")
                        .WithMany("Neighborhoods")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Provider", b =>
                {
                    b.HasOne("Entity.Model.DatesPerson.Address", "Address")
                        .WithMany("Providers")
                        .HasForeignKey("AddressId");

                    b.HasOne("Entity.Model.Security.Person", "Person")
                        .WithMany()
                        .HasForeignKey("PersonId");

                    b.Navigation("Address");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Entity.Model.Security.FormModule", b =>
                {
                    b.HasOne("Entity.Model.Security.Form", "Form")
                        .WithMany("FormModules")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Model.Security.Module", "Module")
                        .WithMany("FormModules")
                        .HasForeignKey("ModuleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("Module");
                });

            modelBuilder.Entity("Entity.Model.Security.Person", b =>
                {
                    b.HasOne("Entity.Model.DatesPerson.Address", "Address")
                        .WithMany("Persons")
                        .HasForeignKey("AddressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Entity.Model.Security.RolFormPermission", b =>
                {
                    b.HasOne("Entity.Model.Security.Form", "Form")
                        .WithMany("RolFormPermissions")
                        .HasForeignKey("FormId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Model.Security.Permission", "Permission")
                        .WithMany("RolFormPermissions")
                        .HasForeignKey("PermissionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Model.Security.Rol", "Rol")
                        .WithMany("RolFormPermissions")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Form");

                    b.Navigation("Permission");

                    b.Navigation("Rol");
                });

            modelBuilder.Entity("Entity.Model.Security.RolUser", b =>
                {
                    b.HasOne("Entity.Model.Security.User", "AssignedByUser")
                        .WithMany()
                        .HasForeignKey("AssignedByUserId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.HasOne("Entity.Model.Security.Rol", "Rol")
                        .WithMany("RolUsers")
                        .HasForeignKey("RolId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Model.Security.User", "User")
                        .WithMany("RolUsers")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Entity.Model.Security.User", null)
                        .WithMany("AssignedRoles")
                        .HasForeignKey("UserId1");

                    b.Navigation("AssignedByUser");

                    b.Navigation("Rol");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Entity.Model.Security.User", b =>
                {
                    b.HasOne("Entity.Model.Security.Person", "Person")
                        .WithOne("User")
                        .HasForeignKey("Entity.Model.Security.User", "PersonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Address", b =>
                {
                    b.Navigation("Persons");

                    b.Navigation("Providers");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.City", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Neighborhoods");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Country", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Departments");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Department", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("Cities");
                });

            modelBuilder.Entity("Entity.Model.DatesPerson.Neighborhood", b =>
                {
                    b.Navigation("Addresses");
                });

            modelBuilder.Entity("Entity.Model.Security.Form", b =>
                {
                    b.Navigation("FormModules");

                    b.Navigation("RolFormPermissions");
                });

            modelBuilder.Entity("Entity.Model.Security.Module", b =>
                {
                    b.Navigation("FormModules");
                });

            modelBuilder.Entity("Entity.Model.Security.Permission", b =>
                {
                    b.Navigation("RolFormPermissions");
                });

            modelBuilder.Entity("Entity.Model.Security.Person", b =>
                {
                    b.Navigation("User")
                        .IsRequired();
                });

            modelBuilder.Entity("Entity.Model.Security.Rol", b =>
                {
                    b.Navigation("RolFormPermissions");

                    b.Navigation("RolUsers");
                });

            modelBuilder.Entity("Entity.Model.Security.User", b =>
                {
                    b.Navigation("AssignedRoles");

                    b.Navigation("RolUsers");
                });
#pragma warning restore 612, 618
        }
    }
}
