using Hedgehogs.Services.Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Hedgehogs.Services.Abstract
{
    public interface IHedgehogService
    {
        Task<List<HedgehogServiceModel>> GetAllAsync();
        Task<HttpStatusCode> Create(HedgehogServiceModel hedgehog);
        Task<HttpStatusCode> Delete(int id);
        Task<HttpStatusCode> Update(HedgehogServiceModel hedgehog);
    }
}
