using FenixCoin.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace FenixCoin.DataAccess.Context
{
    public class FenixDbContext : DbContext
    {
        public FenixDbContext(DbContextOptions<FenixDbContext> options) : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<Crypto> Cryptos { get; set; }
        public DbSet<Wallet> Wallets { get; set; }
        public DbSet<Trade> Trades { get; set; }
        public DbSet<CryptoWallet> CryptoWallets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Configuring User Entity
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.FirstName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.LastName).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired().HasMaxLength(320);
                entity.Property(e => e.Username).IsRequired().HasMaxLength(50);
                entity.Property(e => e.Password).IsRequired();

                entity.HasIndex(e => e.Username).IsUnique();
            });
            #endregion

            #region Configuring Crypto Entity
            modelBuilder.Entity<Crypto>(entity =>
            {
                entity.ToTable("Cryptos");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.CryptoName).IsRequired();
                entity.Property(e => e.CryptoValueInUSD).IsRequired();
                entity.Property(e => e.ShortName).IsRequired().HasMaxLength(4);
            });
            #endregion

            #region Configuring Wallet Entity
            modelBuilder.Entity<Wallet>(entity =>
            {
                entity.ToTable("Wallet");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.WalletBalanceInUSD).IsRequired();
                entity.HasOne(w => w.User)
                .WithOne(u => u.Wallet)
                .HasForeignKey<Wallet>(w => w.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            #endregion Configuring Trade Entity
            modelBuilder.Entity<Trade>(entity =>
            {
                entity.ToTable("Trades");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.TradeType).IsRequired();
                entity.Property(e => e.TradeRole).IsRequired();
                entity.Property(e => e.AmountTradedInUSD);
                entity.Property(e => e.AmountTradedInCryptos);
                entity.Property(e => e.TimeOfTrade).IsRequired();

                entity.HasOne(u => u.User)
                .WithMany(t => t.TradeHistory)
                .HasForeignKey(u => u.UserId)
                .OnDelete(DeleteBehavior.Cascade);
            });
            #region Configuring CryptoWallet Entity
            modelBuilder.Entity<CryptoWallet>(entity =>
            {
                entity.ToTable("CryptoWallet");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.HasOne(wc => wc.Wallet)
                .WithMany(w => w.CryptosInWallet)
                .HasForeignKey(wc => wc.WalletId)
                .OnDelete(DeleteBehavior.Cascade);

                entity.HasOne(wc => wc.Crypto)
                .WithMany()
                .HasForeignKey(wc => wc.CryptoId);
            });
            #endregion
            base.OnModelCreating(modelBuilder);
        }
    }
}
