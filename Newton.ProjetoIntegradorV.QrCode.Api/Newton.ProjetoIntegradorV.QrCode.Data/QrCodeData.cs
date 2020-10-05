using Newton.ProjetoIntegradorV.QrCode.Domain.Contract;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Newton.ProjetoIntegradorV.QrCode.Data
{
    public class QrCodeData : IQrCodeData
    {
        public QrCodeData()
        {

        }

        private readonly string[] keyCode = new string[] {
            "ABCDE-12345-A2A4",
            "EDASA-85987-A1A4",
            "OSIXV-23497-A4A4",
            "POQWE-32184-A3A4"
        };

        public string[] BuscarKeyCode()
        {
            return keyCode;
        }
    }
}
