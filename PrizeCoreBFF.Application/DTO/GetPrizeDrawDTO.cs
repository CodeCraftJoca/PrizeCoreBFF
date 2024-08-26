using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.DTO
{
    public class GetPrizeDrawDTO
    {
        public Guid UserId { get; set; }
        public List<PrizeDTO> Prize { get; set; }
        public List<VibeDTO> Vibe { get; set; }
        public int TotalVibes { get; set; }
        public int VibesRemainingForLuckyNumber { get; set; }
        public TermsDTO Terms { get; set; }

    }
}
