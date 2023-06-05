using Hedgehogs.Data.Abstract;
using Hedgehogs.Domain.POCO;
using Hedgehogs.Services.Abstract;
using Hedgehogs.Services.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehogs.Services.Implementations
{
    public class HedgehogService : IHedgehogService
    {
        private readonly IHedgehogRepository _repo;

        public HedgehogService(IHedgehogRepository repo)
        {
            _repo = repo;
        }

        public async Task<HttpStatusCode> Create(HedgehogServiceModel hedgehog)
        {
            await _repo.AddAsync(hedgehog.Adapt<Hedgehog>());
            return HttpStatusCode.Created;
        }

        public async Task<List<HedgehogServiceModel>> GetAllAsync()
        {
            var HedgehogList= await _repo.GetAllAsync();

            return HedgehogList.Adapt<List<HedgehogServiceModel>>();
        }

        public async Task<HttpStatusCode> Delete(int id)
        {
            if(await _repo.Exists(id))
            {
                await _repo.DeleteAsync(id);
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.NotFound;
        }

        public async Task<HttpStatusCode> Update(HedgehogServiceModel hedgehog)
        {
            if (await _repo.Exists(hedgehog.Id))
            {
                await _repo.UpdateAsync(hedgehog.Adapt<Hedgehog>());
                return HttpStatusCode.OK;
            }
            return HttpStatusCode.NotFound;
        }
    }
}
