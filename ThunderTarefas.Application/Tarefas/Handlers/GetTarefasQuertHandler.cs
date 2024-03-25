using MediatR;
using ThunderTarefas.Application.Tarefas.Queries;
using ThunderTarefas.Domain.Entities;
using ThunderTarefas.Domain.Interfaces;

namespace ThunderTarefas.Application.Tarefas.Handlers
{
    public class GetTarefasQuertHandler : IRequestHandler<GetTarefaQuery, IEnumerable<Tarefa>>
    {
        private readonly ITarefaRespository _tarefaRespository;
        public GetTarefasQuertHandler(ITarefaRespository tarefaRespository)
        {
            _tarefaRespository = tarefaRespository;
        }

        public async Task<IEnumerable<Tarefa>> Handle(GetTarefaQuery request, CancellationToken cancellationToken)
        {
            return await _tarefaRespository.GetAsync();
        }
    }
}
