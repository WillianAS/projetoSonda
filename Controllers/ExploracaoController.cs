using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ProjetoSonda.Models;

namespace ProjetoSonda.Controllers
{
    [ApiController]
    [Route("v1/exploracao")]
    public class ExploracaoController : ControllerBase
    {
        public ActionResult<bool> Post([FromBody] Coordenadas model)
        {
            if (ModelState.IsValid)
            {
                return true;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}