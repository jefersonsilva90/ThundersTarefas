using MediatR;
using ThunderTarefas.Domain.Entities;

namespace ThunderTarefas.Application.Tarefas.Queries
{
    public class GetTarefaQuery : IRequest<IEnumerable<Tarefa>>
    {
    }
}
