
using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using MediatR.Extensions.AttributedBehaviors;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{
    public class ExcluirOrcamentoCommand : DeleteCommand<OrcamentoViewModel>
    {
        public ExcluirOrcamentoCommand(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
