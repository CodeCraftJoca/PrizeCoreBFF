using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.DTO
{
    /// <summary>
    /// Representa um "vibe" associado a um usuário.
    /// </summary>
    public class VibeDTO
    {
        /// <summary>
        /// O identificador único do "vibe".
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// O identificador único do usuário associado ao "vibe".
        /// </summary>
        public Guid UserId { get; set; }
    }

}
