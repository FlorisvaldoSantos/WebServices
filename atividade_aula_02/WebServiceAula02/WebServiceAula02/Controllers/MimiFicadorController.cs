using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebServiceAula02.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MimiFicadorController : ControllerBase
    {
        private const string ExpressaoRegular = "[aeiouAEIOUáéíóúÁÉÍÓÚâêîôûÂÊÎÔÛ]";

        /// <summary>
        /// Troca as vogais por I em qualquer texto 
        /// </summary>
        [HttpGet("Mimificador")]
        public ActionResult Mimificador (string entrada)
        {
            try
            {
                if (string.IsNullOrEmpty(entrada)) 
                    return BadRequest("Informe um texto de entrada.");

                                
                return Ok(Regex.Replace(entrada, ExpressaoRegular, "I"));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
            
        }

       
    }
}
