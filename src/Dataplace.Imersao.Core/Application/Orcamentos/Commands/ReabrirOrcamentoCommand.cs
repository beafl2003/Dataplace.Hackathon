using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{
    public class ReabrirOrcamentoCommand : UpdateCommand<OrcamentoViewModel>
    {
        public ReabrirOrcamentoCommand(OrcamentoViewModel item) : base(item)
        {
        }
    }

    
}
