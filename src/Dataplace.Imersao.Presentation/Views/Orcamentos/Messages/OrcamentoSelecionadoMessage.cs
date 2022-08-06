namespace Dataplace.Imersao.Presentation.Views.Orcamentos.Messages
{
    public class OrcamentoSelecionadoMessage
    {
        public OrcamentoSelecionadoMessage(int numOrcamento)
        {
            NumOrcamento = numOrcamento;
        }

        public int NumOrcamento { get; }
    }
}
