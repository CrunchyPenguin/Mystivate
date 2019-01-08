using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mystivate.Models
{
    public partial class Mystivate_dbContext : DbContext
    {
        public Mystivate_dbContext()
        {
        }

        public Mystivate_dbContext(DbContextOptions<Mystivate_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<DailyTask> DailyTasks { get; set; }
        public virtual DbSet<GearType> GearTypes { get; set; }
        public virtual DbSet<Habit> Habits { get; set; }
        public virtual DbSet<InventorySlot> InventorySlots { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<QuestEquipmentReward> QuestEquipmentRewards { get; set; }
        public virtual DbSet<QuestInventory> QuestInventory { get; set; }
        public virtual DbSet<QuestStatus> QuestStatus { get; set; }
        public virtual DbSet<ToDo> ToDos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<WeaponType> WeaponTypes { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }

        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<Gear> Gear { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=tcp:mystivate.database.windows.net,1433;Initial Catalog=Mystivate_db;Persist Security Info=False;User ID=Mystivate;Password=Myst1vate01!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Bind to correct tables
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<GearType>().ToTable("GearType");
            modelBuilder.Entity<Habit>().ToTable("Habit");
            modelBuilder.Entity<Quest>().ToTable("Quest");
            modelBuilder.Entity<Habit>().ToTable("Habit");
            modelBuilder.Entity<DailyTask>().ToTable("DailyTask");
            modelBuilder.Entity<ToDo>().ToTable("ToDo");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<WeaponType>().ToTable("WeaponType");
            modelBuilder.Entity<InventorySlot>().ToTable("InventorySlot");
            modelBuilder.Entity<QuestEquipmentReward>().ToTable("QuestEquipmentReward");

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.HasOne(d => d.WeaponType)
                    .WithMany(p => p.Equipment as IEnumerable<Weapon>)
                    .HasForeignKey(d => d.WeaponTypeId)
                    .HasConstraintName("FKEquipment571488");
            });

            modelBuilder.Entity<Gear>(entity =>
            {
                entity.HasOne(d => d.GearType)
                    .WithMany(p => p.Equipment as IEnumerable<Gear>)
                    .HasForeignKey(d => d.GearTypeId)
                    .HasConstraintName("FKEquipment387209");
            });

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.MaxHealth).HasDefaultValueSql("((100))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Character)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCharacter650031");
            });

            modelBuilder.Entity<DailyTask>(entity =>
            {
                entity.Property(e => e.Done)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DailyTask)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKDailyTask557893");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GearType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Habit>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Habit)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHabit36272");
            });

            modelBuilder.Entity<InventorySlot>(entity =>
            {
                entity.HasOne(d => d.Character)
                    .WithMany(p => p.InventorySlot)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKInventoryS19018");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.InventorySlot)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKInventoryS790889");

                entity.Property(e => e.Wearing)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Left)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");
            });

            modelBuilder.Entity<Quest>(entity =>
            {
                entity.Property(e => e.BossImage)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QuestEquipmentReward>(entity =>
            {
                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.QuestEquipmentRewards)
                    .HasForeignKey(d => d.EquipmentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestEquip228121");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.QuestEquipmentRewards)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestEquip245676");
            });

            modelBuilder.Entity<QuestInventory>(entity =>
            {
                entity.HasOne(d => d.Character)
                    .WithMany(p => p.QuestInventory)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestInven638883");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.QuestInventory)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestInven668817");

                entity.HasOne(d => d.QuestStatus)
                    .WithMany(p => p.QuestInventory)
                    .HasForeignKey(d => d.QuestStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestInven965621");
            });

            modelBuilder.Entity<QuestStatus>(entity =>
            {
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ToDo>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ToDo)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKToDo905792");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.LastLogin).HasColumnType("date");

                entity.Property(e => e.PasswordKey)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PasswordSalt)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<WeaponType>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });
        }
    }
}
