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
    public class TarefaCreateCommandHandler : IRequestHandler<TarefaCreateCommand, Tarefa>
    {
        private readonly ITarefaRespository _tarefaRespository;
        public TarefaCreateCommandHandler(ITarefaRespository tarefaRespository)
        {
            _tarefaRespository = tarefaRespository;
        }

        public async Task<Tarefa> Handle(TarefaCreateCommand request, CancellationToken cancellationToken)
        {
            var tarefa = new Tarefa(request.Titulo, request.Descricao, request.PrazoConclusao, request.DataConclusao, request.Concluida);

            if (tarefa == null)
            {
                throw new ApplicationException("Erro na criação da entidade");
            }
            else
            {
                return await _tarefaRespository.CreateAsync(tarefa);
            }
        }
    }
}
