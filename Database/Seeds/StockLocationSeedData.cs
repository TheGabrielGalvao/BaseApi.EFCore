using Domain.Entities.Stock;
using Microsoft.EntityFrameworkCore;

namespace Database.Seeds
{
    public static class StockLocationSeedData
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            SeedDefaultTypes(modelBuilder);
        }


        private static void SeedDefaultTypes(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StockLocationEntity>().HasData(
                new StockLocationEntity { 
                    Id = 1, 
                    Uuid = Guid.Parse("595980BE-1635-4CA1-987D-EDDBD1FB15D8"), 
                    Name = "Padrão", 
                    Description = "Local de Estoque Padrão", 
                    Status = Util.Enumerartor.EGenericStatus.Ativo }
                
            );
        }
    }
}
