using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderTarefas.Application.DTOs;
using ThunderTarefas.Application.Interfaces;
using ThunderTarefas.Application.Tarefas.Commands;
using ThunderTarefas.Application.Tarefas.Queries;

namespace ThunderTarefas.Application.Services
{
    public class TarefaService : BaseService, ITarefaService
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TarefaService(IMediator mediator, IMapper mapper, INotificador notificador) : base(notificador)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public async Task Add(TarefaDTO tarefaDTO)
        {
            var tarefaEntity = _mapper.Map<TarefaCreateCommand>(tarefaDTO);
            await _mediator.Send(tarefaEntity);
        }

        public async Task<TarefaDTO> GetById(Guid? id)
        {
            var tarefaByIdQuery = new GetTarefaByIdQuery(id.Value);

            if (tarefaByIdQuery == null)
                Notificar("Entidade não carregada");

            var result = await _mediator.Send(tarefaByIdQuery);

            return _mapper.Map<TarefaDTO>(result);
        }

        public async Task<IEnumerable<TarefaDTO>> GetTarefas()
        {
            var tarefaQuery = new GetTarefaQuery();

            if (tarefaQuery == null)
                Notificar("Entidade não carregada");


            var result = await _mediator.Send(tarefaQuery);

            return _mapper.Map<IEnumerable<TarefaDTO>>(result);
        }

        public async Task Remove(Guid? id)
        {
            var tarefaRemoveCommand = new TarefaRemoveCommand(id.Value);
            if (tarefaRemoveCommand == null)
                Notificar("Entidade não carregada");


            await _mediator.Send(tarefaRemoveCommand);
        }

        public async Task Update(TarefaDTO tarefaDTO)
        {
            var tarefaUpdateCommand = _mapper.Map<TarefaUpdateCommand>(tarefaDTO);
            await _mediator.Send(tarefaUpdateCommand);
        }
    }
}
