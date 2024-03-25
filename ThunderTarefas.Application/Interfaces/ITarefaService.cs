using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderTarefas.Application.DTOs;

namespace ThunderTarefas.Application.Interfaces
{
    public interface ITarefaService
    {
        Task<IEnumerable<TarefaDTO>> GetTarefas();
        Task<TarefaDTO> GetById(Guid? id);
        Task Add(TarefaDTO tarefaDTO);
        Task Update(TarefaDTO tarefaDTO);
        Task Remove(Guid? id);
    }
}
