using Dataplace.Core.Domain.Query;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using System.Collections.Generic;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Queries
{
    public class OrcamentoItemQuery : QuerySort<IEnumerable<OrcamentoItemViewModel>>, IQuerySort<IEnumerable<OrcamentoItemViewModel>>
    {
        public int NumOrcamento { get; set; }
    }


}
