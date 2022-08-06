using Dataplace.Imersao.Core.Domain.Exections;
using System;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects
{
    public class OrcamentoPrevisaoEntrega
    {
        // uso orm
        protected OrcamentoPrevisaoEntrega() { }
        public OrcamentoPrevisaoEntrega(Orcamento orcamento, DateTime data)
        {
            if (data.Date < orcamento.DtOrcamento.Date)
                throw new DomainException("Data de previsão de entrega anterior a data do orçamento");

            Dias = (int)(data - orcamento.DtOrcamento.Date).TotalDays;
            Data = data.Date;

        }

        public DateTime Data { get; private set; }
        public int Dias { get; private set; }

        public bool IsValid()
        {
            if (Dias == 0 || Data == default(DateTime))
                return false;
            else
                return true;
        }
    }
}
