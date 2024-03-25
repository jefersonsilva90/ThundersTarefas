using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderTarefas.Domain.Entities;

namespace ThunderTarefas.Domain.Interfaces
{
    public interface ITarefaRespository
    {
        Task<Tarefa> GetByIdAsync(Guid? id);
        Task<Tarefa> CreateAsync(Tarefa tarefa);
        Task<Tarefa> UpdateAsync(Tarefa tarefa);
        Task<Tarefa> RemoveAsync(Tarefa tarefa);
        Task<IEnumerable<Tarefa>> GetAsync();
    }
}
