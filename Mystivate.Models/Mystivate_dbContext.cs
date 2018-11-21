using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;

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
        public virtual DbSet<Gear> Gear { get; set; }
        public virtual DbSet<GearInventory> GearInventory { get; set; }
        public virtual DbSet<GearQuestReward> GearQuestRewards { get; set; }
        public virtual DbSet<GearType> GearTypes { get; set; }
        public virtual DbSet<Habit> Habits { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<QuestInventory> QuestInventory { get; set; }
        public virtual DbSet<QuestStatus> QuestStatus { get; set; }
        public virtual DbSet<ToDo> ToDos { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Weapon> Weapons { get; set; }
        public virtual DbSet<WeaponInventory> WeaponInventory { get; set; }
        public virtual DbSet<WeaponQuestReward> WeaponQuestRewards { get; set; }
        public virtual DbSet<WeaponType> WeaponTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
//                optionsBuilder.UseSqlServer("Server=tcp:mystivate.database.windows.net,1433;Initial Catalog=Mystivate_db;Persist Security Info=False;User ID=Mystivate;Password=Myst1vate01!;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
//            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Bind to correct tables
            modelBuilder.Entity<Character>().ToTable("Character");
            modelBuilder.Entity<GearQuestReward>().ToTable("GearQuestReward");
            modelBuilder.Entity<GearType>().ToTable("GearType");
            modelBuilder.Entity<Habit>().ToTable("Habit");
            modelBuilder.Entity<Quest>().ToTable("Quest");
            modelBuilder.Entity<Habit>().ToTable("Habit");
            modelBuilder.Entity<DailyTask>().ToTable("DailyTask");
            modelBuilder.Entity<ToDo>().ToTable("ToDo");
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Weapon>().ToTable("Weapon");
            modelBuilder.Entity<WeaponQuestReward>().ToTable("WeaponQuestReward");
            modelBuilder.Entity<WeaponType>().ToTable("WeaponType");

            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.CurrentHealth).HasDefaultValueSql("((100))");

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
                    .HasDefaultValueSql("(0)");

                entity.Property(e => e.DoneYesterday)
                    .IsRequired()
                    .HasDefaultValueSql("(1)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.DailyTask)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTask917793");
            });

            modelBuilder.Entity<Gear>(entity =>
            {
                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.GearType)
                    .WithMany(p => p.Gear)
                    .HasForeignKey(d => d.GearTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKGear472184");
            });

            modelBuilder.Entity<GearInventory>(entity =>
            {
                entity.Property(e => e.Wearing)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.GearInventory)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKGearInvent738922");

                entity.HasOne(d => d.Gear)
                    .WithMany(p => p.GearInventory)
                    .HasForeignKey(d => d.GearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKGearInvent84682");
            });

            modelBuilder.Entity<GearQuestReward>(entity =>
            {
                entity.HasOne(d => d.Gear)
                    .WithMany(p => p.GearQuestReward)
                    .HasForeignKey(d => d.GearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKGearQuestR658048");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.GearQuestReward)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKGearQuestR648399");
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

            modelBuilder.Entity<Weapon>(entity =>
            {
                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.WeaponType)
                    .WithMany(p => p.Weapon)
                    .HasForeignKey(d => d.WeaponTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKWeapon883775");
            });

            modelBuilder.Entity<WeaponInventory>(entity =>
            {
                entity.Property(e => e.WeaponLeft)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.WeaponRight)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.HasOne(d => d.Character)
                    .WithMany(p => p.WeaponInventory)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKWeaponInve376071");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.WeaponInventory)
                    .HasForeignKey(d => d.WeaponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKWeaponInve992366");
            });

            modelBuilder.Entity<WeaponQuestReward>(entity =>
            {
                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.WeaponQuestReward)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKWeaponQues292731");

                entity.HasOne(d => d.Weapon)
                    .WithMany(p => p.WeaponQuestReward)
                    .HasForeignKey(d => d.WeaponId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKWeaponQues754862");
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
