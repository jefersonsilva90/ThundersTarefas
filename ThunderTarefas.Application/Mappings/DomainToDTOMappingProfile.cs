using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ThunderTarefas.Application.DTOs;
using ThunderTarefas.Domain.Entities;

namespace ThunderTarefas.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Tarefa, TarefaDTO>().ReverseMap();
   
        }
    }
}
