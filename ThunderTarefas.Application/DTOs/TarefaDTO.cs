using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThunderTarefas.Application.DTOs
{
    public class TarefaDTO
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = ("Título Requerido"))]
        [MinLength(5)]
        public string Titulo { get; set; }
        [Required(ErrorMessage = ("Descrição Requerida"))]
        [MinLength(10)]
        public string Descricao { get; set; }
        [Required(ErrorMessage = ("Prazo conclusão Requerido"))]
        public DateTime PrazoConclusao { get; set; }
        public DateTime? DataConclusao { get; set; }
        public bool Concluida { get; set; }
    }
}
