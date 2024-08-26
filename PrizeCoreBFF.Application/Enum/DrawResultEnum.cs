using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.Enum
{
    public enum DrawResultEnum
    {
        InCompetition, // Você está concorrendo
        NotWon,        // Não foi dessa vez
        Won            // Você ganhou
    }
}
