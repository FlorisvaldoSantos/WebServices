using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebServiceAula02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NumerosController : ControllerBase
    {
        /// <summary>
        /// Ordena os números em ordem crescente 
        /// </summary>
        [HttpGet("NumerosCrescente")]
        public ActionResult NumerosCrescente (string entrada)
        {
            try
            {
                if (string.IsNullOrEmpty(entrada))
                    return BadRequest("Informe um texto de entrada.");

                var Vetentrada = entrada.Split(";");

                var VetOrdenado = Vetentrada.OrderBy(e => e);

                return Ok($"Os números ordenados são: { string.Join(";" , VetOrdenado)}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        /// <summary>
        /// Ordena os números em ordem decrescente 
        /// </summary>
        [HttpGet("NumerosDecrescente")]
        public ActionResult NumerosDecrescente(string entrada)
        {
            try
            {
                if (string.IsNullOrEmpty(entrada))
                    return BadRequest("Informe um texto de entrada.");

                var Vetentrada = entrada.Split(";");

                var VetOrdenado = Vetentrada.OrderByDescending(e => e);

                return Ok($"Os números ordenados descresente são: { string.Join(";", VetOrdenado)}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }


        /// <summary>
        /// Identifica os números pares
        /// </summary>
        [HttpGet("NumerosPares")]
        public ActionResult NumerosPares(string entrada)
        {
            try
            {
                if (string.IsNullOrEmpty(entrada))
                    return BadRequest("Informe um texto de entrada.");

                List<string> LstPares = new List<string>();

                var Vetentrada = entrada.Split(";");

                var VetOrdenado = Vetentrada.OrderBy(e => e);

                foreach (var item in VetOrdenado)
                {
                    if(int.Parse(item) % 2 == 0)
                    {
                        LstPares.Add(item);
                    }
                }

                return Ok($"Os números pares são: { string.Join(";", LstPares)}");
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }

        }

    }
}
