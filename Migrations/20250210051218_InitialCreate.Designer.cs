﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ZenlessZoneZeroCharacterAPI.Models;

#nullable disable

namespace ZenlessZoneZeroCharacterAPI.Migrations
{
    [DbContext(typeof(ZZZCharactersContext))]
    [Migration("20250210051218_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            MySqlModelBuilderExtensions.AutoIncrementColumns(modelBuilder);

            modelBuilder.Entity("ZenlessZoneZeroCharacterAPI.Models.Characters", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("Damage")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Element")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("Heath")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Characters");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Damage = 250,
                            Element = "Physical",
                            Heath = 1500,
                            Name = "Billy Kid",
                            Type = "Attack"
                        },
                        new
                        {
                            Id = 2,
                            Damage = 180,
                            Element = "Ether",
                            Heath = 1200,
                            Name = "Nicole Demara",
                            Type = "Support"
                        },
                        new
                        {
                            Id = 3,
                            Damage = 150,
                            Element = "Fire",
                            Heath = 2000,
                            Name = "Soldier Eleven",
                            Type = "Defence"
                        },
                        new
                        {
                            Id = 4,
                            Damage = 300,
                            Element = "Ice",
                            Heath = 1300,
                            Name = "Miyabi",
                            Type = "Attack"
                        });
                });

            modelBuilder.Entity("ZenlessZoneZeroCharacterAPI.Models.Items", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    MySqlPropertyBuilderExtensions.UseMySqlIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AddedDamage")
                        .HasColumnType("int");

                    b.Property<int?>("AddedHealth")
                        .HasColumnType("int");

                    b.Property<string>("BonusType")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int?>("BonusValue")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<int>("CharacterId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.HasIndex("CharacterId");

                    b.ToTable("Items");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddedDamage = 50,
                            AddedHealth = 0,
                            BonusType = "Damage",
                            BonusValue = 10,
                            CharacterId = 1,
                            Name = "Blaster Pistol",
                            Type = "Weapon"
                        },
                        new
                        {
                            Id = 2,
                            AddedDamage = 0,
                            AddedHealth = 100,
                            BonusType = "Health",
                            BonusValue = 20,
                            CharacterId = 2,
                            Name = "Energy Shield",
                            Type = "Accessory"
                        },
                        new
                        {
                            Id = 3,
                            AddedDamage = 70,
                            AddedHealth = 0,
                            BonusType = "Damage",
                            BonusValue = 15,
                            CharacterId = 3,
                            Name = "Flame Thrower",
                            Type = "Weapon"
                        },
                        new
                        {
                            Id = 4,
                            AddedDamage = 60,
                            AddedHealth = 0,
                            BonusType = "Damage",
                            BonusValue = 20,
                            CharacterId = 4,
                            Name = "Ice Blade",
                            Type = "Weapon"
                        },
                        new
                        {
                            Id = 5,
                            AddedDamage = 0,
                            AddedHealth = 50,
                            BonusType = "Health",
                            BonusValue = 10,
                            CharacterId = 1,
                            Name = "Energy Booster",
                            Type = "Accessory"
                        },
                        new
                        {
                            Id = 6,
                            AddedDamage = 0,
                            AddedHealth = 150,
                            BonusType = "Health",
                            BonusValue = 30,
                            CharacterId = 3,
                            Name = "Shield Generator",
                            Type = "Accessory"
                        },
                        new
                        {
                            Id = 7,
                            AddedDamage = 80,
                            AddedHealth = 0,
                            BonusType = "Damage",
                            BonusValue = 12,
                            CharacterId = 2,
                            Name = "Rapid Fire Rifle",
                            Type = "Weapon"
                        },
                        new
                        {
                            Id = 8,
                            AddedDamage = 90,
                            AddedHealth = 0,
                            BonusType = "Damage",
                            BonusValue = 25,
                            CharacterId = 4,
                            Name = "Wind Sword",
                            Type = "Weapon"
                        },
                        new
                        {
                            Id = 9,
                            AddedDamage = 0,
                            AddedHealth = 200,
                            BonusType = "Health",
                            BonusValue = 50,
                            CharacterId = 2,
                            Name = "Healing Crystal",
                            Type = "Accessory"
                        },
                        new
                        {
                            Id = 10,
                            AddedDamage = 0,
                            AddedHealth = 300,
                            BonusType = "Health",
                            BonusValue = 70,
                            CharacterId = 3,
                            Name = "Dragon Armor",
                            Type = "Accessory"
                        },
                        new
                        {
                            Id = 11,
                            AddedDamage = 120,
                            AddedHealth = 0,
                            BonusType = "Damage",
                            BonusValue = 18,
                            CharacterId = 1,
                            Name = "Energy Pulse Cannon",
                            Type = "Weapon"
                        },
                        new
                        {
                            Id = 12,
                            AddedDamage = 0,
                            AddedHealth = 120,
                            BonusType = "Health",
                            BonusValue = 40,
                            CharacterId = 4,
                            Name = "Ice Shield",
                            Type = "Accessory"
                        },
                        new
                        {
                            Id = 13,
                            AddedDamage = 75,
                            AddedHealth = 0,
                            BonusType = "Damage",
                            BonusValue = 17,
                            CharacterId = 3,
                            Name = "Phoenix Blade",
                            Type = "Weapon"
                        },
                        new
                        {
                            Id = 14,
                            AddedDamage = 65,
                            AddedHealth = 0,
                            BonusType = "Damage",
                            BonusValue = 12,
                            CharacterId = 2,
                            Name = "Electric Gauntlets",
                            Type = "Weapon"
                        },
                        new
                        {
                            Id = 15,
                            AddedDamage = 0,
                            AddedHealth = 150,
                            BonusType = "Health",
                            BonusValue = 35,
                            CharacterId = 1,
                            Name = "Health Regenerator",
                            Type = "Accessory"
                        },
                        new
                        {
                            Id = 16,
                            AddedDamage = 100,
                            AddedHealth = 0,
                            BonusType = "Damage",
                            BonusValue = 22,
                            CharacterId = 3,
                            Name = "Dragon's Claw",
                            Type = "Weapon"
                        },
                        new
                        {
                            Id = 17,
                            AddedDamage = 110,
                            AddedHealth = 0,
                            BonusType = "Damage",
                            BonusValue = 20,
                            CharacterId = 4,
                            Name = "Thunderstorm Hammer",
                            Type = "Weapon"
                        },
                        new
                        {
                            Id = 18,
                            AddedDamage = 0,
                            AddedHealth = 250,
                            BonusType = "Health",
                            BonusValue = 60,
                            CharacterId = 3,
                            Name = "Reflective Shield",
                            Type = "Accessory"
                        },
                        new
                        {
                            Id = 19,
                            AddedDamage = 0,
                            AddedHealth = 80,
                            BonusType = "Health",
                            BonusValue = 15,
                            CharacterId = 2,
                            Name = "Energy Absorber",
                            Type = "Accessory"
                        },
                        new
                        {
                            Id = 20,
                            AddedDamage = 0,
                            AddedHealth = 220,
                            BonusType = "Health",
                            BonusValue = 50,
                            CharacterId = 4,
                            Name = "Frostbite Armor",
                            Type = "Accessory"
                        });
                });

            modelBuilder.Entity("ZenlessZoneZeroCharacterAPI.Models.Items", b =>
                {
                    b.HasOne("ZenlessZoneZeroCharacterAPI.Models.Characters", "Character")
                        .WithMany("Items")
                        .HasForeignKey("CharacterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Character");
                });

            modelBuilder.Entity("ZenlessZoneZeroCharacterAPI.Models.Characters", b =>
                {
                    b.Navigation("Items");
                });
#pragma warning restore 612, 618
        }
    }
}
