using Database.Seeds;
using Domain.Entities;
using Domain.Entities.Auth;
using Domain.Entities.Fiancial;
using Domain.Entities.Financial;
using Domain.Entities.Product;
using Domain.Entities.Stock;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public  class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        #region DbSet
        public DbSet<Module> Modules { get; set; }
        public DbSet<Permission> Permissions { get; set; }
        public DbSet<UserProfile> Profiles { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<ContactEntity> Contacts { get; set; }

        public DbSet<FinancialReleaseEntity> FinancialReleases { get; set; }
        public DbSet<FinancialReleaseTypeEntity> FinancialReleaseTypes { get; set; }
        public DbSet<FinancialBalanceEntity> FinancialBalances { get; set; }
        public DbSet<ManualTransactionEntity> ManualTransactions { get; set; }
        public DbSet<WalletEntity> Wallets { get; set; }


        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductEntity> Products { get; set; }

        
        public DbSet<InventoryAdjustmentEntity> InventoryAdjustments { get; set; }
        public DbSet<StockBalanceEntity> StockBalances { get; set; }
        public DbSet<StockLocationEntity> StockLocations { get; set; }
        public DbSet<StockReleaseEntity> StockReleases { get; set; }
        
        #endregion


        public override int SaveChanges()
        {
            GenerateGuidForNewEntities();
            return base.SaveChanges();
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            GenerateGuidForNewEntities();
            return await base.SaveChangesAsync(cancellationToken);
        }

        private void GenerateGuidForNewEntities()
        {
            var entitiesWithDefaultEntity = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added && e.Entity is DefaultEntity)
                .Select(e => e.Entity as DefaultEntity)
                .ToList();

            foreach (var entity in entitiesWithDefaultEntity)
            {
                if (entity.Uuid == Guid.Empty)
                {
                    entity.Uuid = Guid.NewGuid();
                }
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.SharedTypeEntity<Dictionary<long, long>>("ProfilePermissions");
            modelBuilder.Entity<UserProfile>()
                .HasMany(p => p.Permissions)
                .WithMany(p => p.Profiles)
                .UsingEntity<Dictionary<long, long>>("ProfilePermissions",
                    r => r.HasOne<Permission>().WithMany().HasForeignKey("PermissionId"),
                    l => l.HasOne<UserProfile>().WithMany().HasForeignKey("ProfileId")
                );

            modelBuilder.Entity<User>()
                 .HasOne(u => u.UserGroup)
                 .WithMany(g => g.Users)
                 .HasForeignKey(u => u.UserGroupId)
                 .IsRequired(false)
                 .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<UserGroup>()
                .HasOne(g => g.Profile)
                .WithMany()
                .HasForeignKey(g => g.ProfileId);

            modelBuilder.Entity<ProductEntity>()
                .HasOne(p => p.StockLocation)
                .WithMany()
                .HasForeignKey(p => p.StockLocationId)
                .OnDelete(DeleteBehavior.Restrict);


            AuthSeedData.Seed(modelBuilder);
            FinancialFinancialReleaseTypeSeedData.Seed(modelBuilder);
            StockLocationSeedData.Seed(modelBuilder);
            WalletSeedData.Seed(modelBuilder);
        }
    }
}
