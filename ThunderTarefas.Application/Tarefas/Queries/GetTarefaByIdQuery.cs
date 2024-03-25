using MediatR;
using ThunderTarefas.Domain.Entities;

namespace ThunderTarefas.Application.Tarefas.Queries
{
    public class GetTarefaByIdQuery : IRequest<Tarefa>
    {
        public Guid Id { get; set; }

        public GetTarefaByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
