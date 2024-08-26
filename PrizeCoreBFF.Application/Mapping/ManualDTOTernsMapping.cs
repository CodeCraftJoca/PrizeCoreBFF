using PrizeCoreBFF.Application.DTO;
using PrizeCoreBFF.ExternalServices.Models;
using System;
using System.Collections.Generic;

namespace PrizeCoreBFF.Application.Mapping
{
    public class ManualDTOTermsMapping
    {
        // Método para mapear um único objeto ExternalTermsModel para termsModelDTO
        public termsModelDTO MapToTermsModelDTO(ExternalTermsModel externalModel)
        {
            if (externalModel == null)
                throw new ArgumentNullException(nameof(externalModel));

            return new termsModelDTO
            {
                TermsId = externalModel.TermsId,
                SessionOfTerms = externalModel.SessionOfTerms,
                Title = externalModel.Title,
                Description = externalModel.Description
            };
        }

        // Método para mapear uma lista de objetos ExternalTermsModel para uma lista de termsModelDTO
        public List<termsModelDTO> MapToTermsModelDTOList(List<ExternalTermsModel> externalModels)
        {
            if (externalModels == null)
                throw new ArgumentNullException(nameof(externalModels));

            var termsModelDTOList = new List<termsModelDTO>();

            foreach (var externalModel in externalModels)
            {
                var termsModelDTO = MapToTermsModelDTO(externalModel);
                termsModelDTOList.Add(termsModelDTO);
            }

            return termsModelDTOList;
        }
    }
}
