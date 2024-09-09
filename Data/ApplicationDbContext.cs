using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace Dream_Reserve_Back;

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

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("document_type")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Abreviation, "abreviation_UNIQUE").IsUnique();

            entity.HasIndex(e => e.Id, "document_id").IsUnique();

            entity.HasIndex(e => e.Name, "document_name_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Abreviation)
                .HasMaxLength(10)
                .HasColumnName("abreviation");
            entity.Property(e => e.Name)
                .HasMaxLength(25)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Flight>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("flight")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Id, "flight_id").IsUnique();

            entity.HasIndex(e => e.Name, "number_UNIQUE").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Date)
                .HasColumnType("datetime")
                .HasColumnName("date");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Food>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("food")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.Id, "food_id").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Cuantity)
                .HasColumnType("int(11)")
                .HasColumnName("cuantity");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
        });

        modelBuilder.Entity<Hotel>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("hotel")
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
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .HasColumnName("email");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Nit)
                .HasColumnType("int(11)")
                .HasColumnName("nit");
            entity.Property(e => e.Phone)
                .HasMaxLength(45)
                .HasColumnName("phone");
        });

        modelBuilder.Entity<Person>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("person")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

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
                .HasMaxLength(255)
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

            entity.HasOne(d => d.DocumentType).WithMany(p => p.People)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_person_document_type1");
        });

        modelBuilder.Entity<Reserve>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("reserve")
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
            entity.Property(e => e.FlightId)
                .HasColumnType("int(11)")
                .HasColumnName("flight_id");
            entity.Property(e => e.FoodId)
                .HasColumnType("int(11)")
                .HasColumnName("food_id");
            entity.Property(e => e.PersonId)
                .HasColumnType("int(11)")
                .HasColumnName("person_id");
            entity.Property(e => e.RoomId)
                .HasColumnType("int(11)")
                .HasColumnName("room_id");
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
                .ToTable("room")
                .HasCharSet("utf8mb4")
                .UseCollation("utf8mb4_0900_ai_ci");

            entity.HasIndex(e => e.HotelId, "fk_room_hotel1_idx");

            entity.HasIndex(e => e.Id, "room_id").IsUnique();

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.CheckIn)
                .HasColumnType("datetime")
                .HasColumnName("check_in");
            entity.Property(e => e.CheckOut)
                .HasColumnType("datetime")
                .HasColumnName("check_out");
            entity.Property(e => e.HotelId)
                .HasColumnType("int(11)")
                .HasColumnName("hotel_id");
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

            entity.HasOne(d => d.Hotel).WithMany(p => p.Rooms)
                .HasForeignKey(d => d.HotelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_room_hotel1");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity
                .ToTable("tour")
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
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasPrecision(10)
                .HasColumnName("price");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
