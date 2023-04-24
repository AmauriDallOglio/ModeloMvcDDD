using Aplicacao.Aplicacao;
using Dominio.Entidades;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio iRepositorioCategoria;
        private readonly CategoriaAplicacao aplicacaoCategoria;
        public CategoriaController(ICategoriaRepositorio iCategoriaRepositorio)
        {
            iRepositorioCategoria = iCategoriaRepositorio;
            aplicacaoCategoria = new CategoriaAplicacao(iRepositorioCategoria, null);
        }

        [HttpPost("Incluir")]
        public IActionResult Incluir(Categoria categoria)
        {
            try
            {
                Categoria resultado = aplicacaoCategoria.Incluir(categoria);
                return CreatedAtAction(nameof(ObterPorId), new { id = resultado.Id }, resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }

        [HttpPost("Incluir10Registros")]
        public IActionResult Incluir10Registros(Categoria categoria)
        {
            try
            {
                for (int i = 0; i < 10; i++)
                {
                    Categoria nova = new Categoria();
               

                    string tipo = "inserindo api filho " + Convert.ToString(i);
                    nova.Descricao = tipo;
                    Categoria resultado =  aplicacaoCategoria.Incluir(nova);
                }
 
                return Ok();
            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }


        [HttpPut("Alterar")]
        public IActionResult Alterar(int id, Categoria categoria)
        {
            try
            {
                categoria.Id = id;
                Categoria resultado = aplicacaoCategoria.Alterar(categoria);
                return CreatedAtAction(nameof(ObterPorId), new { id = id }, categoria);

            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }


        [HttpDelete("{id}")]
        public IActionResult Excluir(int id, Categoria categoria)
        {
            try
            {
                bool resultado = aplicacaoCategoria.Excluir(id);
                return Ok(resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }

        [HttpGet("ObterPorId")]
        public IActionResult ObterPorId(short id)
        {
            try
            {
                Categoria resultado = aplicacaoCategoria.BuscarPorId(id);
                return Ok(resultado);
            }
            catch (Exception erro)
            {
                return NotFound("Erro:" + erro.Message);
            }
        }





    }
}
