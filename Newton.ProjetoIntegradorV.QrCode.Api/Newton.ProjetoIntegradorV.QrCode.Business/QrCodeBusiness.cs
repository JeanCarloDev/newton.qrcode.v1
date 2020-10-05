using Newton.ProjetoIntegradorV.QrCode.Domain.Contract;
using QRCoder;
using System;
using System.Drawing;
using System.Linq;

namespace Newton.ProjetoIntegradorV.QrCode.Business
{
    public class QrCodeBusiness : IQrCodeBusiness
    {
        private readonly IQrCodeData _qrCodeData;
        public QrCodeBusiness(IQrCodeData qrCodeData)
        {
            _qrCodeData = qrCodeData;
        }
        private readonly int qtdSegundos = 180;

        public Domain.QrCode RetornarQrCode()
        {
            // Busca chaves
            Domain.QrCode qrCodeResponse = new Domain.QrCode();
            var keyCodes = _qrCodeData.BuscarKeyCode();
            int qtd = keyCodes.Length;

            // Seleciona uma chave qualquer
            Random randNum = new Random();
            var item = randNum.Next(0, qtd - 1);

            qrCodeResponse.segundosValidos = qtdSegundos;
            qrCodeResponse.dataGeracao = DateTime.Now;

            // Gera bitmap
            QRCodeGenerator qrGenerator = new QRCodeGenerator();
            QRCodeData qrCodeData = qrGenerator.CreateQrCode(keyCodes[item], QRCodeGenerator.ECCLevel.Q);
            QRCode qrCode = new QRCode(qrCodeData);
            Bitmap qrCodeImage = qrCode.GetGraphic(20);

            qrCodeResponse.qrCode = qrCodeImage;

            return qrCodeResponse;
        }

        public bool VerificarKey(string key)
        {
            // Busca chaves
            Domain.QrCode qrCodeResponse = new Domain.QrCode();
            var keyCodes = _qrCodeData.BuscarKeyCode();

            var response = (keyCodes.Contains(key));

            return response;

        }

    }
}
