using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.Enum
{
    public class DrawStatusEnum
    {
        public enum DrawStatus
        {
            Pending,
            InProgress,
            Completed,
            Cancelled
        }
    }
}
