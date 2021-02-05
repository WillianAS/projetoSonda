using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjetoSonda.Models;

namespace ProjetoSonda.Controllers
{
    [ApiController]
    [Route("v1/exploracao")]
    public class ExploracaoController : ControllerBase
    {
        private const string planaltoRetanguarMsg = "As coordenadas X e Y da area do planalto precisam ser diferentes entre si";
        public ActionResult<List<Sonda>> Post([FromBody] Planalto planalto)
        {
            List<Sonda> resultadoExploracao = new List<Sonda>();

            if (ModelState.IsValid)
            {
                if (planalto.ehRetangular(planalto))
                {
                    foreach(var sonda in planalto.sondas)
                    {
                        resultadoExploracao.Add(sonda.explorar(sonda, planalto));
                    }

                    return resultadoExploracao;
                }
                else
                {
                    return BadRequest(planaltoRetanguarMsg);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}