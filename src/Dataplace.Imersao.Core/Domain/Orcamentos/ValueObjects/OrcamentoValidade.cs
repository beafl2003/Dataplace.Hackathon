using Dataplace.Imersao.Core.Domain.Exections;
using System;

namespace Dataplace.Imersao.Core.Domain.Orcamentos.ValueObjects
{
    public class OrcamentoValidadeBase
    {
        // uso orm
        protected OrcamentoValidadeBase() { }

        public DateTime Data { get; protected set; }
        public int Dias { get; protected set; }
        public bool IsValid()
        {
            if (Dias == 0 || Data == default(DateTime))
                return false;
            else
                return true;
        }
    }

    public class OrcamentoValidade : OrcamentoValidadeBase
    {
        // uso orm
        protected OrcamentoValidade() { }
        public OrcamentoValidade(Orcamento orcamento, int dias)
        {
            if(dias < 0)
                throw new ValueLowerThanZeroDomainException(nameof(dias));

            Dias = dias;
            Data = orcamento.DtOrcamento.Date.AddDays(dias);

        }
       
    }

    public class OrcamentoValidadePorData : OrcamentoValidadeBase
    {
        // uso orm
        protected OrcamentoValidadePorData() { }
        public OrcamentoValidadePorData(Orcamento orcamento, DateTime data)
        {
            if (data < orcamento.DtOrcamento)
                throw new DomainException("Data de validade deve ser anterior a data do orçamento");

            Dias = (int)(data.Date - orcamento.DtOrcamento.Date).TotalDays;
            Data = data.Date;


        }

    }
}
