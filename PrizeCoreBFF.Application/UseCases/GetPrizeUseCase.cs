using AutoMapper;
using PrizeCoreBFF.Application.DTO;
using PrizeCoreBFF.Application.Interfaces;
using PrizeCoreBFF.Application.Mapping;
using PrizeCoreBFF.ExternalServices.InterfaceServices;
using PrizeCoreBFF.ExternalServices.Models;

namespace PrizeCoreBFF.Application.UseCases
{

    public class GetPrizeUseCase : IGetPrizeUseCase
    {
        private readonly IPrizeDrawConsumerService _prizeDrawConsumerService;
        private readonly ManualDTOMapping _prizeMapper;
        private readonly ManualDTOVibeMapping _vibeMapper;
        private readonly ManualDTOTermsMapping _termsMapper;


        public GetPrizeUseCase(IPrizeDrawConsumerService prizeDrawConsumerService, ManualDTOMapping prizeMapper, ManualDTOVibeMapping vibeMapper, ManualDTOTermsMapping termsMapping)
        {
            _prizeDrawConsumerService = prizeDrawConsumerService;
            _prizeMapper = prizeMapper;
            _vibeMapper = vibeMapper;
            _termsMapper = termsMapping;
        }

        public async Task<GetPrizeDrawDTO> GetPrizeAsync(int prizeId)
        {
            try
            {
                var externalModels = await _prizeDrawConsumerService.GetPrizeDrawAsync(prizeId);
                var prizeDTOs = _prizeMapper.MapToPrizeDTOList(externalModels.PrizeDraw);
                var vibeDTO = _vibeMapper.MapToVibeDTOList(externalModels.Vibes);
                var Terms = _prizeDrawConsumerService.GetTermsAndConditionsAsync(prizeId);
                var termsDTO = _termsMapper.MapToTermsModelDTOList(Terms.Result.Terms);

                foreach (var prizeDTO in prizeDTOs)
                {
                     SetUserStatus(prizeDTO);
                      }
                int totalVibes = CalculateTotalVibes(vibeDTO);
                int vibesRemainingForLuckyNumber = CalculateVibesRemainingForLuckyNumber(totalVibes);

                var TernsDTOMapping = new TermsDTO
                {
                    Id = Terms.Result.Id,
                    Terms = termsDTO
                };
                var GetPrizeDrawDTO = new GetPrizeDrawDTO
                {
                    Prize = prizeDTOs,
                    Vibe = vibeDTO,
                    TotalVibes = CalculateTotalVibes(vibeDTO),
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


        private int CalculateTotalVibes(List<VibeDTO> vibes)
        {
            return vibes.Count;
        }

        private int CalculateVibesRemainingForLuckyNumber(int totalVibes)
        {
            const int VibesForLuckyNumber = 30;
            return VibesForLuckyNumber - totalVibes;
        }



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
                prizeDTO.UserStatus = "Voce não está participando";
            }
        }
    }
}
