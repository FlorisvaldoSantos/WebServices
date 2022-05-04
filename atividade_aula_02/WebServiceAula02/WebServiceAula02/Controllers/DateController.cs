using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Globalization;

namespace WebServiceAula02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DateController : ControllerBase
    {
        private const int SEMANA = 7;
        private const int NUMERO_DIAS_ANO = 365; 
        private const int MESES = 12;

        /// <summary>
        /// Data padrão Brasil 
        /// </summary>
        [HttpGet]
        [Route("DiferencaEntreDatas")]
        public IActionResult DiferencaEntreDatas (string DataIncial, string DataFinal)
        {
            try
            {
                if (DataIncial == null) return BadRequest("Informe a data inicial");
                if (DataFinal == null) return BadRequest("Informe a data final");

                DateTime dInicial, dFinal;
                dInicial = DateTime.Parse(DataIncial, new CultureInfo("pt-BR"));
                dFinal = DateTime.Parse(DataFinal, new CultureInfo("pt-BR"));

                var retorno = $"A diferença entre as data em Dias é: {(dFinal - dInicial).TotalDays} ";

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Data padrão Brasil 
        /// </summary>
        [HttpGet]
        [Route("DiferencaEntreSemanas")]
        public ActionResult DiferencaEntreSemanas(string DataIncial, string DataFinal)
        {
            try
            {
                if (DataIncial == null) return BadRequest("Informe a data inicial");
                if (DataFinal == null) return BadRequest("Informe a data final");

                DateTime dInicial, dFinal;
                dInicial = DateTime.Parse(DataIncial, new CultureInfo("pt-BR"));
                dFinal = DateTime.Parse(DataFinal, new CultureInfo("pt-BR"));

                var retorno = $"A diferença entre as data em semanas é: { Math.Round(((dFinal - dInicial).TotalDays / SEMANA),0)} ";

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Data padrão Brasil 
        /// </summary>
        [HttpGet]
        [Route("DiferencaEntreMeses")]
        public ActionResult DiferencaEntreMeses(string DataIncial, string DataFinal)
        {
            try
            {
                if (DataIncial == null) return BadRequest("Informe a data inicial");
                if (DataFinal == null) return BadRequest("Informe a data final");

                DateTime dInicial, dFinal;
                dInicial = DateTime.Parse(DataIncial, new CultureInfo("pt-BR"));
                dFinal = DateTime.Parse(DataFinal, new CultureInfo("pt-BR"));

                var Nmeses = (int)(dFinal.Subtract(dInicial).Days / (NUMERO_DIAS_ANO / MESES));
                var retorno = $"A diferença entre de datas em Meses é: {Nmeses} ";

                return Ok(retorno);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}
