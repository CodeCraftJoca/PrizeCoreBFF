using PrizeCoreBFF.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.Interfaces
{
    public interface  IGetPrizeUseCase
    {
        Task<GetPrizeDrawDTO> GetPrizeAsync(int prizeId);
    }
}
