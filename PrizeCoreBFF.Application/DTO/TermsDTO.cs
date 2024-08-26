using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrizeCoreBFF.Application.DTO
{
    /// <summary>
    /// Representa os termos e condições associados a um sorteio.
    /// </summary>
    public class TermsDTO
    {
        /// <summary>
        /// O identificador único dos termos e condições.
        /// </summary>
        public Guid Id { get; set; }

        /// <summary>
        /// Lista de termos associados a um prêmio.
        /// </summary>
        public List<termsModelDTO> Terms { get; set; }
    }

    /// <summary>
    /// Representa uma sessão de um termo específico associado a um prêmio.
    /// </summary>
    public class termsModelDTO
    {
        /// <summary>
        /// O identificador único do termo.
        /// </summary>
        public Guid TermsId { get; set; }

        /// <summary>
        /// O identificador do sorteio ao qual o termo está associado.
        /// </summary>
        public Guid PrizeId { get; set; }

        /// <summary>
        /// A sessão ou categoria dos termos.
        /// </summary>
        public string SessionOfTerms { get; set; }

        /// <summary>
        /// O título do termo.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Descrição detalhada do termo.
        /// </summary>
        public List<string> Description { get; set; }
    }

}
