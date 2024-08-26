using PrizeCoreBFF.Application.DTO;
using PrizeCoreBFF.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.Mapping
{
    public class ManualDTOVibeMapping
    {
        public VibeDTO MapToVibeDTO(ExternalVibesModel externalModel)
        {
            if (externalModel == null)
                throw new ArgumentNullException(nameof(externalModel));

            return new VibeDTO
            {
                Id = externalModel.Id,
                UserId = externalModel.UserID
            };
        }

        public List<VibeDTO> MapToVibeDTOList(List<ExternalVibesModel> externalModels)
        {
            if (externalModels == null)
                throw new ArgumentNullException(nameof(externalModels));

            var vibeDTOList = new List<VibeDTO>();

            foreach (var externalModel in externalModels)
            {
                var vibeDTO = MapToVibeDTO(externalModel);
                vibeDTOList.Add(vibeDTO);
            }

            return vibeDTOList;
        }
    }
}
