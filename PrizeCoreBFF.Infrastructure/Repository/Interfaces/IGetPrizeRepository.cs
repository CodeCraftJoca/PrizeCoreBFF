using PrizeCoreBFF.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Infrastructure.Repository.Interfaces
{
    public interface IGetPrizeRepository
    {
        Task<PrizeDTO> GetPrizeAsync(int prizeId);
    }
}
