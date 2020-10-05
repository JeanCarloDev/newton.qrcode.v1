using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newton.ProjetoIntegradorV.QrCode.Domain;
using Newton.ProjetoIntegradorV.QrCode.Domain.Contract;
using Swashbuckle.AspNetCore.Annotations;

namespace Newton.ProjetoIntegradorV.QrCode.Api.Controllers
{
    [Route("newton/v1/projeto-integrador-v/qrcode")]
    [ApiController]
    public class QrCodeController : Controller
    {
        private readonly IQrCodeBusiness _qrCodeBusiness;
        /// <summary>
        /// QrCodeController
        /// </summary>
        /// <param name="qrCodeBusiness"></param>
        public QrCodeController(IQrCodeBusiness qrCodeBusiness)
        {
            _qrCodeBusiness = qrCodeBusiness;
        }

        /// <summary>
        /// Obter bitmap QrCode
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [SwaggerResponse(200, Type = typeof(Domain.QrCode))]
        [SwaggerResponse(400, Type = typeof(Error))]
        public async Task<IActionResult> GetQrCode()
        {
            var response = _qrCodeBusiness.RetornarQrCode();
            if (response.qrCode == null)
            {
                Error erro = new Error();
                erro.Code = 100;
                erro.Message = "Não foi possível gerar QrCode.";

                return BadRequest(erro);
            }
            return Ok(response);
        }

        /// <summary>
        /// Validar Key QRCode
        /// </summary>
        /// <param name="key"></param>
        [HttpPost]
        [SwaggerResponse(204)]
        [SwaggerResponse(400, Type = typeof(Error))]
        public async Task<IActionResult> ValidarKey([FromBody] string key)
        {
            var response = _qrCodeBusiness.VerificarKey(key);
            if (!response)
            {
                Error erro = new Error();
                erro.Code = 999;
                erro.Message = "Key não encontrada.";

                return BadRequest(erro);
            }
            return StatusCode(204);
        }
    }
}
