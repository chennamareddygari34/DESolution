﻿using System;
using System.Collections.Generic;
using DEApp.Models;
using Microsoft.EntityFrameworkCore;

namespace DEApp.Data;

public partial class DeappContext : DbContext
{
    public DeappContext()
    {
    }

    public DeappContext(DbContextOptions<DeappContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Applicant> Applicants { get; set; }

    public virtual DbSet<Loan> Loans { get; set; }

    public virtual DbSet<ProfileSetting> ProfileSettings { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Vendor> Vendors { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:DevConnection");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Applicant>(entity =>
        {
            entity.HasKey(e => e.ApplicantId).HasName("PK__Applican__39AE9148702794EA");

            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.Applicant1)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("Applicant");
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.Country).HasMaxLength(100);
            entity.Property(e => e.DateOfBirth).HasColumnType("datetime");
            entity.Property(e => e.District).HasMaxLength(100);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.HouseNo).HasMaxLength(50);
            entity.Property(e => e.Landmark).HasMaxLength(100);
            entity.Property(e => e.MaritalStatus).HasMaxLength(50);
            entity.Property(e => e.OccupationType).HasMaxLength(50);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.State).HasMaxLength(100);
            entity.Property(e => e.VendorId).HasColumnName("VendorID");

            entity.HasOne(d => d.Vendor).WithMany(p => p.Applicants)
                .HasForeignKey(d => d.VendorId)
                .HasConstraintName("FK__Applicant__Vendo__4BAC3F29");
        });

        modelBuilder.Entity<Loan>(entity =>
        {
            entity.HasKey(e => e.LoanId).HasName("PK__Loans__4F5AD43754EB1AB4");

            entity.Property(e => e.LoanId).HasColumnName("LoanID");
            entity.Property(e => e.ApplicantDate).HasColumnType("datetime");
            entity.Property(e => e.ApplicantId).HasColumnName("ApplicantID");
            entity.Property(e => e.InterestRate).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.LastUpdate).HasColumnType("datetime");
            entity.Property(e => e.LoanAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.LoanDescription).HasMaxLength(255);
            entity.Property(e => e.LoanType).HasMaxLength(100);
            entity.Property(e => e.MaxLoanAmount).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.MonthlyPayment).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Applicant).WithMany(p => p.Loans)
                .HasForeignKey(d => d.ApplicantId)
                .HasConstraintName("FK__Loans__Applicant__4E88ABD4");
        });

        modelBuilder.Entity<ProfileSetting>(entity =>
        {
            entity.HasKey(e => e.ProfileSettingId).HasName("PK__ProfileS__3388D9C08AA68E13");

            entity.ToTable("ProfileSetting");

            entity.HasIndex(e => e.Username, "UQ__ProfileS__536C85E4F895E4E4").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__ProfileS__A9D105347198F1D3").IsUnique();

            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FirstName).HasMaxLength(100);
            entity.Property(e => e.LastName).HasMaxLength(100);
            entity.Property(e => e.MobileNumber).HasMaxLength(15);
            entity.Property(e => e.Role).HasMaxLength(50);
            entity.Property(e => e.Username).HasMaxLength(100);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4C1D94B090");

            entity.ToTable("User");

            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<Vendor>(entity =>
        {
            entity.HasKey(e => e.VendorId).HasName("PK__Vendors__FC8618D3529A5137");

            entity.Property(e => e.VendorId).HasColumnName("VendorID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Make)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Model)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.VendorName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
