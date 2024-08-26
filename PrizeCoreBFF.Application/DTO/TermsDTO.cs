using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.DTO
{
    public class TermsDTO
    {
        public Guid Id { get; set; }
        public List<termsModelDTO> Terms { get; set; }
    }

    public class termsModelDTO
    {
        public Guid TermsId { get; set; }
        public Guid PrizeId { get; set; }
        public string SessionOfTerms { get; set; }
        public string Title { get; set; }
        public List<string> Description { get; set; }

    }
}
