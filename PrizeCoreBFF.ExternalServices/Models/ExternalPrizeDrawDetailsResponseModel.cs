using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.ExternalServices.Models
{
    public class ExternalPrizeDrawDetailsResponseModel
    {
        public List<ExternalPrizeDrawModel> PrizeDraw { get; set; }
        public List<ExternalVibesModel> Vibes { get; set; }
        public ExternalTermsAndConditionsModel TermsAndConditions { get; set; }

    }
}
