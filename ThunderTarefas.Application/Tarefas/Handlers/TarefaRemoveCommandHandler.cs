using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderTarefas.Application.Tarefas.Commands;
using ThunderTarefas.Domain.Entities;
using ThunderTarefas.Domain.Interfaces;

namespace ThunderTarefas.Application.Tarefas.Handlers
{
    public class TarefaRemoveCommandHandler : IRequestHandler<TarefaRemoveCommand, Tarefa>
    {
        private readonly ITarefaRespository _tarefaRespository;
        public TarefaRemoveCommandHandler(ITarefaRespository tarefaRespository)
        {
            _tarefaRespository = tarefaRespository;
        }

        public async Task<Tarefa> Handle(TarefaRemoveCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRespository.GetByIdAsync(request.Id);

            if (tarefa == null)
            {
                throw new ApplicationException("Erro na criação da entidade");
            }
            else
            {
                return await _tarefaRespository.RemoveAsync(tarefa);
            }
        }
    }
}
