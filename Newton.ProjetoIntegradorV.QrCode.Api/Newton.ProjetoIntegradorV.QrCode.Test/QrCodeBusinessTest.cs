using Moq;
using Newton.ProjetoIntegradorV.QrCode.Business;
using Newton.ProjetoIntegradorV.QrCode.Domain.Contract;
using Xunit;

namespace Newton.ProjetoIntegradorV.QrCode.Test
{
    public class QrCodeBusinessTest
    {
        private readonly Mock<IQrCodeData> _qrCodedata;
        private readonly Mock<IQrCodeBusiness> _qrCodebusiness;
        private readonly QrCodeBusiness _subject;
        public QrCodeBusinessTest()
        {
            _qrCodedata = new Mock<IQrCodeData>();
            _subject = new QrCodeBusiness(_qrCodedata.Object);
        }

        [Fact]
        public void Dado_que_a_key_nao_existe()
        {
            // arrange
            string key = "TESTE-PROJ-INTEGRADOR-V";

            // act
            var act = _subject.VerificarKey(key);

            // assert
            Assert.False(act);
        }

    }
}
