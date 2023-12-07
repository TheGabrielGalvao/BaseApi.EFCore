using Domain.Entities.Financial;
using Domain.Enum;
using Microsoft.EntityFrameworkCore;
using Util.Enumerartor;

namespace Database.Seeds
{
    public static class WalletSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedDefaultTypes(modelBuilder);
        }


        private static void SeedDefaultTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WalletEntity>().HasData(
                new WalletEntity
                {
                    Id = 1,
                    Uuid = Guid.Parse("C6ECCDB4-29AB-4F65-BA92-7B6580619436"),
                    Name = "Conta Padrão",
                    Type = EWalletType.None,
                    Status = EGenericStatus.Ativo
                }

            );
        }
    }
}
