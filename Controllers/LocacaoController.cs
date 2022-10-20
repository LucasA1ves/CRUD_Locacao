using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrudLocacao.Controllers
{
    public class LocacaoController : Controller
    {
        [HttpGet("{id}")]
        public async Task<ActionResult<ProdutoVO>> BuscarPorId(long id)
        {
            var produto = await _repository.BuscarPorId(id);

            if (produto == null)
                return NotFound();

            return Ok(produto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoVO>> CadastrarProduto([FromBody] ProdutoVO produtoVO)
        {
            if (produtoVO == null)
                return BadRequest();

            var produto = await _repository.Criar(produtoVO);

            return Ok(produto);
        }

        [HttpPut]
        public async Task<ActionResult<ProdutoVO>> AtualizarProduto([FromBody] ProdutoVO produtoVO)
        {
            if (produtoVO == null)
                return BadRequest();

            var produto = await _repository.Atualizar(produtoVO);
            return Ok(produto);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<ProdutoVO>> DeletarProduto(long id)
        {
            var status = await _repository.Deletar(id);

            if (!status)
                return BadRequest();

            return Ok(status);
        }
    }
}
