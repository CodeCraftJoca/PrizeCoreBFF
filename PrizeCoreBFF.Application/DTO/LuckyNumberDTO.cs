using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.DTO
{
    // <summary>
    /// Representa um número da sorte associado a um sorteio.
    /// </summary>
    public class LuckyNumberDTO
    {
        /// <summary>
        /// O identificador único do número da sorte.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// O número da sorte.
        /// </summary>
        public int Number { get; set; }

        /// <summary>
        /// A data e hora em que o número da sorte foi recebido.
        /// </summary>
        public DateTime Received { get; set; }

        /// <summary>
        /// O identificador do sorteio ao qual este número da sorte está associado.
        /// </summary>
        public Guid PrizeDrawId { get; set; }
    }
}
