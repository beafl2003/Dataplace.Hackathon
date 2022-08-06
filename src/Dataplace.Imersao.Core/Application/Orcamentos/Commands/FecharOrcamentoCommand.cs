using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{

    public class FecharOrcamentoCommand : UpdateCommand<OrcamentoViewModel>
    {
        public FecharOrcamentoCommand(OrcamentoViewModel item) : base(item)
        {
        }
    }
}
