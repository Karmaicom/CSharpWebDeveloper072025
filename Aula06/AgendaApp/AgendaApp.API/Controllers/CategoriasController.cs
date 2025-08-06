using AgendaApp.API.Dtos;
using AgendaApp.API.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAll()
        {
            var categoriaRepository = new CategoriaRepository();
            var categorias = categoriaRepository.ObterTodos();

            return Ok(categorias);
        }

        [HttpPost]
        public IActionResult Post([FromBody] TarefaRequestDto requestDto)
        {
            return Ok();
        }

        [HttpPut]
        public IActionResult Put()
        {
            return Ok();
        }

        [HttpDelete]
        public IActionResult Delete()
        {
            return Ok();
        }
    }
}
