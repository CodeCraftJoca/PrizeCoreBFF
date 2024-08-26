using AutoMapper;
using PrizeCoreBFF.Application.DTO;
using PrizeCoreBFF.ExternalServices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.Mapping
{
    public class DTOMapping: Profile
    {
        public DTOMapping()
        {
            CreateMap<ExternalPrizeDrawModel, PrizeDTO>()
                .ForMember(dest => dest.DrawNumber, opt => opt.MapFrom(src => src.DrawNumber))
                .ForMember(dest => dest.DateOfDraw, opt => opt.MapFrom(src => src.DateOfDraw))
                .ForMember(dest => dest.ResultOfDraw, opt => opt.MapFrom(src => src.ResultOfDraw))
                .ForMember(dest => dest.LuckyNumbers, opt => opt.MapFrom(src => src.LuckyNumbers))
                .ForMember(dest => dest.IsParticipating, opt => opt.MapFrom(src => src.IsParticipating));
        }
    }
    
}
