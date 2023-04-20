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
            aplicacaoCategoria = new CategoriaAplicacao(iRepositorioCategoria);
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
