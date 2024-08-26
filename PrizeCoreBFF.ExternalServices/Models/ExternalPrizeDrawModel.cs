using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.ExternalServices.Models
{
    public class ExternalPrizeDrawModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public int Status { get; set; }
        public int DrawNumber { get; set; }
        public int? WinnerNumber { get; set; }
        public bool IsParticipating { get; set; }
        public List<ExternalLuckyNumberModel>? LuckyNumbers { get; set; }
        public DateTime DateOfDraw { get; set; }
        public int? ResultOfDraw { get; set; }
    }


}
