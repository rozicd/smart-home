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
    [Migration("20231117194346_profilePictureColumn")]
    partial class profilePictureColumn
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
                            Id = new Guid("5b5ae722-aa14-4516-bccc-b2de7ffa1749"),
                            CountryId = new Guid("beb98654-aa57-4b47-93b0-918b35288aad"),
                            Name = "New York"
                        },
                        new
                        {
                            Id = new Guid("c783ac1b-5d92-4c06-9348-077c4088a870"),
                            CountryId = new Guid("beb98654-aa57-4b47-93b0-918b35288aad"),
                            Name = "Los Angeles"
                        },
                        new
                        {
                            Id = new Guid("d0a379b8-b53e-4204-b2ff-3b7054d45b32"),
                            CountryId = new Guid("beb98654-aa57-4b47-93b0-918b35288aad"),
                            Name = "Chicago"
                        },
                        new
                        {
                            Id = new Guid("fee0c8cf-d294-41cf-abe7-6014d06deac8"),
                            CountryId = new Guid("26a53003-a168-4b4a-9206-44f5ae0beed4"),
                            Name = "London"
                        },
                        new
                        {
                            Id = new Guid("5c818915-1946-4172-9614-e3065f37a516"),
                            CountryId = new Guid("2c71f8ef-959c-4167-af71-56f9131b2796"),
                            Name = "Paris"
                        },
                        new
                        {
                            Id = new Guid("d30089bb-e39a-477b-b2cb-79584346aa4e"),
                            CountryId = new Guid("9bc74ec4-1259-415a-80a8-669b13e2e25c"),
                            Name = "Berlin"
                        },
                        new
                        {
                            Id = new Guid("02fe284e-7368-46a4-b1f0-335f994c2124"),
                            CountryId = new Guid("a29d739a-4748-4d2a-b68c-8b947181e967"),
                            Name = "Tokyo"
                        },
                        new
                        {
                            Id = new Guid("7a05af95-cdfd-4bec-910f-a1d6c7fc8965"),
                            CountryId = new Guid("faa28d76-2b51-4d26-b682-3cb38244531c"),
                            Name = "Beijing"
                        },
                        new
                        {
                            Id = new Guid("a95001db-afbf-4945-aa9b-0c8c7c89e908"),
                            CountryId = new Guid("df5ef112-8534-4796-b40b-c1dc9b2f13a1"),
                            Name = "Sydney"
                        },
                        new
                        {
                            Id = new Guid("f9a4aee8-41ae-4069-9abe-00fc3678a63a"),
                            CountryId = new Guid("5095770c-85e7-4ece-82f7-b5694082a5cf"),
                            Name = "Toronto"
                        },
                        new
                        {
                            Id = new Guid("65667068-461a-4069-813b-46676553b2b3"),
                            CountryId = new Guid("1591ac6b-9ce6-4f5c-b6a7-01ed9a8a7dfc"),
                            Name = "Mumbai"
                        },
                        new
                        {
                            Id = new Guid("02b36421-bc1d-4879-acef-150f0f5516a9"),
                            CountryId = new Guid("d1a73aa0-b528-4e0e-8d0a-3fc0e9d1d329"),
                            Name = "Cape Town"
                        },
                        new
                        {
                            Id = new Guid("09fdd01b-a3ab-4026-ab82-d78adc6ba1f6"),
                            CountryId = new Guid("6d5ef5ba-5415-4301-ad7c-b6e958b47119"),
                            Name = "Rio de Janeiro"
                        },
                        new
                        {
                            Id = new Guid("691f7f5a-9b5d-4af4-870d-ec9b08055fec"),
                            CountryId = new Guid("b462e254-3326-4520-b1a3-4be7098b4176"),
                            Name = "Moscow"
                        },
                        new
                        {
                            Id = new Guid("ed5f043d-c886-4adb-adff-03da3e876387"),
                            CountryId = new Guid("57464541-19e1-4154-9708-d1b972d4f6b2"),
                            Name = "Dubai"
                        },
                        new
                        {
                            Id = new Guid("2f9d5ae7-a194-4cf5-b3d0-25e45889690d"),
                            CountryId = new Guid("92bf8acd-526a-4b3f-bed6-19422b3c8d10"),
                            Name = "Stockholm"
                        },
                        new
                        {
                            Id = new Guid("acba009a-90a9-482a-8d2f-cecc1a81d99d"),
                            CountryId = new Guid("0f61aed8-8d06-48c6-b1a6-75743a4282e6"),
                            Name = "Seoul"
                        },
                        new
                        {
                            Id = new Guid("4eeef9ea-dd09-4a14-88df-fb3f048e914f"),
                            CountryId = new Guid("26389955-061e-44b5-a40e-a2c128feaa08"),
                            Name = "Mexico City"
                        },
                        new
                        {
                            Id = new Guid("e49a5f00-044f-4dc8-ad9e-6494309fcc22"),
                            CountryId = new Guid("834d28db-9384-487d-bd23-0da300d68642"),
                            Name = "Amsterdam"
                        },
                        new
                        {
                            Id = new Guid("14933624-ab93-4d5a-a26e-da2805380e65"),
                            CountryId = new Guid("2b497444-e852-49d5-9d1d-20329e629855"),
                            Name = "Oslo"
                        },
                        new
                        {
                            Id = new Guid("15426833-7852-4c95-be2c-76ebb7382f52"),
                            CountryId = new Guid("20115ddb-de3c-4638-9e02-5093111431fd"),
                            Name = "Hanoi"
                        },
                        new
                        {
                            Id = new Guid("05e27727-6846-4375-89df-24915df0853a"),
                            CountryId = new Guid("b936ed81-502d-4daa-bf0b-19c50afb21e0"),
                            Name = "Bangkok"
                        },
                        new
                        {
                            Id = new Guid("bf6547f3-8441-4025-9fcf-9bc0eb8244a4"),
                            CountryId = new Guid("99cdc8a7-c660-41b0-b2eb-9e831cf0ffa7"),
                            Name = "Istanbul"
                        },
                        new
                        {
                            Id = new Guid("560b3623-5dda-480e-9abd-bf67fc513670"),
                            CountryId = new Guid("bb1097f1-5a82-4e6c-b82e-5b0aac7ce56a"),
                            Name = "Buenos Aires"
                        },
                        new
                        {
                            Id = new Guid("9ae82c65-0875-4dfe-9786-3ccb2818d51e"),
                            CountryId = new Guid("05cd71ce-cdfd-44f7-87ce-837d80d9c380"),
                            Name = "Rome"
                        },
                        new
                        {
                            Id = new Guid("48ff5088-5395-4984-9fce-d6082b3b7787"),
                            CountryId = new Guid("735b7bf5-f71e-46f5-b955-abe57cdc052f"),
                            Name = "Cairo"
                        },
                        new
                        {
                            Id = new Guid("79b08051-e923-4659-8969-8547308a52ce"),
                            CountryId = new Guid("b9772749-0de3-42a1-a485-5d50bb7a839c"),
                            Name = "Lagos"
                        },
                        new
                        {
                            Id = new Guid("bbe10e4a-28e7-4c44-be41-3cdcf8a8a986"),
                            CountryId = new Guid("e7777953-bbe1-467e-8d48-f3a0d749fa0b"),
                            Name = "Auckland"
                        },
                        new
                        {
                            Id = new Guid("914c1455-592d-4b49-b868-a5936d57c7a7"),
                            CountryId = new Guid("908a45cf-2690-4d19-82d1-aaf28521475f"),
                            Name = "Nairobi"
                        },
                        new
                        {
                            Id = new Guid("b509b5d3-05c7-4b11-a779-2ce3f5003cef"),
                            CountryId = new Guid("6d41318f-0907-4fe1-8ce3-cf6a072827fb"),
                            Name = "Barcelona"
                        },
                        new
                        {
                            Id = new Guid("2887c593-59f8-4f34-a0d6-459894520a8d"),
                            CountryId = new Guid("f664d8b4-203e-472c-8ea2-8f52f50bb877"),
                            Name = "Athens"
                        },
                        new
                        {
                            Id = new Guid("7e51f86e-0715-4596-9ca1-b099843951d3"),
                            CountryId = new Guid("40a13bd4-a01f-4f1d-a6b2-0c0568c5f72b"),
                            Name = "Dublin"
                        },
                        new
                        {
                            Id = new Guid("f8693fdb-f610-4046-9f2b-b60a3316c254"),
                            CountryId = new Guid("f071489b-f61f-4cbf-a788-611ccc8499a9"),
                            Name = "Zurich"
                        },
                        new
                        {
                            Id = new Guid("aa1bb05a-7cdb-4bbf-9155-e96125799ea6"),
                            CountryId = new Guid("192a7518-b2a2-4ab7-9963-b7dfb9acc100"),
                            Name = "Singapore"
                        },
                        new
                        {
                            Id = new Guid("d053cd5a-9ef0-4eb2-a6bd-809b4fa0aa39"),
                            CountryId = new Guid("a8c7f969-4882-44bd-b914-9ebb4af2e8fe"),
                            Name = "Vienna"
                        },
                        new
                        {
                            Id = new Guid("86da552c-2772-4055-bd34-dfd5f76a0110"),
                            CountryId = new Guid("faa28d76-2b51-4d26-b682-3cb38244531c"),
                            Name = "Hong Kong"
                        },
                        new
                        {
                            Id = new Guid("175098f4-ecb1-4c91-baf8-5fa067c9a116"),
                            CountryId = new Guid("a103c63c-3373-4682-865f-74bd9b8e77c0"),
                            Name = "Copenhagen"
                        },
                        new
                        {
                            Id = new Guid("ffa9f8d9-351b-4ebc-93c0-4e61ac338f71"),
                            CountryId = new Guid("538e42a2-41a0-4c9d-9e62-38dd88139553"),
                            Name = "Lisbon"
                        },
                        new
                        {
                            Id = new Guid("d3bf2ea7-ffce-40f8-a135-95fe546c9afb"),
                            CountryId = new Guid("6d5a367c-6351-4e4a-9d4e-416f939a6374"),
                            Name = "Warsaw"
                        },
                        new
                        {
                            Id = new Guid("24b21c81-2807-4de4-ba47-bf7d70e99580"),
                            CountryId = new Guid("bb05bd11-e191-4bed-83d4-75ff9319242c"),
                            Name = "Prague"
                        },
                        new
                        {
                            Id = new Guid("28fa1f9e-7ad7-4968-bac9-b18921a8df8a"),
                            CountryId = new Guid("2c3924b2-0b40-448e-8d2f-6975d3730dec"),
                            Name = "Budapest"
                        },
                        new
                        {
                            Id = new Guid("285b9b07-111b-4f16-b8a0-7067b685c47d"),
                            CountryId = new Guid("af562313-2923-4cc8-ba57-8ba9530b43f8"),
                            Name = "Brussels"
                        },
                        new
                        {
                            Id = new Guid("7627374b-534f-41ca-b99a-6b135bc8ee2d"),
                            CountryId = new Guid("272e0800-c2a9-4408-93bd-e902890a3a59"),
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
                            Id = new Guid("beb98654-aa57-4b47-93b0-918b35288aad"),
                            Name = "USA"
                        },
                        new
                        {
                            Id = new Guid("26a53003-a168-4b4a-9206-44f5ae0beed4"),
                            Name = "UK"
                        },
                        new
                        {
                            Id = new Guid("2c71f8ef-959c-4167-af71-56f9131b2796"),
                            Name = "France"
                        },
                        new
                        {
                            Id = new Guid("9bc74ec4-1259-415a-80a8-669b13e2e25c"),
                            Name = "Germany"
                        },
                        new
                        {
                            Id = new Guid("a29d739a-4748-4d2a-b68c-8b947181e967"),
                            Name = "Japan"
                        },
                        new
                        {
                            Id = new Guid("faa28d76-2b51-4d26-b682-3cb38244531c"),
                            Name = "China"
                        },
                        new
                        {
                            Id = new Guid("df5ef112-8534-4796-b40b-c1dc9b2f13a1"),
                            Name = "Australia"
                        },
                        new
                        {
                            Id = new Guid("5095770c-85e7-4ece-82f7-b5694082a5cf"),
                            Name = "Canada"
                        },
                        new
                        {
                            Id = new Guid("1591ac6b-9ce6-4f5c-b6a7-01ed9a8a7dfc"),
                            Name = "India"
                        },
                        new
                        {
                            Id = new Guid("d1a73aa0-b528-4e0e-8d0a-3fc0e9d1d329"),
                            Name = "South Africa"
                        },
                        new
                        {
                            Id = new Guid("6d5ef5ba-5415-4301-ad7c-b6e958b47119"),
                            Name = "Brazil"
                        },
                        new
                        {
                            Id = new Guid("b462e254-3326-4520-b1a3-4be7098b4176"),
                            Name = "Russia"
                        },
                        new
                        {
                            Id = new Guid("57464541-19e1-4154-9708-d1b972d4f6b2"),
                            Name = "UAE"
                        },
                        new
                        {
                            Id = new Guid("92bf8acd-526a-4b3f-bed6-19422b3c8d10"),
                            Name = "Sweden"
                        },
                        new
                        {
                            Id = new Guid("0f61aed8-8d06-48c6-b1a6-75743a4282e6"),
                            Name = "South Korea"
                        },
                        new
                        {
                            Id = new Guid("26389955-061e-44b5-a40e-a2c128feaa08"),
                            Name = "Mexico"
                        },
                        new
                        {
                            Id = new Guid("834d28db-9384-487d-bd23-0da300d68642"),
                            Name = "Netherlands"
                        },
                        new
                        {
                            Id = new Guid("2b497444-e852-49d5-9d1d-20329e629855"),
                            Name = "Norway"
                        },
                        new
                        {
                            Id = new Guid("20115ddb-de3c-4638-9e02-5093111431fd"),
                            Name = "Vietnam"
                        },
                        new
                        {
                            Id = new Guid("b936ed81-502d-4daa-bf0b-19c50afb21e0"),
                            Name = "Thailand"
                        },
                        new
                        {
                            Id = new Guid("99cdc8a7-c660-41b0-b2eb-9e831cf0ffa7"),
                            Name = "Turkey"
                        },
                        new
                        {
                            Id = new Guid("bb1097f1-5a82-4e6c-b82e-5b0aac7ce56a"),
                            Name = "Argentina"
                        },
                        new
                        {
                            Id = new Guid("05cd71ce-cdfd-44f7-87ce-837d80d9c380"),
                            Name = "Italy"
                        },
                        new
                        {
                            Id = new Guid("735b7bf5-f71e-46f5-b955-abe57cdc052f"),
                            Name = "Egypt"
                        },
                        new
                        {
                            Id = new Guid("b9772749-0de3-42a1-a485-5d50bb7a839c"),
                            Name = "Nigeria"
                        },
                        new
                        {
                            Id = new Guid("e7777953-bbe1-467e-8d48-f3a0d749fa0b"),
                            Name = "New Zealand"
                        },
                        new
                        {
                            Id = new Guid("908a45cf-2690-4d19-82d1-aaf28521475f"),
                            Name = "Kenya"
                        },
                        new
                        {
                            Id = new Guid("6d41318f-0907-4fe1-8ce3-cf6a072827fb"),
                            Name = "Spain"
                        },
                        new
                        {
                            Id = new Guid("f664d8b4-203e-472c-8ea2-8f52f50bb877"),
                            Name = "Greece"
                        },
                        new
                        {
                            Id = new Guid("40a13bd4-a01f-4f1d-a6b2-0c0568c5f72b"),
                            Name = "Ireland"
                        },
                        new
                        {
                            Id = new Guid("f071489b-f61f-4cbf-a788-611ccc8499a9"),
                            Name = "Switzerland"
                        },
                        new
                        {
                            Id = new Guid("192a7518-b2a2-4ab7-9963-b7dfb9acc100"),
                            Name = "Singapore"
                        },
                        new
                        {
                            Id = new Guid("a8c7f969-4882-44bd-b914-9ebb4af2e8fe"),
                            Name = "Austria"
                        },
                        new
                        {
                            Id = new Guid("a103c63c-3373-4682-865f-74bd9b8e77c0"),
                            Name = "Denmark"
                        },
                        new
                        {
                            Id = new Guid("538e42a2-41a0-4c9d-9e62-38dd88139553"),
                            Name = "Portugal"
                        },
                        new
                        {
                            Id = new Guid("6d5a367c-6351-4e4a-9d4e-416f939a6374"),
                            Name = "Poland"
                        },
                        new
                        {
                            Id = new Guid("bb05bd11-e191-4bed-83d4-75ff9319242c"),
                            Name = "Czech Republic"
                        },
                        new
                        {
                            Id = new Guid("2c3924b2-0b40-448e-8d2f-6975d3730dec"),
                            Name = "Hungary"
                        },
                        new
                        {
                            Id = new Guid("af562313-2923-4cc8-ba57-8ba9530b43f8"),
                            Name = "Belgium"
                        },
                        new
                        {
                            Id = new Guid("272e0800-c2a9-4408-93bd-e902890a3a59"),
                            Name = "Finland"
                        });
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

                    b.Property<string>("ProfilePictureUrl")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Role")
                        .HasColumnType("integer");

                    b.Property<int>("Status")
                        .HasColumnType("integer");

                    b.HasKey("Id");

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

            modelBuilder.Entity("SmartHome.Data.Entities.PropertyEntity", b =>
                {
                    b.HasOne("SmartHome.Data.Entities.CityEntity", "City")
                        .WithMany("Properties")
                        .HasForeignKey("CityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("City");
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
