using MediatR;
using ThunderTarefas.Application.Tarefas.Queries;
using ThunderTarefas.Domain.Entities;
using ThunderTarefas.Domain.Interfaces;

namespace ThunderTarefas.Application.Tarefas.Handlers
{
    public class GetTarefaByIdQueryHandler : IRequestHandler<GetTarefaByIdQuery, Tarefa>
    {
        private readonly ITarefaRespository _tarefaRespository;
        public GetTarefaByIdQueryHandler(ITarefaRespository tarefaRespository)
        {
            _tarefaRespository = tarefaRespository;
        }
        public async Task<Tarefa> Handle(GetTarefaByIdQuery request, CancellationToken cancellationToken)
        {
            return await _tarefaRespository.GetByIdAsync(request.Id);
        }

    }
}
