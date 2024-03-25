using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderTarefas.Data.Context;
using ThunderTarefas.Domain.Entities;
using ThunderTarefas.Domain.Interfaces;

namespace ThunderTarefas.Data.Repositories
{
    public class TarefaRepository : ITarefaRespository
    {
        private ApplicationDbContext _tarefaContext;
        public TarefaRepository(ApplicationDbContext context)
        {
            _tarefaContext = context;
        }
        public async Task<Tarefa> CreateAsync(Tarefa tarefa)
        {
            _tarefaContext.Add(tarefa);
            await _tarefaContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<IEnumerable<Tarefa>> GetAsync()
        {
            return await _tarefaContext.Tarefas.ToListAsync();
        }

        public async Task<Tarefa> GetByIdAsync(Guid? id)
        {
            return await _tarefaContext.Tarefas.FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Tarefa> RemoveAsync(Tarefa tarefa)
        {
            _tarefaContext.Remove(tarefa);
            await _tarefaContext.SaveChangesAsync();
            return tarefa;
        }

        public async Task<Tarefa> UpdateAsync(Tarefa tarefa)
        {
            _tarefaContext.Update(tarefa);
            await _tarefaContext.SaveChangesAsync();
            return tarefa;
        }
    }
}
