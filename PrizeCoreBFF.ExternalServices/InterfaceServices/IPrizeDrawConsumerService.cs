using PrizeCoreBFF.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.ExternalServices.InterfaceServices
{
    public interface IPrizeDrawConsumerService
    {
        Task<ExternalPrizeDrawDetailsResponseModel> GetPrizeDrawAsync(int prizeId);
        Task<ExternalTermsAndConditionsModel> GetTermsAndConditionsAsync(int prizeId);
    }
}
