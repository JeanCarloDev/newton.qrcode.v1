using System;
using System.Collections.Generic;
using System.Text;

namespace Newton.ProjetoIntegradorV.QrCode.Domain.Contract
{
    public interface IQrCodeData
    {
        string[] BuscarKeyCode();
    }
}
