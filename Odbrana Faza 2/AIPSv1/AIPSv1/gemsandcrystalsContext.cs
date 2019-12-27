using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AIPSv1
{
    public partial class gemsandcrystalsContext : DbContext
    {
        //public gemsandcrystalsContext()
        //{
        //}

        public gemsandcrystalsContext(DbContextOptions<gemsandcrystalsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Card> Card { get; set; }
        public virtual DbSet<Deck> Deck { get; set; }
        public virtual DbSet<Game> Game { get; set; }
        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("Server=localhost;Database=gemsandcrystals;User=root;Password=root;TreatTinyAsBoolean=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>(entity =>
            {
                entity.HasKey(e => e.IdCard);

                entity.ToTable("card");

                entity.HasIndex(e => e.IdCard)
                    .HasName("idCard_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Name)
                    .HasName("Name_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdCard)
                    .HasColumnName("idCard")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Attack).HasColumnType("int(11)");

                entity.Property(e => e.CrystalsCost).HasColumnType("int(11)");

                entity.Property(e => e.Description).HasColumnType("varchar(200)");

                entity.Property(e => e.Effect).HasColumnType("tinyint(4)");

                entity.Property(e => e.EffectList).HasColumnType("varchar(200)");

                entity.Property(e => e.GemsCost).HasColumnType("int(11)");

                entity.Property(e => e.Health).HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Shield).HasColumnType("int(11)");

                entity.Property(e => e.Spell).HasColumnType("tinyint(4)");
            });

            modelBuilder.Entity<Deck>(entity =>
            {
                entity.HasKey(e => e.IdDeck);

                entity.ToTable("deck");

                entity.HasIndex(e => e.IdDeck)
                    .HasName("idDeck_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdDeck)
                    .HasColumnName("idDeck")
                    .HasColumnType("int(11)");

                entity.Property(e => e.CardList).HasColumnType("varchar(500)");

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasColumnType("int(11)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnType("varchar(45)");
            });

            modelBuilder.Entity<Game>(entity =>
            {
                entity.HasKey(e => e.IdGame);

                entity.ToTable("game");

                entity.HasIndex(e => e.IdGame)
                    .HasName("idGame_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.IdP1)
                    .HasName("idP1_idx");

                entity.HasIndex(e => e.IdP1deck)
                    .HasName("idP1Deck_idx");

                entity.HasIndex(e => e.IdP2)
                    .HasName("idP2_idx");

                entity.HasIndex(e => e.IdP2deck)
                    .HasName("idP2Deck_idx");

                entity.Property(e => e.IdGame)
                    .HasColumnName("idGame")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdP1)
                    .HasColumnName("idP1")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdP1deck)
                    .HasColumnName("idP1Deck")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdP2)
                    .HasColumnName("idP2")
                    .HasColumnType("int(11)");

                entity.Property(e => e.IdP2deck)
                    .HasColumnName("idP2Deck")
                    .HasColumnType("int(11)");

                entity.Property(e => e.P1deckCount)
                    .HasColumnName("P1DeckCount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.P1handCardList)
                    .HasColumnName("P1HandCardList")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.P1lp)
                    .HasColumnName("P1LP")
                    .HasColumnType("int(11)");

                entity.Property(e => e.P1tableCardsList)
                    .HasColumnName("P1TableCardsList")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.P2deckCount)
                    .HasColumnName("P2DeckCount")
                    .HasColumnType("int(11)");

                entity.Property(e => e.P2handCardList)
                    .HasColumnName("P2HandCardList")
                    .HasColumnType("varchar(500)");

                entity.Property(e => e.P2lp)
                    .HasColumnName("P2LP")
                    .HasColumnType("int(11)");

                entity.Property(e => e.P2tableCardsList)
                    .HasColumnName("P2TableCardsList")
                    .HasColumnType("varchar(500)");

                entity.HasOne(d => d.IdP1Navigation)
                    .WithMany(p => p.GameIdP1Navigation)
                    .HasForeignKey(d => d.IdP1)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idP1");

                entity.HasOne(d => d.IdP1deckNavigation)
                    .WithMany(p => p.GameIdP1deckNavigation)
                    .HasForeignKey(d => d.IdP1deck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idP1Deck");

                entity.HasOne(d => d.IdP2Navigation)
                    .WithMany(p => p.GameIdP2Navigation)
                    .HasForeignKey(d => d.IdP2)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idP2");

                entity.HasOne(d => d.IdP2deckNavigation)
                    .WithMany(p => p.GameIdP2deckNavigation)
                    .HasForeignKey(d => d.IdP2deck)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idP2Deck");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.IdUser);

                entity.ToTable("user");

                entity.HasIndex(e => e.IdUser)
                    .HasName("idUser_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.IdUser)
                    .HasColumnName("idUser")
                    .HasColumnType("int(11)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Avatar).HasColumnType("varchar(45)");

                entity.Property(e => e.LossNo).HasColumnType("int(11)");

                entity.Property(e => e.MyDecksList).HasColumnType("varchar(500)");

                entity.Property(e => e.Nickname)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.OwnedCardsList).HasColumnType("varchar(500)");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Rank)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnType("varchar(45)");

                entity.Property(e => e.WinNo).HasColumnType("int(11)");

                entity.HasOne(d => d.IdUserNavigation)
                    .WithOne(p => p.InverseIdUserNavigation)
                    .HasForeignKey<User>(d => d.IdUser)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("idUser");
            });
        }
    }
}
