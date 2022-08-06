using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{

    public class ExcluirItemCommand : DeleteCommand<OrcamentoItemViewModel>
    {
        public ExcluirItemCommand(OrcamentoItemViewModel item) : base(item)
        {
        }
    }
}
