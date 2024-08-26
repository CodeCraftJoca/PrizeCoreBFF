using PrizeCoreBFF.Application.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static PrizeCoreBFF.Application.Enum.DrawStatusEnum;

namespace PrizeCoreBFF.Application.DTO
{
    /// <summary>
    /// Representa as informações de um sorteio.
    /// </summary>
    public class PrizeDTO
    {
        /// <summary>
        /// O identificador único do sorteio.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// O status do prêmio, representado como um valor inteiro.
        /// Pending = 0, InProgress = 1, Completed = 2, Cancelled = 3,
        /// </summary>
        public int Status { get; set; }

        /// <summary>
        /// O status do usuário relacionado ao prêmio.
        /// Você está concorrendo,Você ainda não tem Números da sorte, Você ganhou!, Não foi dessa vez, Voce não está participando
        /// </summary>
        public string UserStatus { get; set; }

        /// <summary>
        /// O número do sorteio ao qual o prêmio está associado.
        /// </summary>
        public int DrawNumber { get; set; }

        /// <summary>
        /// A data do sorteio.
        /// </summary>
        public DateTime DateOfDraw { get; set; }

        /// <summary>
        /// O resultado do sorteio, se disponível.
        /// </summary>
        public int? ResultOfDraw { get; set; }

        /// <summary>
        /// Lista de números da sorte associados ao prêmio.
        /// </summary>
        public List<LuckyNumberDTO>? LuckyNumbers { get; set; }

        /// <summary>
        /// O número do vencedor, se disponível.
        /// </summary>
        public int? WinnerNumber { get; set; }

        /// <summary>
        /// O nome do vencedor.
        /// </summary>
        public string Winner { get; set; }

        /// <summary>
        /// Indica se o usuario tá participando do sorteio.
        /// </summary>
        public bool IsParticipating { get; set; }
    }

}
