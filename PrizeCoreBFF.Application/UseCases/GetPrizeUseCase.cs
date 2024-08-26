using AutoMapper;
using PrizeCoreBFF.Application.DTO;
using PrizeCoreBFF.Application.Interfaces;
using PrizeCoreBFF.Application.Mapping;
using PrizeCoreBFF.ExternalServices.InterfaceServices;
using PrizeCoreBFF.ExternalServices.Models;

namespace PrizeCoreBFF.Application.UseCases
{
    /// <summary>
    /// Caso de uso para obter dados de prêmios e informações associadas.
    /// </summary>
    public class GetPrizeUseCase : IGetPrizeUseCase
    {
        private readonly IPrizeDrawConsumerService _prizeDrawConsumerService;
        private readonly ManualDTOMapping _prizeMapper;
        private readonly ManualDTOVibeMapping _vibeMapper;
        private readonly ManualDTOTermsMapping _termsMapper;

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="GetPrizeUseCase"/>.
        /// </summary>
        /// <param name="prizeDrawConsumerService">Serviço para consumir dados de prêmios.</param>
        /// <param name="prizeMapper">Mapeador para conversão de dados de prêmios.</param>
        /// <param name="vibeMapper">Mapeador para conversão de dados de vibes.</param>
        /// <param name="termsMapping">Mapeador para conversão de termos e condições.</param>
        public GetPrizeUseCase(
            IPrizeDrawConsumerService prizeDrawConsumerService,
            ManualDTOMapping prizeMapper,
            ManualDTOVibeMapping vibeMapper,
            ManualDTOTermsMapping termsMapping)
        {
            _prizeDrawConsumerService = prizeDrawConsumerService;
            _prizeMapper = prizeMapper;
            _vibeMapper = vibeMapper;
            _termsMapper = termsMapping;
        }

        /// <summary>
        /// Obtém os dados de prêmios e informações associadas com base no identificador do sorteio.
        /// </summary>
        /// <param name="prizeId">Identificador do prêmio.</param>
        /// <returns>Um <see cref="GetPrizeDrawDTO"/> contendo os dados do sorteio e informações associadas.</returns>
        /// <exception cref="ApplicationException">Lançado quando ocorre um erro ao recuperar os dados do sorteio.</exception>
        public async Task<GetPrizeDrawDTO> GetPrizeAsync(int prizeId)
        {
            try
            {
                var externalModels = await _prizeDrawConsumerService.GetPrizeDrawAsync(prizeId);
                var prizeDTOs = _prizeMapper.MapToPrizeDTOList(externalModels.PrizeDraw);
                var vibeDTO = _vibeMapper.MapToVibeDTOList(externalModels.Vibes);
                var Terms = await _prizeDrawConsumerService.GetTermsAndConditionsAsync(prizeId);
                var termsDTO = _termsMapper.MapToTermsModelDTOList(Terms.Terms);

                foreach (var prizeDTO in prizeDTOs)
                {
                    SetUserStatus(prizeDTO);
                }
                int totalVibes = CalculateTotalVibes(vibeDTO);
                int vibesRemainingForLuckyNumber = CalculateVibesRemainingForLuckyNumber(totalVibes);

                var TernsDTOMapping = new TermsDTO
                {
                    Id = Terms.Id,
                    Terms = termsDTO
                };
                var GetPrizeDrawDTO = new GetPrizeDrawDTO
                {
                    Prize = prizeDTOs,
                    Vibe = vibeDTO,
                    TotalVibes = totalVibes,
                    VibesRemainingForLuckyNumber = vibesRemainingForLuckyNumber,
                    Terms = TernsDTOMapping
                };

                return GetPrizeDrawDTO;
            }
            catch (Exception ex)
            {
                // Log the exception or handle it as appropriate
                throw new ApplicationException("An error occurred while retrieving prize data.", ex);
            }
        }

        /// <summary>
        /// Calcula o total de vibes.
        /// </summary>
        /// <param name="vibes">Lista de vibes.</param>
        /// <returns>Total de vibes.</returns>
        private int CalculateTotalVibes(List<VibeDTO> vibes)
        {
            return vibes.Count;
        }

        /// <summary>
        /// Calcula a quantidade de vibes restantes necessárias para obter um número da sorte.
        /// </summary>
        /// <param name="totalVibes">Total de vibes atuais.</param>
        /// <returns>Quantidade de vibes restantes necessárias.</returns>
        private int CalculateVibesRemainingForLuckyNumber(int totalVibes)
        {
            const int VibesForLuckyNumber = 30;
            return VibesForLuckyNumber - totalVibes;
        }

        /// <summary>
        /// Define o status do usuário para um prêmio baseado em suas condições e números da sorte.
        /// </summary>
        /// <param name="prizeDTO">O DTO do prêmio para o qual o status do usuário será definido.</param>
        private void SetUserStatus(PrizeDTO prizeDTO)
        {
            if (prizeDTO == null)
                throw new ArgumentNullException(nameof(prizeDTO));

            // Verificação do status e participação
            bool isParticipating = prizeDTO.IsParticipating;
            bool hasLuckyNumbers = prizeDTO.LuckyNumbers != null && prizeDTO.LuckyNumbers.Any();
            bool isWinner = hasLuckyNumbers && prizeDTO.LuckyNumbers.Any(luckyNumber => luckyNumber.Number == prizeDTO.WinnerNumber);

            // Definindo o status baseado nas condições
            if (prizeDTO.Status == 1 && isParticipating)
            {
                prizeDTO.UserStatus = "Você está concorrendo";
            }
            else if (prizeDTO.Status == 2 && isParticipating)
            {
                prizeDTO.UserStatus = !hasLuckyNumbers
                    ? "Você ainda não tem Números da sorte"
                    : isWinner
                        ? "Você ganhou!"
                        : "Não foi dessa vez";
            }
            else
            {
                prizeDTO.UserStatus = "Você não está participando";
            }
        }
    }
}
