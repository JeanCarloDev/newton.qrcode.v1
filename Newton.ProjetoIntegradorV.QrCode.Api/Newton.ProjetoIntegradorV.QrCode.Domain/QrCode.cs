using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Newton.ProjetoIntegradorV.QrCode.Domain
{
    public class QrCode
    {
        /// <summary>
        /// Bitmap que contém o QrCode
        /// </summary>
        public Bitmap qrCode { get; set; }

        /// <summary>
        /// Data/Hora da geração do QrCode
        /// </summary>
        public DateTime dataGeracao { get; set; }
        /// <summary>
        /// Quantidade de segundos no qual o QrCode é válido
        /// </summary>
        public int segundosValidos { get; set; }
    }
}
