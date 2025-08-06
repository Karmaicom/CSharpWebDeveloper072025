using AgendaApp.API.Dtos;
using AgendaApp.API.Entities;
using AgendaApp.API.Enums;
using AgendaApp.API.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AgendaApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefasController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] TarefaRequestDto requestDto)
        {
            var tarefaRepository = new TarefaRepository();
            var categoriaRepository = new CategoriaRepository();

            if (!categoriaRepository.CategoriaExiste(requestDto.CategoriaId.Value))
                return NotFound(new { mensagem = "Categoria não encontrada." });

            var tarefa = new Tarefa
            {
                Nome = requestDto.Nome,
                DataHora = DateTime.Parse($"{requestDto.Data} {requestDto.Hora}"),
                Prioridade = (Prioridade) requestDto.Prioridade.Value,
                CategoriaId = requestDto.CategoriaId.Value
            };

            return StatusCode(StatusCodes.Status201Created, new { tarefa.Id, requestDto });

        }

    }
}
