using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace SentiApp.Entities;

public partial class SentiDbContext : DbContext
{
    public SentiDbContext()
    {
    }

    public SentiDbContext(DbContextOptions<SentiDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Appointment> Appointments { get; set; }

    public virtual DbSet<Client> Clients { get; set; }

    public virtual DbSet<EmployeeInfo> EmployeeInfos { get; set; }

    public virtual DbSet<EmployeeSpecialization> EmployeeSpecializations { get; set; }

    public virtual DbSet<Registration> Registrations { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Room> Rooms { get; set; }

    public virtual DbSet<Shedule> Shedules { get; set; }

    public virtual DbSet<Specialization> Specializations { get; set; }

    public virtual DbSet<TimeSlotGroup> TimeSlotGroups { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseLazyLoadingProxies().UseSqlServer("Server=DESKTOP-GS54HBS\\SA;Database=SentiDb;User id=sa;password=111;encrypt=false");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Cyrillic_General_CI_AI");

        modelBuilder.Entity<Appointment>(entity =>
        {
            entity.HasKey(e => e.AppointmentId).HasName("PK_Appointment_1");

            entity.ToTable("Appointment");

            entity.Property(e => e.Comment).HasColumnType("text");

            entity.HasOne(d => d.Registration).WithMany(p => p.Appointments)
                .HasForeignKey(d => d.RegistrationId)
                .HasConstraintName("FK_Appointment_Registration");
        });

        modelBuilder.Entity<Client>(entity =>
        {
            entity.ToTable("Client");

            entity.Property(e => e.Comment).HasColumnType("text");
            entity.Property(e => e.ContactInfo).HasMaxLength(50);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.MedHistory).HasColumnType("text");
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeInfo>(entity =>
        {
            entity.ToTable("EmployeeInfo");

            entity.Property(e => e.AcceptanceDate).HasColumnType("date");
            entity.Property(e => e.EmployeeIdocument).HasColumnName("EmployeeIDocument");
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Patronymic).HasMaxLength(50);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<EmployeeSpecialization>(entity =>
        {
            entity.HasKey(e => e.EmployeeSpecializationsId);

            entity.HasOne(d => d.Employee).WithMany(p => p.EmployeeSpecializations)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_EmployeeSpecializations_EmployeeInfo1");

            entity.HasOne(d => d.Specialization).WithMany(p => p.EmployeeSpecializations)
                .HasForeignKey(d => d.SpecializationId)
                .HasConstraintName("FK_EmployeeSpecializations_Specialization");
        });

        modelBuilder.Entity<Registration>(entity =>
        {
            entity.HasKey(e => e.RegistrationId).HasName("PK_Appointment");

            entity.ToTable("Registration");

            entity.Property(e => e.DateTime).HasColumnType("datetime");
            entity.Property(e => e.RegistrationDate).HasColumnType("datetime");
            entity.Property(e => e.Status).HasMaxLength(50);

            entity.HasOne(d => d.Client).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.ClientId)
                .HasConstraintName("FK_Appointment_Client");

            entity.HasOne(d => d.Employee).WithMany(p => p.Registrations)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Appointment_EmployeeInfo");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.ToTable("Role");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.RoleName).HasMaxLength(20);
        });

        modelBuilder.Entity<Room>(entity =>
        {
            entity.ToTable("Room");

            entity.Property(e => e.RoomId).ValueGeneratedNever();
            entity.Property(e => e.RoomNumber).HasMaxLength(5);
        });

        modelBuilder.Entity<Shedule>(entity =>
        {
            entity.ToTable("Shedule");

            entity.Property(e => e.Day).HasColumnType("date");
            entity.Property(e => e.EndTime).HasPrecision(4);
            entity.Property(e => e.StartTime).HasPrecision(4);

            entity.HasOne(d => d.Employee).WithMany(p => p.Shedules)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_Shedule_EmployeeInfo");

            entity.HasOne(d => d.Room).WithMany(p => p.Shedules)
                .HasForeignKey(d => d.RoomId)
                .HasConstraintName("FK_Shedule_Room");
        });

        modelBuilder.Entity<Specialization>(entity =>
        {
            entity.ToTable("Specialization");

            entity.Property(e => e.SpecializationId).ValueGeneratedNever();
            entity.Property(e => e.SpecializationName).HasMaxLength(50);
        });

        modelBuilder.Entity<TimeSlotGroup>(entity =>
        {
            entity.HasKey(e => e.TimeSlotsGroupId);

            entity.ToTable("TimeSlotGroup");

            entity.Property(e => e.TimeSlot).HasPrecision(4);

            entity.HasOne(d => d.Shedule).WithMany(p => p.TimeSlotGroups)
                .HasForeignKey(d => d.SheduleId)
                .HasConstraintName("FK_TimeSlotGroup_Shedule");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("User");

            entity.Property(e => e.UserId).ValueGeneratedNever();
            entity.Property(e => e.Login).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK_User_Role");

            entity.HasOne(d => d.UserNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_User_EmployeeInfo1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
