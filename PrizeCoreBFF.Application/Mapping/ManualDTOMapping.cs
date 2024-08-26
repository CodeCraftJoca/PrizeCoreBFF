using PrizeCoreBFF.Application.DTO;
using PrizeCoreBFF.Application.Enum;
using PrizeCoreBFF.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrizeCoreBFF.Application.Enum.DrawStatusEnum;

namespace PrizeCoreBFF.Application.Mapping
{
    public class ManualDTOMapping
    {
            public PrizeDTO MapToPrizeDTO(ExternalPrizeDrawModel externalModel)
            {
                if (externalModel == null)
                    throw new ArgumentNullException(nameof(externalModel));

                return new PrizeDTO
                {
                    Id = externalModel.Id,
                    Status = externalModel.Status,
                    DrawNumber = externalModel.DrawNumber,
                    WinnerNumber = externalModel.WinnerNumber,
                    DateOfDraw = externalModel.DateOfDraw,
                    ResultOfDraw = externalModel.ResultOfDraw,
                    LuckyNumbers = MapToLuckyNumberList(externalModel?.LuckyNumbers),
                    IsParticipating = externalModel.IsParticipating

                };
            }

            public List<PrizeDTO> MapToPrizeDTOList(List<ExternalPrizeDrawModel> externalModels)
            {
                if (externalModels == null)
                    throw new ArgumentNullException(nameof(externalModels));

                var prizeDTOList = new List<PrizeDTO>();

                foreach (var externalModel in externalModels)
                {
                    var prizeDTO = MapToPrizeDTO(externalModel);
                    prizeDTOList.Add(prizeDTO);
                }

                return prizeDTOList;
            }

        private List<LuckyNumberDTO> MapToLuckyNumberList(List<ExternalLuckyNumberModel>? luckyNumbers)
        {
            if (luckyNumbers == null)
                return new List<LuckyNumberDTO>();

            var luckyNumberList = new List<LuckyNumberDTO>();

            foreach (var number in luckyNumbers)
            {
                luckyNumberList.Add(new LuckyNumberDTO
                {
                    Id = number.Id,
                    Number = number.Number,
                    Received = number.Received,
                    PrizeDrawId = number.PrizeDrawId
                });
            }

            return luckyNumberList;
        }
      
    }
}
