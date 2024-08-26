using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.ExternalServices.Models
{
    public class ExternalLuckyNumberModel
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public DateTime Received { get; set; }
        public Guid PrizeDrawId { get; set; }
    }
}
