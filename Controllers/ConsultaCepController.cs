using CrudLocacao.DTO;
using CrudLocacao.HttpFactory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrudLocacao.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ConsultaCepController : Controller
    {
        [HttpGet("{cep}")]
        public async Task<ActionResult<ResponseConsultaCep>> BuscarCep(long cep)
        {
            ConsultaCep consultarCep = new ConsultaCep();

            var response = await consultarCep.ConsultarCep(Convert.ToString(cep));

            if (response == null)
                return NotFound();

            return Ok(response);
        }

    }
}
