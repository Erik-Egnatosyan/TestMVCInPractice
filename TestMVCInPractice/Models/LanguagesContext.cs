﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestMVCInPractice.Models;

public partial class LanguagesContext : DbContext
{
    public LanguagesContext(DbContextOptions<LanguagesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<MultiLangauge> MultiLangauges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<MultiLangauge>(entity =>
        {
            entity.HasKey(e => e.id).HasName("PK__MultiLan__3213E83FB4B1EC1A");

            entity.ToTable("MultiLangauge");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}