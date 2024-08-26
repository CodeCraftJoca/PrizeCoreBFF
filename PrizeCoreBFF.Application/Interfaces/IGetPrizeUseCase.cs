using PrizeCoreBFF.Application.DTO;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.Interfaces
{
    /// <summary>
    /// Interface que define os contratos para obter informações sobre prêmios.
    /// </summary>
    public interface IGetPrizeUseCase
    {
        /// <summary>
        /// Obtém os dados de prêmios e informações associadas com base no identificador do prêmio.
        /// </summary>
        /// <param name="prizeId">Identificador do prêmio.</param>
        /// <returns>Um <see cref="GetPrizeDrawDTO"/> contendo os dados do sorteio e informações associadas.</returns>
        Task<GetPrizeDrawDTO> GetPrizeAsync(int prizeId);
    }
}
