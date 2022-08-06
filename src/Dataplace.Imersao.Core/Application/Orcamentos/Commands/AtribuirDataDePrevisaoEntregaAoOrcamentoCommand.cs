using Dataplace.Core.Domain.Commands;
using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using System;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Commands
{
    public class AtribuirDataDePrevisaoEntregaAoOrcamentoCommand : UpdateCommand<OrcamentoViewModel>
    {
        public AtribuirDataDePrevisaoEntregaAoOrcamentoCommand(OrcamentoViewModel item, DateTime dtPrevisaoEntrega) : base(item)
        {
            DtPrevisaoEntrega = dtPrevisaoEntrega;
        }

        public DateTime DtPrevisaoEntrega { get; }
    }

}
