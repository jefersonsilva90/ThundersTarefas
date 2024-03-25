using MediatR;
using ThunderTarefas.Application.Tarefas.Commands;
using ThunderTarefas.Domain.Entities;
using ThunderTarefas.Domain.Interfaces;


namespace ThunderTarefas.Application.Tarefas.Handlers
{
    public class TarefaUpdateCommanHandler : IRequestHandler<TarefaUpdateCommand, Tarefa>
    {
        private readonly ITarefaRespository _tarefaRespository;
        public TarefaUpdateCommanHandler(ITarefaRespository tarefaRespository)
        {
            _tarefaRespository = tarefaRespository;
        }

        public async Task<Tarefa> Handle(TarefaUpdateCommand request, CancellationToken cancellationToken)
        {
            var tarefa = await _tarefaRespository.GetByIdAsync(request.Id);

            if (tarefa == null)
            {
                throw new ApplicationException("Erro na criação da entidade");
            }
            else
            {
                tarefa.Update(request.Titulo, request.Descricao, request.PrazoConclusao, request.DataConclusao, request.Concluida);
                return await _tarefaRespository.UpdateAsync(tarefa);
            }
        }
    }
}
