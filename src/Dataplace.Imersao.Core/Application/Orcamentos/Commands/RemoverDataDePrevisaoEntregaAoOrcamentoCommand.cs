using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{
    public class RemoverDataDePrevisaoEntregaAoOrcamentoCommand : UpdateCommand<OrcamentoViewModel>
    {
        public RemoverDataDePrevisaoEntregaAoOrcamentoCommand(OrcamentoViewModel item) : base(item)
        {

        }
    }
}
