using System;
using System.Collections.Generic;
using Dream_Reserve_Back.Models;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Dream_Reserve_Back.Data;

public partial class ApplicationDbContext : DbContext
{
    public ApplicationDbContext()
    {
    }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Flight> Flights { get; set; }

    public virtual DbSet<Food> Foods { get; set; }

    public virtual DbSet<Hotel> Hotels { get; set; }

    public virtual DbSet<Person> People { get; set; }

    public virtual DbSet<Reserve> Reserves { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<Review> Reviews { get; set; }

    public virtual DbSet<FlightType> FlightTypes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("document_types")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Abbreviation, "abreviation_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "document_id").IsUnique();

            entity.HasIndex(e => e.Name, "document_name_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Abbreviation)
                .HasMaxLength(10)
                .HasColumnName("abbreviation");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("flights")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Id, "flight_id").IsUnique();

            entity.HasIndex(e => e.Name, "number_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
             entity.Property(e => e.FlightTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("flight_type_id");  
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Destiny)
                .HasMaxLength(45)
                .HasColumnName("destiny");
            entity.Property(e => e.Duration)
                .HasMaxLength(45)
                .HasColumnName("duration");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Origin)
                .HasMaxLength(45)
                .HasColumnName("origin");
            entity.Property(e => e.Seat)
                .HasMaxLength(5)
                .HasColumnName("seat");

             entity.HasOne(d => d.FlightType).WithMany(p => p.Flights)
                .HasForeignKey(d => d.FlightTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_flight_flight_type1");  
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("foods")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Cuantity, "cuantity_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "food_id").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cuantity)
                .HasMaxLength(25)
                .HasColumnName("cuantity");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hotels")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Address, "address_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "hotel_id").IsUnique();

            entity.HasIndex(e => e.Name, "name_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Nit, "nit_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Phone, "phone_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Address)
                .HasMaxLength(45)
                .HasColumnName("address");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(35)
                .HasColumnName("name");
            entity.Property(e => e.Nit)
                .HasColumnType("int(15)")
                .HasColumnName("nit");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasColumnName("phone");
            entity.Property(e => e.UrlImages)
                .HasColumnType("mediumtext")
                .HasColumnName("urlImages");
            entity.Property(e => e.Rating)
                .HasColumnType("int(11)")
                .HasColumnName("rating");
            entity.Property(e => e.City)
                .HasMaxLength(255)
                .HasColumnName("city");
        });

        modelBuilder.Entity<FlightType>(entity => 
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("flight_types")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Id, "flight_type_id").IsUnique();

            entity.HasIndex(e => e.Name, "flight_type_name_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Price, "flight_type_price_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Description, "description_UNIQUE").IsUnique();
           
            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("people")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.DocumentNumber, "document_number_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Email, "email_UNIQUE").IsUnique();

            entity.HasIndex(e => e.DocumentTypeId, "fk_person_document_type1_idx");

            entity.HasIndex(e => e.Id, "id").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .HasColumnName("document_number");
            entity.Property(e => e.DocumentTypeId)
                .HasColumnType("int(11)")
                .HasColumnName("document_type_id");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.LastName)
                .HasMaxLength(25)
                .HasColumnName("last_name");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .HasColumnName("password");
            entity.Property(e => e.UrlAvatar)
                .HasColumnType("mediumtext")
                .HasColumnName("urlAvatar");


            entity.HasOne(d => d.DocumentType).WithMany(p => p.People)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_person_document_type1");
        });

        modelBuilder.Entity<Reserve>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("reserves")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.PersonId, "fk_reserv_person1_idx");

            entity.HasIndex(e => e.RoomId, "fk_reserv_room1_idx");

            entity.HasIndex(e => e.FlightId, "fk_reserve_flight1_idx");

            entity.HasIndex(e => e.FoodId, "fk_reserve_food1_idx");

            entity.HasIndex(e => e.TourId, "fk_reserve_tour1_idx");

            entity.HasIndex(e => e.Id, "reserv_id").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CheckIn)
                .HasColumnType("datetime")
                .HasColumnName("check_in");
            entity.Property(e => e.CheckOut)
                .HasColumnType("datetime")
                .HasColumnName("check_out");
            entity.Property(e => e.FlightId)
                .HasColumnType("int(11)")
                .HasColumnName("flight_id");
            entity.Property(e => e.FoodId)
                .HasColumnType("int(11)")
                .HasColumnName("food_id");
            entity.Property(e => e.PeopleCuantity)
                .HasColumnType("int(3)")
                .HasColumnName("people_cuantity");
            entity.Property(e => e.PersonId)
                .HasColumnType("int(11)")
                .HasColumnName("person_id");
            entity.Property(e => e.RoomId)
                .HasColumnType("int(11)")
                .HasColumnName("room_id");
            entity.Property(e => e.Total)
                .HasPrecision(10)
                .HasColumnName("total");
            entity.Property(e => e.TourId)
                .HasColumnType("int(11)")
                .HasColumnName("tour_id");

            entity.HasOne(d => d.Flight).WithMany(p => p.Reserves)
                .HasForeignKey(d => d.FlightId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserve_flight1");

            entity.HasOne(d => d.Food).WithMany(p => p.Reserves)
                .HasForeignKey(d => d.FoodId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserve_food1");

            entity.HasOne(d => d.Person).WithMany(p => p.Reserves)
                .HasForeignKey(d => d.PersonId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserv_person1");

            entity.HasOne(d => d.Room).WithMany(p => p.Reserves)
                .HasForeignKey(d => d.RoomId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserv_room1");

            entity.HasOne(d => d.Tour).WithMany(p => p.Reserves)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_reserve_tour1");
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("rooms")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.HotelId, "fk_room_hotel1_idx");

            entity.HasIndex(e => e.Id, "room_id").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.HotelId)
                .HasColumnType("int(11)")
                .HasColumnName("hotel_id");
            entity.Property(e => e.PeopleCapacity)
                .HasColumnType("int(3)")
                .HasColumnName("people_capacity");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
            entity.Property(e => e.RoomNumber)
                .HasColumnType("int(11)")
                .HasColumnName("room_number");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");
            entity.Property(e => e.Type)
                .HasMaxLength(50)
                .HasColumnName("type");
            entity.Property(e => e.UrlImages)
                .HasColumnType("mediumtext")
                .HasColumnName("urlImages");

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_room_hotel1");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tours")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Name, "name_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "tour_id").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Category)
                .HasMaxLength(45)
                .HasColumnName("category");
            entity.Property(e => e.Description)
                .HasMaxLength(255)
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");

            entity.Property(e => e.UrlImages)
                .HasColumnType("mediumtext")
                .HasColumnName("urlImages");
        });

        modelBuilder.Entity<Review>(entity =>
         {
             entity.HasKey(r => r.Id);
             entity.Property(r => r.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");

             entity
                 .ToTable("reviews")
                 .HasCharSet("utf8mb4")
                 .UseCollation("utf8mb4_0900_ai_ci");

             entity.Property(r => r.Title)
                   .IsRequired()
                   .HasMaxLength(100)
                   .HasColumnName("title");

             entity.Property(r => r.Message)
                   .IsRequired()
                   .HasMaxLength(255)
                   .HasColumnName("message");

             entity.Property(r => r.Rating)
                    .IsRequired()
                    .HasColumnName("rating");

             entity.Property(r => r.CreatedAt)
                   .IsRequired()
                   .HasColumnName("createdAt");

             entity.Property(e => e.PersonId)
                 .HasColumnType("int(11)")
                 .HasColumnName("person_id");


             entity.HasOne(d => d.Person).WithMany(p => p.Reviews)
                 .HasForeignKey(d => d.PersonId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("fk_review_person1");
         });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
