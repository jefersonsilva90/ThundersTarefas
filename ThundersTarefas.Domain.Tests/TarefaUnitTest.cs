using FluentAssertions;
using ThunderTarefas.Domain.Entities;
using ThunderTarefas.Domain.Validation;

namespace ThundersTarefas.Domain.Tests
{
    public class TarefaUnitTest
    {
        [Fact]
        public void Tarefa_ConcluirSemDataDeConclusao_ObjetoComEstadoInvalido()
        {
            Action action = () => new Tarefa("Realizar Atividade de teste da Thunder",
                                            "Realizar Atividade de teste da Thunder e enviar ate segunda feira ",
                                            new DateTime(),
                                            null,
                                            true);
            action.Should().Throw<DomainExceptionValidation>()
           .WithMessage("Situação invalida. Não é possível concluir tarefa sem data de conclusão");
        }
        [Fact]
        public void Tarefa_PreencherDataConclusaoSemConcluir_ObjetoComEstadoInvalido()
        {
            Action action = () => new Tarefa("Realizar Atividade de teste da Thunder",
                                            "Realizar Atividade de teste da Thunder e enviar ate segunda feira ",
                                            new DateTime(),
                                             new DateTime(),
                                            false);
            action.Should().Throw<DomainExceptionValidation>()
           .WithMessage("Situação invalida. Não é possível preencher a data de conclusão sem concluir a tarefa");
        }
    }
}
