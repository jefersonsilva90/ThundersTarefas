using ThunderTarefas.Domain.Validation;

namespace ThunderTarefas.Domain.Entities
{
    public sealed class Tarefa : Entity
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public DateTime PrazoConclusao { get; private set; }
        public DateTime? DataConclusao { get; private set; }
        public bool Concluida { get; private set; }
        public Tarefa(string titulo, string descricao, DateTime prazoConclusao, DateTime? dataConclusao, bool concluida)
        {
            ValidateDomain(titulo, descricao, prazoConclusao, dataConclusao, concluida);
        }
        public void Update(string titulo, string descricao, DateTime prazoConclusao, DateTime? dataConclusao, bool concluida)
        {
            ValidateDomain(titulo, descricao, prazoConclusao, dataConclusao, concluida);
        }
        private void ValidateDomain(string titulo, string descricao, DateTime prazoConclusao, DateTime? dataConclusao, bool concluida = false)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(titulo),
                "Título inválido. Título é requerido");

            DomainExceptionValidation.When(titulo.Length < 5,
                "Título inválido, Título requer pelo menos 5 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao),
                "Descriçao inválida. Descrição é requerida");

            DomainExceptionValidation.When(descricao.Length < 10,
                "Descriçao inválida, Descrição requer pelo menos 10 caracteres");

            DomainExceptionValidation.When(string.IsNullOrEmpty(prazoConclusao.ToString()),
                "Prazo Conclusão inválido. Prazo Conclusão é requerido");

            DomainExceptionValidation.When((string.IsNullOrEmpty(dataConclusao.ToString()) && (concluida)),
                "Situação invalida. Não é possível concluir tarefa sem data de conclusão");

            DomainExceptionValidation.When(!(string.IsNullOrEmpty(dataConclusao.ToString()) && (!concluida)),
                 "Situação invalida. Não é possível preencher a data de conclusão sem concluir a tarefa");

            Titulo = titulo;
            Descricao = descricao;
            PrazoConclusao = prazoConclusao;
            DataConclusao = dataConclusao;
            Concluida = concluida;
        }
    }
}
