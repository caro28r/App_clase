using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace P6_APPI_CAROLINAR.Models;

public partial class P620242travelsContext : DbContext
{
    public P620242travelsContext()
    {
    }

    public P620242travelsContext(DbContextOptions<P620242travelsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Country> Countries { get; set; }

    public virtual DbSet<Destination> Destinations { get; set; }

    public virtual DbSet<Hosting> Hostings { get; set; }

    public virtual DbSet<Reservation> Reservations { get; set; }

    public virtual DbSet<Schedule> Schedules { get; set; }

    public virtual DbSet<Tour> Tours { get; set; }

    public virtual DbSet<Transport> Transports { get; set; }

    public virtual DbSet<Travel> Travels { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Country>(entity =>
        {
            entity.HasKey(e => e.CountryId).HasName("PK__Country__10D160BFB7402E6E");

            entity.ToTable("Country");

            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.CountryName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Destination>(entity =>
        {
            entity.HasKey(e => e.DestionationId).HasName("PK__Destinat__12F2541F01507317");

            entity.ToTable("Destination");

            entity.Property(e => e.DestionationId).HasColumnName("DestionationID");
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.DestinationName)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Destinations)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKDestinatio811421");
        });

        modelBuilder.Entity<Hosting>(entity =>
        {
            entity.HasKey(e => e.HostingId).HasName("PK__Hosting__B2C2DF84116AE423");

            entity.ToTable("Hosting");

            entity.Property(e => e.HostingId).HasColumnName("HostingID");
            entity.Property(e => e.Address)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CountryId).HasColumnName("CountryID");
            entity.Property(e => e.HostingName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.ZipCode)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Country).WithMany(p => p.Hostings)
                .HasForeignKey(d => d.CountryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKHosting822815");
        });

        modelBuilder.Entity<Reservation>(entity =>
        {
            entity.HasKey(e => e.ReservationId).HasName("PK__Reservat__B7EE5F045E0D4F43");

            entity.ToTable("Reservation");

            entity.Property(e => e.ReservationId).HasColumnName("ReservationID");
            entity.Property(e => e.CheckInDate).HasColumnType("smalldatetime");
            entity.Property(e => e.CheckOutDate).HasColumnType("smalldatetime");
            entity.Property(e => e.HostingId).HasColumnName("HostingID");
            entity.Property(e => e.Notes)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.TourId).HasColumnName("TourID");

            entity.HasOne(d => d.Hosting).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.HostingId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKReservatio685500");

            entity.HasOne(d => d.Tour).WithMany(p => p.Reservations)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKReservatio347148");
        });

        modelBuilder.Entity<Schedule>(entity =>
        {
            entity.HasKey(e => e.ActivityId).HasName("PK__Schedule__45F4A7F18D74C9BF");

            entity.ToTable("Schedule");

            entity.Property(e => e.ActivityId).HasColumnName("ActivityID");
            entity.Property(e => e.ActivityDateAndTime).HasColumnType("smalldatetime");
            entity.Property(e => e.ActivityName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Notes)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.TravelId).HasColumnName("TravelID");

            entity.HasOne(d => d.Travel).WithMany(p => p.Schedules)
                .HasForeignKey(d => d.TravelId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKSchedule898172");
        });

        modelBuilder.Entity<Tour>(entity =>
        {
            entity.HasKey(e => e.TourId).HasName("PK__Tour__604CEA10E10433DB");

            entity.ToTable("Tour");

            entity.Property(e => e.TourId).HasColumnName("TourID");
            entity.Property(e => e.Notes)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.TourDate).HasColumnType("smalldatetime");
            entity.Property(e => e.TourName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.Tours)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTour899402");
        });

        modelBuilder.Entity<Transport>(entity =>
        {
            entity.HasKey(e => e.TransportId).HasName("PK__Transpor__19E9A17D14D94F12");

            entity.ToTable("Transport");

            entity.Property(e => e.TransportId).HasColumnName("TransportID");
            entity.Property(e => e.TransportDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Travel>(entity =>
        {
            entity.HasKey(e => e.TravelId).HasName("PK__Travel__E931521500390070");

            entity.ToTable("Travel");

            entity.Property(e => e.TravelId).HasColumnName("TravelID");
            entity.Property(e => e.ArrivalDate).HasColumnType("smalldatetime");
            entity.Property(e => e.DepartureDate).HasColumnType("smalldatetime");
            entity.Property(e => e.DestionationId).HasColumnName("DestionationID");
            entity.Property(e => e.Notes)
                .HasMaxLength(1500)
                .IsUnicode(false);
            entity.Property(e => e.TourId).HasColumnName("TourID");
            entity.Property(e => e.TransportId).HasColumnName("TransportID");

            entity.HasOne(d => d.Destionation).WithMany(p => p.Travels)
                .HasForeignKey(d => d.DestionationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTravel896955");

            entity.HasOne(d => d.Tour).WithMany(p => p.Travels)
                .HasForeignKey(d => d.TourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTravel272452");

            entity.HasOne(d => d.Transport).WithMany(p => p.Travels)
                .HasForeignKey(d => d.TransportId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKTravel336555");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC348E22CE");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LoginPassword)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");

            entity.HasOne(d => d.UserRole).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRoleId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FKUser854768");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.UserRoleId).HasName("PK__UserRole__3D978A5501F180D7");

            entity.ToTable("UserRole");

            entity.Property(e => e.UserRoleId).HasColumnName("UserRoleID");
            entity.Property(e => e.UserRoleDescription)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
