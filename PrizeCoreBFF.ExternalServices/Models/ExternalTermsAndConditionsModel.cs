using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.ExternalServices.Models
{
    public class ExternalTermsAndConditionsModel
    {
        public Guid Id { get; set; }
        public Guid PrizeId { get; set; }

        public List<ExternalTermsModel> Terms { get; set; }
    }   

    public class ExternalTermsModel
    {
        public Guid TermsId { get; set; }
        public string SessionOfTerms { get; set; }
        public string Title { get; set; }
        public List<string> Description { get; set; }

    }
}
