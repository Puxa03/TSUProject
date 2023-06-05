using Hedgehogs.Data;
using Hedgehogs.Data.Abstract;
using Hedgehogs.Domain.POCO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehogs.DataEF.Implementations
{
    public class HedgehogRepository : IHedgehogRepository
    {
        private readonly IBaseRepository<Hedgehog> _baseRepo;

        public HedgehogRepository(IBaseRepository<Hedgehog> baseRepo)
        {
            _baseRepo = baseRepo;
        }

        public async Task<List<Hedgehog>> GetAllAsync()
        {
            return await _baseRepo.GetAllAsync();
        }

        public async Task AddAsync(Hedgehog hedgehog)
        {
            await _baseRepo.AddAsync(hedgehog);
        }

        public async Task<bool> Exists(int id)
        {
            return await _baseRepo.Exists(h => h.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            await _baseRepo.DeleteAsync(id);
        }

        public async Task UpdateAsync(Hedgehog hedgehog)
        {
            await _baseRepo.UpdateAsync(hedgehog);
        }
    }
}
