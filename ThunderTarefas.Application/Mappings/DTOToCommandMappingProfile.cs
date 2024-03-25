using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderTarefas.Application.DTOs;
using ThunderTarefas.Application.Tarefas.Commands;

namespace ThunderTarefas.Application.Mappings
{
    public class DTOToCommandMappingProfile : Profile
    {
        public DTOToCommandMappingProfile()
        {
            CreateMap<TarefaDTO, TarefaCreateCommand>();
            CreateMap<TarefaDTO, TarefaUpdateCommand>();
        }
    }
}
