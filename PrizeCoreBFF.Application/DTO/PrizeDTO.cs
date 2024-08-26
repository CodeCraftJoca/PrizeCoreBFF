using PrizeCoreBFF.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static PrizeCoreBFF.Application.Enum.DrawStatusEnum;

namespace PrizeCoreBFF.Application.DTO
{
    public class PrizeDTO
    {
        public Guid Id { get; set; }
        public int Status { get; set; }
        public string UserStatus { get; set; }
        public int DrawNumber { get; set; }
        public DateTime DateOfDraw { get; set; }
        public int? ResultOfDraw { get; set; }
        public List<LuckyNumberDTO>? LuckyNumbers { get; set; }
        public int? WinnerNumber { get; set;} 
        public string Winner { get; set; }
        public bool IsParticipating { get; set; }
    }
}
