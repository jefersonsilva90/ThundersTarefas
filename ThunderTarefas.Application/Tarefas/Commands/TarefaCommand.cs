using MediatR;
using ThunderTarefas.Domain.Entities;

namespace ThunderTarefas.Application.Tarefas.Commands
{
    public abstract class TarefaCommand : IRequest<Tarefa>
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime PrazoConclusao { get; private set; }
        public DateTime? DataConclusao { get; private set; }
        public bool Concluida { get; private set; }
    }
}
