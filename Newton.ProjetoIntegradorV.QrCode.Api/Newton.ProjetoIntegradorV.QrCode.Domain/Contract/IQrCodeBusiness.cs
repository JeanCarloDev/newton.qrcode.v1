using System;
using System.Collections.Generic;
using System.Text;

namespace Newton.ProjetoIntegradorV.QrCode.Domain.Contract
{
    public interface IQrCodeBusiness
    {
        Domain.QrCode RetornarQrCode();
        bool VerificarKey(string key);
    }
}
