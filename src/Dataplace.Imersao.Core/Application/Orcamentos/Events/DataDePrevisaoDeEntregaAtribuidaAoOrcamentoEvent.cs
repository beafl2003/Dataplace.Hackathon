using Dataplace.Imersao.Core.Application.Orcamentos.ViewModels;
using System;

namespace Dataplace.Imersao.Core.Application.Orcamentos.Events
{
    public class DataDePrevisaoDeEntregaAtribuidaAoOrcamentoEvent : OrcamentoEventBase
    {
        public DataDePrevisaoDeEntregaAtribuidaAoOrcamentoEvent(OrcamentoViewModel item, DateTime dtPrevisaoEntrega) : base(item)
        {
            DtPrevisaoEntrega = dtPrevisaoEntrega;
        }

        public DateTime DtPrevisaoEntrega { get; }
    }
}
