﻿// <auto-generated />
using System;
using Dream_Reserve_Back.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Dream_Reserve_Back.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseCollation("utf8_general_ci")
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.HasCharSet(modelBuilder, "utf8");
            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("Dream_Reserve_Back.Models.DocumentType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Abbreviation")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("varchar(10)")
                        .HasColumnName("abbreviation");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Abbreviation" }, "abreviation_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Id" }, "document_id")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "document_name_UNIQUE")
                        .IsUnique();

                    b.ToTable("document_types", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Flight", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime")
                        .HasColumnName("date");

                    b.Property<string>("Destiny")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("destiny");

                    b.Property<string>("Duration")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("duration");

                    b.Property<int>("FlightTypeId")
                        .HasColumnType("int(11)")
                        .HasColumnName("flight_type_id");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("name");

                    b.Property<string>("Origin")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("origin");

                    b.Property<string>("Seat")
                        .IsRequired()
                        .HasMaxLength(5)
                        .HasColumnType("varchar(5)")
                        .HasColumnName("seat");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex("FlightTypeId");

                    b.HasIndex(new[] { "Id" }, "flight_id")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "number_UNIQUE")
                        .IsUnique();

                    b.ToTable("flights", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.FlightType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Description" }, "description_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Id" }, "flight_type_id")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "flight_type_name_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Price" }, "flight_type_price_UNIQUE")
                        .IsUnique();

                    b.ToTable("flight_types", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Food", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Cuantity")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("cuantity");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<decimal>("Price")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("price");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Cuantity" }, "cuantity_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Id" }, "food_id")
                        .IsUnique();

                    b.ToTable("foods", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Hotel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("address");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("city");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("email");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(35)
                        .HasColumnType("varchar(35)")
                        .HasColumnName("name");

                    b.Property<int>("Nit")
                        .HasColumnType("int(15)")
                        .HasColumnName("nit");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("phone");

                    b.Property<int>("Rating")
                        .HasColumnType("int(11)")
                        .HasColumnName("rating");

                    b.Property<string>("UrlImages")
                        .IsRequired()
                        .HasColumnType("mediumtext")
                        .HasColumnName("urlImages");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Address" }, "address_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "email_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Id" }, "hotel_id")
                        .IsUnique();

                    b.HasIndex(new[] { "Name" }, "name_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Nit" }, "nit_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Phone" }, "phone_UNIQUE")
                        .IsUnique();

                    b.ToTable("hotels", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Person", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DocumentNumber")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("document_number");

                    b.Property<int>("DocumentTypeId")
                        .HasColumnType("int(11)")
                        .HasColumnName("document_type_id");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("email");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("last_name");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("varchar(25)")
                        .HasColumnName("name");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("password");

                    b.Property<string>("UrlAvatar")
                        .IsRequired()
                        .HasColumnType("mediumtext")
                        .HasColumnName("urlAvatar");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "DocumentNumber" }, "document_number_UNIQUE")
                        .IsUnique();

                    b.HasIndex(new[] { "Email" }, "email_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("email_UNIQUE1");

                    b.HasIndex(new[] { "DocumentTypeId" }, "fk_person_document_type1_idx");

                    b.HasIndex(new[] { "Id" }, "id")
                        .IsUnique();

                    b.ToTable("people", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Reserve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CheckIn")
                        .HasColumnType("datetime")
                        .HasColumnName("check_in");

                    b.Property<DateTime>("CheckOut")
                        .HasColumnType("datetime")
                        .HasColumnName("check_out");

                    b.Property<int>("FlightId")
                        .HasColumnType("int(11)")
                        .HasColumnName("flight_id");

                    b.Property<int>("FoodId")
                        .HasColumnType("int(11)")
                        .HasColumnName("food_id");

                    b.Property<int>("PeopleCuantity")
                        .HasColumnType("int(3)")
                        .HasColumnName("people_cuantity");

                    b.Property<int>("PersonId")
                        .HasColumnType("int(11)")
                        .HasColumnName("person_id");

                    b.Property<int>("RoomId")
                        .HasColumnType("int(11)")
                        .HasColumnName("room_id");

                    b.Property<decimal>("Total")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("total");

                    b.Property<int>("TourId")
                        .HasColumnType("int(11)")
                        .HasColumnName("tour_id");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "PersonId" }, "fk_reserv_person1_idx");

                    b.HasIndex(new[] { "RoomId" }, "fk_reserv_room1_idx");

                    b.HasIndex(new[] { "FlightId" }, "fk_reserve_flight1_idx");

                    b.HasIndex(new[] { "FoodId" }, "fk_reserve_food1_idx");

                    b.HasIndex(new[] { "TourId" }, "fk_reserve_tour1_idx");

                    b.HasIndex(new[] { "Id" }, "reserv_id")
                        .IsUnique();

                    b.ToTable("reserves", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Review", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("createdAt");

                    b.Property<string>("Message")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("message");

                    b.Property<int>("PersonId")
                        .HasColumnType("int(11)")
                        .HasColumnName("person_id");

                    b.Property<int>("Rating")
                        .HasColumnType("int")
                        .HasColumnName("rating");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("title");

                    b.HasKey("Id");

                    b.HasIndex("PersonId");

                    b.ToTable("reviews", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Room", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<int>("HotelId")
                        .HasColumnType("int(11)")
                        .HasColumnName("hotel_id");

                    b.Property<int>("PeopleCapacity")
                        .HasColumnType("int(3)")
                        .HasColumnName("people_capacity");

                    b.Property<decimal>("Price")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("price");

                    b.Property<int>("RoomNumber")
                        .HasColumnType("int(11)")
                        .HasColumnName("room_number");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("status");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("type");

                    b.Property<string>("UrlImages")
                        .IsRequired()
                        .HasColumnType("mediumtext")
                        .HasColumnName("urlImages");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "HotelId" }, "fk_room_hotel1_idx");

                    b.HasIndex(new[] { "Id" }, "room_id")
                        .IsUnique();

                    b.ToTable("rooms", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Tour", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int(11)")
                        .HasColumnName("id");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .IsRequired()
                        .HasMaxLength(45)
                        .HasColumnType("varchar(45)")
                        .HasColumnName("category");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("name");

                    b.Property<decimal>("Price")
                        .HasPrecision(10)
                        .HasColumnType("decimal(10)")
                        .HasColumnName("price");

                    b.Property<string>("UrlImages")
                        .IsRequired()
                        .HasColumnType("mediumtext")
                        .HasColumnName("urlImages");

                    b.HasKey("Id")
                        .HasName("PRIMARY");

                    b.HasIndex(new[] { "Name" }, "name_UNIQUE")
                        .IsUnique()
                        .HasDatabaseName("name_UNIQUE1");

                    b.HasIndex(new[] { "Id" }, "tour_id")
                        .IsUnique();

                    b.ToTable("tours", (string)null);

                    MySqlEntityTypeBuilderExtensions.HasCharSet(b, "utf8mb4");
                    MySqlEntityTypeBuilderExtensions.UseCollation(b, "utf8mb4_0900_ai_ci");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Flight", b =>
                {
                    b.HasOne("Dream_Reserve_Back.Models.FlightType", "FlightType")
                        .WithMany("Flights")
                        .HasForeignKey("FlightTypeId")
                        .IsRequired()
                        .HasConstraintName("fk_flight_flight_type1");

                    b.Navigation("FlightType");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Person", b =>
                {
                    b.HasOne("Dream_Reserve_Back.Models.DocumentType", "DocumentType")
                        .WithMany("People")
                        .HasForeignKey("DocumentTypeId")
                        .IsRequired()
                        .HasConstraintName("fk_person_document_type1");

                    b.Navigation("DocumentType");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Reserve", b =>
                {
                    b.HasOne("Dream_Reserve_Back.Models.Flight", "Flight")
                        .WithMany("Reserves")
                        .HasForeignKey("FlightId")
                        .IsRequired()
                        .HasConstraintName("fk_reserve_flight1");

                    b.HasOne("Dream_Reserve_Back.Models.Food", "Food")
                        .WithMany("Reserves")
                        .HasForeignKey("FoodId")
                        .IsRequired()
                        .HasConstraintName("fk_reserve_food1");

                    b.HasOne("Dream_Reserve_Back.Models.Person", "Person")
                        .WithMany("Reserves")
                        .HasForeignKey("PersonId")
                        .IsRequired()
                        .HasConstraintName("fk_reserv_person1");

                    b.HasOne("Dream_Reserve_Back.Models.Room", "Room")
                        .WithMany("Reserves")
                        .HasForeignKey("RoomId")
                        .IsRequired()
                        .HasConstraintName("fk_reserv_room1");

                    b.HasOne("Dream_Reserve_Back.Models.Tour", "Tour")
                        .WithMany("Reserves")
                        .HasForeignKey("TourId")
                        .IsRequired()
                        .HasConstraintName("fk_reserve_tour1");

                    b.Navigation("Flight");

                    b.Navigation("Food");

                    b.Navigation("Person");

                    b.Navigation("Room");

                    b.Navigation("Tour");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Review", b =>
                {
                    b.HasOne("Dream_Reserve_Back.Models.Person", "Person")
                        .WithMany("Reviews")
                        .HasForeignKey("PersonId")
                        .IsRequired()
                        .HasConstraintName("fk_review_person1");

                    b.Navigation("Person");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Room", b =>
                {
                    b.HasOne("Dream_Reserve_Back.Models.Hotel", "Hotel")
                        .WithMany("Rooms")
                        .HasForeignKey("HotelId")
                        .IsRequired()
                        .HasConstraintName("fk_room_hotel1");

                    b.Navigation("Hotel");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.DocumentType", b =>
                {
                    b.Navigation("People");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Flight", b =>
                {
                    b.Navigation("Reserves");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.FlightType", b =>
                {
                    b.Navigation("Flights");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Food", b =>
                {
                    b.Navigation("Reserves");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Hotel", b =>
                {
                    b.Navigation("Rooms");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Person", b =>
                {
                    b.Navigation("Reserves");

                    b.Navigation("Reviews");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Room", b =>
                {
                    b.Navigation("Reserves");
                });

            modelBuilder.Entity("Dream_Reserve_Back.Models.Tour", b =>
                {
                    b.Navigation("Reserves");
                });
#pragma warning restore 612, 618
        }
    }
}
