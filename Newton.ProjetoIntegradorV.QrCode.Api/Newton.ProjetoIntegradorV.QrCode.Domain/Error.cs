using System;
using System.Collections.Generic;
using System.Text;

namespace Newton.ProjetoIntegradorV.QrCode.Domain
{
    public class Error
    {
        public Error()
        {

        }
        /// <summary>
        /// Código do erro
        /// </summary>
        public int? Code { get; set; }
        /// <summary>
        /// Descrição do erro
        /// </summary>
        public string Message { get; set; }
    }
}
