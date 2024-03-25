using Microsoft.AspNetCore.Mvc;
using ThunderTarefas.Application.DTOs;
using ThunderTarefas.Application.Interfaces;

namespace ThundersTarefas.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : MainController
    {
        private readonly ITarefaService _tarefaService;

        public TarefaController(ITarefaService tarefaService, INotificador notificador) : base(notificador)
        {
            _tarefaService = tarefaService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TarefaDTO tarefaDTO)
        {
            if (tarefaDTO == null)
            {
                NotificarErro("Dado Inválido");
                return CustomResponse(tarefaDTO);
            }

            await _tarefaService.Add(tarefaDTO);

            return new CreatedAtRouteResult("GetTarefas",
                new { id = tarefaDTO.Id }, tarefaDTO);
        }


        [HttpGet("{id}", Name = "GetTarefas")]
        public async Task<ActionResult<TarefaDTO>> Get(Guid id)
        {
            var tarefa = await _tarefaService.GetById(id);
            if (tarefa == null)
            {
                NotificarErro("Tarefa não encontrada");
                return CustomResponse(id);
            }
            return CustomResponse(tarefa);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TarefaDTO>>> Get()
        {
            var tarefa = await _tarefaService.GetTarefas();
            if (tarefa == null)
            {
                NotificarErro("Tarefa não encontrada");
                return CustomResponse();
            }
            return CustomResponse(tarefa);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(Guid id, [FromBody] TarefaDTO tarefaDTO)
        {
            if (id != tarefaDTO.Id)
            {
                NotificarErro("Dado Inválido");
                return CustomResponse(tarefaDTO);
            }

            if (tarefaDTO == null)
            {
                NotificarErro("Dado Inválido");
                return CustomResponse(tarefaDTO);
            }

            await _tarefaService.Update(tarefaDTO);

            return CustomResponse(tarefaDTO);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<TarefaDTO>> Delete(Guid id)
        {
            var tarefaDTO = await _tarefaService.GetById(id);

            if (tarefaDTO == null)
            {
                NotificarErro("Tarefa não enctrado");
                return CustomResponse(id);
            }

            await _tarefaService.Remove(id);

            return CustomResponse(tarefaDTO);
        }

    }
}
