using MediatR;
using ThunderTarefas.Domain.Entities;

namespace ThunderTarefas.Application.Tarefas.Commands
{
    public class TarefaRemoveCommand : IRequest<Tarefa>
    {
        public Guid Id { get; set; }

        public TarefaRemoveCommand(Guid id)
        {
            Id = id;
        }
    }
}
