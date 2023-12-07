using Database;
using Domain.Entities.Fiancial;
using Domain.Interface.Repository.Financial;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Financial
{
    public class FinancialReleaseTypeRepository : IFinancialReleaseTypeRepository
    {
        public readonly AppDbContext _context;
        public FinancialReleaseTypeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<FinancialReleaseTypeEntity> Create(FinancialReleaseTypeEntity transactionType)
        {
            _context.FinancialReleaseTypes.Add(transactionType);

            return transactionType;
        }

        public async Task Delete(Guid uuid)
        {
            var transactionTypeDelete = await _context.FinancialReleaseTypes.FirstOrDefaultAsync(c => c.Uuid == uuid);
            _context.FinancialReleaseTypes.Remove(transactionTypeDelete);
        }

        public async Task<IEnumerable<FinancialReleaseTypeEntity>> Get()
        {
            return await _context.FinancialReleaseTypes.ToListAsync();
        }

        public async Task<FinancialReleaseTypeEntity> Get(Guid uuid)
        {
            var transactionType = await _context.FinancialReleaseTypes.FirstOrDefaultAsync(c => c.Uuid == uuid);
            return transactionType;
        }

        public async Task<FinancialReleaseTypeEntity> Update(FinancialReleaseTypeEntity transactionType)
        {
            _context.Entry(transactionType).State = EntityState.Modified;
            return transactionType;
        }
    }
}
