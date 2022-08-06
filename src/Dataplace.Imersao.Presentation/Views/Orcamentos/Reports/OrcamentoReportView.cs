using Dataplace.Core.Domain.Localization.Messages.Extensions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Dataplace.Imersao.Presentation.Views.Orcamentos.Reports
{
    public partial class OrcamentoReportView : dpLibrary05.Infrastructure.UserControls.ucSymGen_ReportDialog
    {

        private const string _name = "Totalização de Condições de Pagamento";
        private const int _itemSeg = 649;
        private const int _reportId = 1006338;
        public OrcamentoReportView()
        {
            InitializeComponent();

            this.ReportConfiguration += OrcamentoReportView_ReportConfiguration;
            this.BeforeLoadReport += OrcamentoReportView_BeforeLoadReport;
            this.LoadReport += OrcamentoReportView_LoadReport;
            this.AfterLoadReport += OrcamentoReportView_AfterLoadReport;
        }


        private void OrcamentoReportView_ReportConfiguration(object sender, ReportConfigurationEventArgs e)
        {
            // configuraçõe iniciais da tela
            // item de segurança
            // id do report,

            this.Text = _name;
            e.ReportList.Add(_reportId,
                           new dpLibrary05.SymphonyReport.clsSymReport.ReportData(true)
                           {
                               Id = _reportId,
                               ItemSeg = _itemSeg.ToString(),
                               Name = _name
                           });
            e.SecurityIdList.Add(_itemSeg);

        }

        private void OrcamentoReportView_BeforeLoadReport(object sender, BeforeLoadReportEventArgs e)
        {
            // validações para exibir report
            // item de segurança
            // preenchimento dos controles

        }
 
        private void OrcamentoReportView_LoadReport(object sender, LoadReportEventArgs e)
        {
            // defini o report a ser executado
            e.ReportData = ReportList[_reportId];

            // passagem dos parâmetros para o report
            //e.ReportData.Parametros.Items.Add("cdEmpresa", dpLibrary05.mGenerico.SymPRM.cdempresa);
            //e.ReportData.Parametros.Items.Add("cdFilial", dpLibrary05.mGenerico.SymPRM.cdfilial);
        }

        private void OrcamentoReportView_AfterLoadReport(object sender, AfterLoadReportEventArgs e)
        {
            // ...
        }

      
    }
}
