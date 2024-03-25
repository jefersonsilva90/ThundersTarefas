using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderTarefas.Application.Tarefas.Commands
{
    public class TarefaUpdateCommand : TarefaCommand
    {
        public Guid Id { get; set; }
    }
}
