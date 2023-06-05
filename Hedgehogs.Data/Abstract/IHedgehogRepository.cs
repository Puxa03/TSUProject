using Hedgehogs.Domain.POCO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehogs.Data.Abstract
{
    public interface IHedgehogRepository
    {
        Task<List<Hedgehog>> GetAllAsync();
        Task AddAsync(Hedgehog hedgehog);

        Task DeleteAsync(int id);

        Task<bool> Exists(int id);

        Task UpdateAsync(Hedgehog hedgehog);
    }
}
