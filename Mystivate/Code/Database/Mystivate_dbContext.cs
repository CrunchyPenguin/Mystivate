using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Mystivate.Models
{
    public partial class Mystivate_dbContext : DbContext
    {
        public Mystivate_dbContext(DbContextOptions<Mystivate_dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Character> Characters { get; set; }
        public virtual DbSet<Gear> Gear { get; set; }
        public virtual DbSet<GearInventory> GearInventory { get; set; }
        public virtual DbSet<GearType> GearTypes { get; set; }
        public virtual DbSet<Habit> Habits { get; set; }
        public virtual DbSet<QuestInventory> QuestInventory { get; set; }
        public virtual DbSet<QuestReward> QuestRewards { get; set; }
        public virtual DbSet<Quest> Quests { get; set; }
        public virtual DbSet<QuestStatus> QuestStatus { get; set; }
        public virtual DbSet<DailyTask> DailyTasks { get; set; }
        public virtual DbSet<ToDo> ToDos { get; set; }
        public virtual DbSet<User> Users { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Server=tcp:mystivate.database.windows.net,1433;Database=Mystivate_db;User ID=Mystivate;Password=Myst1vate01!;");
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Character>(entity =>
            {
                entity.Property(e => e.Lives).HasDefaultValueSql("((100))");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Armor)
                    .WithMany(p => p.CharactersArmor)
                    .HasForeignKey(d => d.ArmorId)
                    .HasConstraintName("FKCharacters857777");

                entity.HasOne(d => d.Headgear)
                    .WithMany(p => p.CharactersHeadgear)
                    .HasForeignKey(d => d.HeadgearId)
                    .HasConstraintName("FKCharacters193974");

                entity.HasOne(d => d.LeftWeapon)
                    .WithMany(p => p.CharactersLeftWeapon)
                    .HasForeignKey(d => d.LeftWeaponId)
                    .HasConstraintName("FKCharacters282041");

                entity.HasOne(d => d.RightWeapon)
                    .WithMany(p => p.CharactersRightWeapon)
                    .HasForeignKey(d => d.RightWeaponId)
                    .HasConstraintName("FKCharacters509833");

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Characters)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKCharacters489263");
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
                    .HasConstraintName("FKGear6632");
            });

            modelBuilder.Entity<GearInventory>(entity =>
            {
                entity.HasOne(d => d.Character)
                    .WithMany(p => p.GearInventory)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKGearInvent13747");

                entity.HasOne(d => d.Gear)
                    .WithMany(p => p.GearInventory)
                    .HasForeignKey(d => d.GearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKGearInvent84682");
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
                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Habits)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKHabits496376");
            });

            modelBuilder.Entity<QuestInventory>(entity =>
            {
                entity.HasOne(d => d.Character)
                    .WithMany(p => p.QuestInventory)
                    .HasForeignKey(d => d.CharacterId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestInven364059");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.QuestInventory)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestInven78349");

                entity.HasOne(d => d.QuestStatus)
                    .WithMany(p => p.QuestInventory)
                    .HasForeignKey(d => d.QuestStatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestInven965621");
            });

            modelBuilder.Entity<QuestReward>(entity =>
            {
                entity.HasOne(d => d.Gear)
                    .WithMany(p => p.QuestRewards)
                    .HasForeignKey(d => d.GearId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestRewar938196");

                entity.HasOne(d => d.Quest)
                    .WithMany(p => p.QuestRewards)
                    .HasForeignKey(d => d.QuestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKQuestRewar818618");
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

            modelBuilder.Entity<QuestStatus>(entity =>
            {
                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<DailyTask>(entity =>
            {
                entity.Property(e => e.Done)
                    .IsRequired()
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.Users)
                    .WithMany(p => p.Tasks)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKTasks148036");
            });

            modelBuilder.Entity<ToDo>(entity =>
            {
                entity.HasOne(d => d.Users)
                    .WithMany(p => p.ToDos)
                    .HasForeignKey(d => d.UsersId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FKToDos520067");
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
        }
    }
}
