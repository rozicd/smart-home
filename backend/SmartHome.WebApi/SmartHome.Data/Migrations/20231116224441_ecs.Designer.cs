﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using SmartHome.Data;

#nullable disable

namespace SmartHome.Data.Migrations
{
    [DbContext(typeof(DatabaseContext))]
    [Migration("20231116224441_ecs")]
    partial class ecs
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("SmartHome.Data.Entities.ActivationTokenEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Token")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("expires")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("ActivationTokens");
                });

            modelBuilder.Entity("SmartHome.Data.Entities.CityEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CountryId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CountryId");

                    b.ToTable("Cities");

                    b.HasData(
                        new
                        {
                            Id = new Guid("6315d2af-7b70-4aa4-aa47-1a1d869eb791"),
                            CountryId = new Guid("21a6c69f-50f5-454e-9d7d-5f72eeb45ee8"),
                            Name = "New York"
                        },
                        new
                        {
                            Id = new Guid("2bb365f3-08ac-4132-ad24-79d3e9fda262"),
                            CountryId = new Guid("21a6c69f-50f5-454e-9d7d-5f72eeb45ee8"),
                            Name = "Los Angeles"
                        },
                        new
                        {
                            Id = new Guid("fa1abf86-1120-4e49-be01-c296df561376"),
                            CountryId = new Guid("21a6c69f-50f5-454e-9d7d-5f72eeb45ee8"),
                            Name = "Chicago"
                        },
                        new
                        {
                            Id = new Guid("c408f493-4f48-4da3-9333-30c7ca58a2ff"),
                            CountryId = new Guid("6a5cf285-3793-4cce-a155-3cfdef88e4ff"),
                            Name = "London"
                        },
                        new
                        {
                            Id = new Guid("7a92e7bf-c265-4a32-9ff0-54e5960d7d10"),
                            CountryId = new Guid("3a77c84f-8875-4132-9fae-c07f03432435"),
                            Name = "Paris"
                        },
                        new
                        {
                            Id = new Guid("ce5f6a19-ce4c-474d-b37d-8d5943908c4d"),
                            CountryId = new Guid("b7638789-3bea-4e28-b8bc-da6015bfa2b3"),
                            Name = "Berlin"
                        },
                        new
                        {
                            Id = new Guid("fdd02f60-83ba-4ed3-bde0-62b8ce538920"),
                            CountryId = new Guid("cb187c9a-7ab2-4862-b209-19cbb2f0c390"),
                            Name = "Tokyo"
                        },
                        new
                        {
                            Id = new Guid("b4c7d391-ee85-4c1e-aa18-22c91b6c7a10"),
                            CountryId = new Guid("31313cfc-92f3-408a-ad20-7a109b66e7c8"),
                            Name = "Beijing"
                        },
                        new
                        {
                            Id = new Guid("4ec13ea6-7778-4db2-be1b-d2d5a485ec26"),
                            CountryId = new Guid("aa13becc-1f9f-46f3-9d71-7c6d5a68cf91"),
                            Name = "Sydney"
                        },
                        new
                        {
                            Id = new Guid("1a738e20-acf3-4fd4-b403-cfa5f5bdc99a"),
                            CountryId = new Guid("bfb2d56c-f6c5-44c2-b788-a7abd4beb1a9"),
                            Name = "Toronto"
                        },
                        new
                        {
                            Id = new Guid("5f4f38f0-e8e8-4477-82d4-b24e40d707a8"),
                            CountryId = new Guid("4d61d77f-f475-470a-90d3-f7c92af95e00"),
                            Name = "Mumbai"
                        },
                        new
                        {
                            Id = new Guid("4e81c4a9-5b79-497d-a518-85c652c48fc4"),
                            CountryId = new Guid("c4ee01ea-7396-41bb-85fb-157f4139d71a"),
                            Name = "Cape Town"
                        },
                        new
                        {
                            Id = new Guid("d16ec04b-693d-4f36-814e-612e66c33c88"),
                            CountryId = new Guid("0f9d0c04-93d6-4070-9d58-63b42896ffb4"),
                            Name = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = new Guid("b5f77004-36ef-4d5d-9382-e5e5379c6b85"),
                            CountryId = new Guid("4029f4aa-a9dc-4463-af4f-0cb685d8c420"),
                            Name = "Moscow"
                        },
                        new
                        {
                            Id = new Guid("f3e40d2a-3abe-4939-9ffc-a10ec2caf126"),
                            CountryId = new Guid("1efbbe97-c438-40d2-84b2-426330b98f3c"),
                            Name = "Dubai"
                        },
                        new
                        {
                            Id = new Guid("d482ce69-2334-4a63-82f1-ca6863e053b0"),
                            CountryId = new Guid("62e0dd7c-ff47-4f62-a63d-075dc6b49320"),
                            Name = "Stockholm"
                        },
                        new
                        {
                            Id = new Guid("5a4d5777-6a05-4a87-b533-c263ce5f0c66"),
                            CountryId = new Guid("589128f9-3259-4cfb-96e9-8f45996fa396"),
                            Name = "Seoul"
                        },
                        new
                        {
                            Id = new Guid("e4d10339-3680-4f89-b468-ff67723de51f"),
                            CountryId = new Guid("87ecaa49-f347-46e4-a1c3-02ed7663bb03"),
                            Name = "Mexico City"
                        },
                        new
                        {
                            Id = new Guid("d7d0760f-733e-456c-be28-381010760b19"),
                            CountryId = new Guid("46357de9-5c2a-48fb-885e-9dc1e599006e"),
                            Name = "Amsterdam"
                        },
                        new
                        {
                            Id = new Guid("f51a0d31-8043-4fdf-82bc-27c661586b5e"),
                            CountryId = new Guid("833aecc4-85e5-4859-85ee-cc2e840bb303"),
                            Name = "Oslo"
                        },
                        new
                        {
                            Id = new Guid("ba89b05e-d6ce-491e-b7c9-de93fc966026"),
                            CountryId = new Guid("da8338d1-4f2d-41d4-8824-bf8a6f5f47d7"),
                            Name = "Hanoi"
                        },
                        new
                        {
                            Id = new Guid("b72f3856-c14f-4236-871a-9b6fd65dfb7d"),
                            CountryId = new Guid("a4a95dc3-b9ed-4df4-903b-0bf45c142417"),
                            Name = "Bangkok"
                        },
                        new
                        {
                            Id = new Guid("1c966435-41c0-493d-9a03-473b73ae65e3"),
                            CountryId = new Guid("4ce32c13-50ac-4baf-be28-2fbb5df2f289"),
                            Name = "Istanbul"
                        },
                        new
                        {
                            Id = new Guid("b0839cad-30df-4c7d-b6a0-d66d2d723c08"),
                            CountryId = new Guid("aabcafe9-7833-413d-977b-0c0924783148"),
                            Name = "Buenos Aires"
                        },
                        new
                        {
                            Id = new Guid("d1bffbdc-2859-44e7-be6e-e1427848134d"),
                            CountryId = new Guid("b03f6cac-67cc-4b53-a1a2-4663460e3809"),
                            Name = "Rome"
                        },
                        new
                        {
                            Id = new Guid("8dd78fac-c7dd-44ee-8127-e8c1ea6228aa"),
                            CountryId = new Guid("ff57aa9a-8b92-498f-bc32-07bf52cf2965"),
                            Name = "Cairo"
                        },
                        new
                        {
                            Id = new Guid("a7d55187-d5a8-469c-b0df-61f4f002ef4b"),
                            CountryId = new Guid("e94a3deb-7432-4500-91a0-856d70438f18"),
                            Name = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("3f99161e-9942-4bd6-ade4-26fd3e3d9bad"),
                            CountryId = new Guid("ca23f9e6-2c1a-44ea-8207-fa36c9880365"),
                            Name = "Auckland"
                        },
                        new
                        {
                            Id = new Guid("bb9266fd-d80e-49bb-97d0-2dae374e2d26"),
                            CountryId = new Guid("90da958f-8edc-4ebe-874d-059b9f4f6a42"),
                            Name = "Nairobi"
                        },
                        new
                        {
                            Id = new Guid("735bb26b-b86a-4894-b9bc-941f13cbbc93"),
                            CountryId = new Guid("f8648b59-176b-4750-9d1c-f36bc2fe88ec"),
                            Name = "Barcelona"
                        },
                        new
                        {
                            Id = new Guid("08e0cfb3-2bf4-483f-9b98-c9ced3f330eb"),
                            CountryId = new Guid("997a44d8-0934-48a6-9e95-1d9ae837a087"),
                            Name = "Athens"
                        },
                        new
                        {
                            Id = new Guid("3a8b727f-d280-4858-b183-c5626c9ede64"),
                            CountryId = new Guid("308f66fa-f4be-429b-a0ce-8a152b4e5927"),
                            Name = "Dublin"
                        },
                        new
                        {
                            Id = new Guid("f0ca1380-b1e3-4c03-b297-2dd6afc5cd9c"),
                            CountryId = new Guid("b3a3f6dd-34b6-48b5-b463-d89eee98043d"),
                            Name = "Zurich"
                        },
                        new
                        {
                            Id = new Guid("a989dc51-fa8c-4ecd-9009-80d6776f2caf"),
                            CountryId = new Guid("9792f174-3ab1-4c4d-a29d-ec2e4fbdc25b"),
                            Name = "Singapore"
                        },
                        new
                        {
                            Id = new Guid("6cb812cb-bc9c-40e1-9169-559bce14e699"),
                            CountryId = new Guid("98218ff2-df6b-4653-be16-20f2070ee3d8"),
                            Name = "Vienna"
                        },
                        new
                        {
                            Id = new Guid("a1e5cf9f-b565-4b61-b857-84e02d793ea9"),
                            CountryId = new Guid("31313cfc-92f3-408a-ad20-7a109b66e7c8"),
                            Name = "Hong Kong"
                        },
                        new
                        {
                            Id = new Guid("dadbdf0b-f358-4759-bc03-f99238f4752e"),
                            CountryId = new Guid("e7af8513-68f3-404d-b1c9-d703ce6c3cab"),
                            Name = "Copenhagen"
                        },
                        new
                        {
                            Id = new Guid("67f553fa-5bc9-4a8b-ab41-e6f5cc17c4c1"),
                            CountryId = new Guid("5d93e087-1aa0-40ad-8e6e-68133ddd835e"),
                            Name = "Lisbon"
                        },
                        new
                        {
                            Id = new Guid("4d787b6d-e475-45a3-bb83-bb7c301240dc"),
                            CountryId = new Guid("d7704069-7b5c-4330-904d-a7b96d0de365"),
                            Name = "Warsaw"
                        },
                        new
                        {
                            Id = new Guid("7f8b6271-4a05-44e7-a138-a8ef8eaab14d"),
                            CountryId = new Guid("547732b0-5335-4742-9181-9b15817fe56d"),
                            Name = "Prague"
                        },
                        new
                        {
                            Id = new Guid("bd25997b-cab7-4672-b327-dd12f47e389e"),
                            CountryId = new Guid("7c0b3044-2382-449f-a603-b80e5a5fc74f"),
                            Name = "Budapest"
                        },
                        new
                        {
                            Id = new Guid("e02a2bfe-6a10-4c7c-8594-60f2040ef84b"),
                            CountryId = new Guid("8041ff0a-7bdd-4340-a349-7b0417210e7c"),
                            Name = "Brussels"
                        },
                        new
                        {
                            Id = new Guid("cdd77fa2-c2e7-4fbd-a305-019d72230f0c"),
                            CountryId = new Guid("2db178c1-c424-4d8c-861d-09911bbba51e"),
                            Name = "Helsinki"
                        });
                });

            modelBuilder.Entity("SmartHome.Data.Entities.CountryEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Countries");

                    b.HasData(
                        new
                        {
                            Id = new Guid("21a6c69f-50f5-454e-9d7d-5f72eeb45ee8"),
                            Name = "USA"
                        },
                        new
                        {
                            Id = new Guid("6a5cf285-3793-4cce-a155-3cfdef88e4ff"),
                            Name = "UK"
                        },
                        new
                        {
                            Id = new Guid("3a77c84f-8875-4132-9fae-c07f03432435"),
                            Name = "France"
                        },
                        new
                        {
                            Id = new Guid("b7638789-3bea-4e28-b8bc-da6015bfa2b3"),
                            Name = "Germany"
                        },
                        new
                        {
                            Id = new Guid("cb187c9a-7ab2-4862-b209-19cbb2f0c390"),
                            Name = "Japan"
                        },
                        new
                        {
                            Id = new Guid("31313cfc-92f3-408a-ad20-7a109b66e7c8"),
                            Name = "China"
                        },
                        new
                        {
                            Id = new Guid("aa13becc-1f9f-46f3-9d71-7c6d5a68cf91"),
                            Name = "Australia"
                        },
                        new
                        {
                            Id = new Guid("bfb2d56c-f6c5-44c2-b788-a7abd4beb1a9"),
                            Name = "Canada"
                        },
                        new
                        {
                            Id = new Guid("4d61d77f-f475-470a-90d3-f7c92af95e00"),
                            Name = "India"
                        },
                        new
                        {
                            Id = new Guid("c4ee01ea-7396-41bb-85fb-157f4139d71a"),
                            Name = "South Africa"
                        },
                        new
                        {
                            Id = new Guid("0f9d0c04-93d6-4070-9d58-63b42896ffb4"),
                            Name = "Brazil"
                        },
                        new
                        {
                            Id = new Guid("4029f4aa-a9dc-4463-af4f-0cb685d8c420"),
                            Name = "Russia"
                        },
                        new
                        {
                            Id = new Guid("1efbbe97-c438-40d2-84b2-426330b98f3c"),
                            Name = "UAE"
                        },
                        new
                        {
                            Id = new Guid("62e0dd7c-ff47-4f62-a63d-075dc6b49320"),
                            Name = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("589128f9-3259-4cfb-96e9-8f45996fa396"),
                            Name = "South Korea"
                        },
                        new
                        {
                            Id = new Guid("87ecaa49-f347-46e4-a1c3-02ed7663bb03"),
                            Name = "Mexico"
                        },
                        new
                        {
                            Id = new Guid("46357de9-5c2a-48fb-885e-9dc1e599006e"),
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = new Guid("833aecc4-85e5-4859-85ee-cc2e840bb303"),
                            Name = "Norway"
                        },
                        new
                        {
                            Id = new Guid("da8338d1-4f2d-41d4-8824-bf8a6f5f47d7"),
                            Name = "Vietnam"
                        },
                        new
                        {
                            Id = new Guid("a4a95dc3-b9ed-4df4-903b-0bf45c142417"),
                            Name = "Thailand"
                        },
                        new
                        {
                            Id = new Guid("4ce32c13-50ac-4baf-be28-2fbb5df2f289"),
                            Name = "Turkey"
                        },
                        new
                        {
                            Id = new Guid("aabcafe9-7833-413d-977b-0c0924783148"),
                            Name = "Argentina"
                        },
                        new
                        {
                            Id = new Guid("b03f6cac-67cc-4b53-a1a2-4663460e3809"),
                            Name = "Italy"
                        },
                        new
                        {
                            Id = new Guid("ff57aa9a-8b92-498f-bc32-07bf52cf2965"),
                            Name = "Egypt"
                        },
                        new
                        {
                            Id = new Guid("e94a3deb-7432-4500-91a0-856d70438f18"),
                            Name = "Nigeria"
                        },
                        new
                        {
                            Id = new Guid("ca23f9e6-2c1a-44ea-8207-fa36c9880365"),
                            Name = "New Zealand"
                        },
                        new
                        {
                            Id = new Guid("90da958f-8edc-4ebe-874d-059b9f4f6a42"),
                            Name = "Kenya"
                        },
                        new
                        {
                            Id = new Guid("f8648b59-176b-4750-9d1c-f36bc2fe88ec"),
                            Name = "Spain"
                        },
                        new
                        {
                            Id = new Guid("997a44d8-0934-48a6-9e95-1d9ae837a087"),
                            Name = "Greece"
                        },
                        new
                        {
                            Id = new Guid("308f66fa-f4be-429b-a0ce-8a152b4e5927"),
                            Name = "Ireland"
                        },
                        new
                        {
                            Id = new Guid("b3a3f6dd-34b6-48b5-b463-d89eee98043d"),
                            Name = "Switzerland"
                        },
                        new
                        {
                            Id = new Guid("9792f174-3ab1-4c4d-a29d-ec2e4fbdc25b"),
                            Name = "Singapore"
                        },
                        new
                        {
                            Id = new Guid("98218ff2-df6b-4653-be16-20f2070ee3d8"),
                            Name = "Austria"
                        },
                        new
                        {
                            Id = new Guid("e7af8513-68f3-404d-b1c9-d703ce6c3cab"),
                            Name = "Denmark"
                        },
                        new
                        {
                            Id = new Guid("5d93e087-1aa0-40ad-8e6e-68133ddd835e"),
                            Name = "Portugal"
                        },
                        new
                        {
                            Id = new Guid("d7704069-7b5c-4330-904d-a7b96d0de365"),
                            Name = "Poland"
                        },
                        new
                        {
                            Id = new Guid("547732b0-5335-4742-9181-9b15817fe56d"),
                            Name = "Czech Republic"
                        },
                        new
                        {
                            Id = new Guid("7c0b3044-2382-449f-a603-b80e5a5fc74f"),
                            Name = "Hungary"
                        },
                        new
                        {
                            Id = new Guid("8041ff0a-7bdd-4340-a349-7b0417210e7c"),
                            Name = "Belgium"
                        },
                        new
                        {
                            Id = new Guid("2db178c1-c424-4d8c-861d-09911bbba51e"),
                            Name = "Finland"
                        });
                });

            modelBuilder.Entity("SmartHome.Data.Entities.EnvironmentalConditionsSensorEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Connection")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("DeviceStatus")
                        .HasColumnType("integer");

                    b.Property<int>("DeviceType")
                        .HasColumnType("integer");

                    b.Property<float>("EnergySpending")
                        .HasColumnType("real");

                    b.Property<int>("PowerSupply")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("EnvironmentalConditionsSensors");
                });

            modelBuilder.Entity("SmartHome.Data.Entities.PropertyEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<double>("AreaSquareMeters")
                        .HasColumnType("double precision");

                    b.Property<Guid>("CityId")
                        .HasColumnType("uuid");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<bool>("IsActive")
                        .HasColumnType("boolean");

                    b.Property<int>("NumberOfFloors")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.ToTable("Properties");
                });

            modelBuilder.Entity("SmartHome.Data.Entities.UserEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("SmartHome.Data.Entities.CityEntity", b =>
                {
                    b.HasOne("SmartHome.Data.Entities.CountryEntity", "Country")
                        .WithMany("Cities")
                        .HasForeignKey("CountryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Country");
                });

            modelBuilder.Entity("SmartHome.Data.Entities.EnvironmentalConditionsSensorEntity", b =>
                {
                    b.HasOne("SmartHome.Data.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartHome.Data.Entities.PropertyEntity", b =>
                {
                    b.HasOne("SmartHome.Data.Entities.CityEntity", "City")
                        .WithMany("Properties")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
                });

            modelBuilder.Entity("SmartHome.Data.Entities.UserEntity", b =>
                {
                    b.HasOne("SmartHome.Data.Entities.UserEntity", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("SmartHome.Data.Entities.CityEntity", b =>
                {
                    b.Navigation("Properties");
                });

            modelBuilder.Entity("SmartHome.Data.Entities.CountryEntity", b =>
                {
                    b.Navigation("Cities");
                });
#pragma warning restore 612, 618
        }
    }
}
