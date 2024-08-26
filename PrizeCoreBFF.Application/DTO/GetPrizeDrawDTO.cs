using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.DTO
{
    
        /// <summary>
        /// DTO para obter informações requeridas no endpoint getPrizeDraw.
        /// DTO da camada de negocio
        /// 
        /// </summary>
        public class GetPrizeDrawDTO
        {
            /// <summary>
            /// O identificador único do usuário que está participando do sorteio.
            /// </summary>
            public Guid UserId { get; set; }

            /// <summary>
            /// A lista de prêmios disponíveis no sorteio.
            /// </summary>
            public List<PrizeDTO> Prize { get; set; }

            /// <summary>
            /// A lista de vibrações associadas ao sorteio.
            /// </summary>
            public List<VibeDTO> Vibe { get; set; }

            /// <summary>
            /// O número total de vibrações que o usuário possui.
            /// </summary>
            public int TotalVibes { get; set; }

            /// <summary>
            /// O número de vibrações restantes para ganhar um número da sorte.
            /// </summary>
            public int VibesRemainingForLuckyNumber { get; set; }

            /// <summary>
            /// Os termos e condições associados ao sorteio.
            /// </summary>
            public TermsDTO Terms { get; set; }
        }
    

}

